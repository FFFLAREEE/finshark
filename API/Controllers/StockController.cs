using API.Data;
using API.Dtos.Stock;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController :ControllerBase
    {
        private readonly ApplicationDBContext  _context;
        //readonly 表示 _context 只能：
        // 在声明时赋值；或者
        // 在构造函数里赋值。
        public StockController(ApplicationDBContext context)
        {
            _context = context;
            //context
            //     ↓ 构造函数临时收到的数据库入口
            // _context = context
            //     ↓ 保存下来
            // _context
            //     ↓ Controller 的其他方法都可以使用
        }

        [HttpGet]//表示下面的方法负责处理 HTTP GET 请求
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
                .Select(s => s.ToStockDto());//从数据库的 Stocks 表中取出所有记录，并转换成一个 List。
            //_context.Stocks
            // 访问 ApplicationDBContext 中定义的 Stocks
            
            //.ToList()
            // 执行数据库查询，把查到的所有股票转成：
            // List<Stock>
            
            //可以把 C# LINQ 的 Select() 理解成 JavaScript 的 map()。
            // 它们的作用都是： 对集合里的每个元素进行一次转换，最后得到一个新集合。
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock= _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();

            _context.Stocks.Add(stockModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);
        }

        [HttpPut]
        [Route("{id}")]//表示这个 API 的 URL 中必须包含一个 id
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        //IActionResult
        // 表示该方法会返回一个 HTTP 响应
        //Update
        // 这是方法名，表示它负责更新股票。
        // [FromRoute] int id
        // 表示从 URL 路由中取得 id。
        //[FromBody] UpdateStockRequestDto updateDto
        // 表示从 HTTP 请求 body 中读取 JSON，并转换成 UpdateStockRequestDto 对象
        {
            var stockModel =_context.Stocks.FirstOrDefault(x=>x.Id == id);//对每一条股票记录 x，检查它的 Id 是否等于传进来的 id
            //FirstOrDefault(...) 如果找到了，返回第一条符合条件的数据； 如果没有找到，返回默认值 null；
            
            if (stockModel == null)
            {
                return NotFound();
            }
            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName= updateDto.CompanyName;
            stockModel.Purchase= updateDto.Purchase;
            stockModel.LastDiv= updateDto.LastDiv;
            stockModel.MarketCap= updateDto.MarketCap;
            stockModel.Industry= updateDto.Industry;
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
            //stockModel.ToStockDto() 把数据库实体 Stock 转换成用于返回给前端的 StockDto，可以避免把数据库实体中的所有内容直接暴露给前端，只返回 API 希望提供的数据
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel=_context.Stocks.FirstOrDefault(x=>x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }
            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
    
}


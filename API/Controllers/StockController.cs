using API.Data;
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
            var stocks=_context.Stocks.ToList();//从数据库的 Stocks 表中取出所有记录，并转换成一个 List。
            //_context.Stocks
            // 访问 ApplicationDBContext 中定义的 Stocks
            
            //.ToList()
            // 执行数据库查询，把查到的所有股票转成：
            // List<Stock>
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
            return Ok(stock);
        }
    }
    
}


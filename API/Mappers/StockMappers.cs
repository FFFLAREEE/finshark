using API.Dtos.Stock;
using API.Models;


namespace API.Mappers
{
    public static class StockMappers
    {
//把数据库中的 Stock 对象，转换成准备返回给前端的 StockDto 对象。
        public static StockDto ToStockDto(this Stock stockModel)
        //输入：一个 Stock 类型的 stockModel
        // 输出：一个 StockDto
        // this Stock 把它变成了一个扩展方法
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv =  stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,

            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        //public：其他文件可以使用这个方法。
        // static：不需要通过 new StockMappers() 创建对象。
        // Stock：这个方法最终返回一个 Stock 对象。
        // ToStockFromCreateDto：方法名，意思是“从创建股票的 DTO 转换成 Stock”。
        // this CreateStockRequestDto stockDto：接收一个 CreateStockRequestDto，并把这个方法变成扩展方法。
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
                
            };
            //为什么不能直接保存 DTO？
            // 因为 EF Core 的数据库配置使用的是：
            // DbSet<Stock> Stocks
            // 所以数据库接受的是 Stock，不是 CreateStockRequestDto：
        }
    }
}


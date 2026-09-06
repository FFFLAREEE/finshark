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
    }
}


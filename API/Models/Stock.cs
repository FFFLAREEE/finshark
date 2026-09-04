using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
//Column：说明下面这个 C# 属性如何映射到数据库列
// TypeName：指定数据库列的数据类型
// 18：一共最多存储 18 位数字
// 2：其中小数点后最多有 2 位
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        //这个 [Column(...)] 只作用于紧跟在它下面的 LastDiv 属性。
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
//list 允许多个相同的元素
//// Navigation property: one Stock can have multiple Comments
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}


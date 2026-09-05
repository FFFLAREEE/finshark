using API.Models;
using Microsoft.EntityFrameworkCore;
//EF Core 数据库上下文
namespace API.Data
{
    public class ApplicationDBContext : DbContext//表示 ApplicationDBContext 继承 EF Core 提供的 DbContext。
                                                 // 也就是说：
                                                 // ApplicationDBContext 是一个 DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> dbContextOptions)
        : base(dbContextOptions)
        //base(dbContextOptions) 相当于告诉父类：
        // 这是数据库配置，你拿去建立并管理数据库连接。
        // 真正懂得如何连接和操作数据库的是 EF Core 提供的 DbContext。你的 ApplicationDBContext 只负责接收配置并传给它。
        
        //这是 ApplicationDBContext 的构造函数
        //它表示构造函数需要接收一个参数：
        // 部分	                                    含义
        // DbContextOptions<ApplicationDBContext>	参数的数据类型
        // dbContextOptions	                        参数名称
        {
            
        }
        public DbSet<Stock>Stocks{get;set;}
        public DbSet<Comment> Comments{get;set;}

        // seed股票数据
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 1,
                    Symbol = "AAPL",
                    CompanyName = "Apple Inc.",
                    Purchase = 150.00m,
                    LastDiv = 0.24m,
                    Industry = "Technology",
                    MarketCap = 3000000000000
                },
                new Stock
                {
                    Id = 2,
                    Symbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    Purchase = 320.00m,
                    LastDiv = 0.75m,
                    Industry = "Technology",
                    MarketCap = 2800000000000
                },
                new Stock
                {
                    Id = 3,
                    Symbol = "TSLA",
                    CompanyName = "Tesla Inc.",
                    Purchase = 220.00m,
                    LastDiv = 0.00m,
                    Industry = "Automotive",
                    MarketCap = 700000000000
                }
            );
        }

    }
    
}


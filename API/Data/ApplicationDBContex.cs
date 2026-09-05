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
       
        
    }
    
}


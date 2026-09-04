namespace API.Models{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        //这两行共同表示：这条评论属于哪一只股票，用来建立 Comment 和 Stock 之间的关系。
        public int? StockId { get; set; }
        //int? 中的 ? 表示它可以是 null。一条评论可以不属于任何股票
        //Navigation property, allow us to navigate within the model
        //StockId 只告诉你股票编号，而 Stock 让你直接访问股票的详细信息。
        public Stock? Stock { get; set; }
        
    }}


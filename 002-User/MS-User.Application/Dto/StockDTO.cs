namespace MS_User.Application.Dto
{
    public class StockDTO
    {
        public string Symbol { get; set; }

        public int Amount { get; set; }

        public decimal CurrentPrice { get; set; }

        public int? AccountId { get; set; }
    }
}
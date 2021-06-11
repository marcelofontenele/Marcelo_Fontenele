namespace MS_Investiments.Application.Dto
{
    public class OrderDTO
    {
        public int Amount { get; set; }

        public string Symbol { get; set; }

        public int UserId { get; set; }

        public int AccountId { get; set; }

        public decimal Total => this.Amount * this.Value;

        public decimal Value { get; set; }
    }
}
namespace MS_User.Application.Dto
{
    public class AccountTransactionDTO
    {
        public int AccountId { get; set; }

        public decimal Value { get; set; }

        public StockDTO Stock { get; set; }
    }
}
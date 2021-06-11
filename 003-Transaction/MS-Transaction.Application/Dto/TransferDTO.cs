namespace MS_Transaction.Application.Dto
{
    public class TransferDTO
    {
        public string Event { get; set; }

        public string Amount { get; set; }

        public TargetDTO Target { get; set; }

        public OriginDTO Origin { get; set; }
    }
}
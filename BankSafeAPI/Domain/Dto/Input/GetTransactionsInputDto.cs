namespace BankSafeAPI.Domain.Dto.Input
{
    public class GetTransactionsInputDto : TransactionBaseInputDto
    {
        public int TransactionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

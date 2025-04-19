namespace BankSafeAPI.Domain.Dto.Input
{
    public class GetTransactionsInputDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

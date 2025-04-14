namespace BankSafeAPI.Domain.Enums
{
    public class AccountStatus
    {
        public const string Active = "active";
        public const string Closed = "closed";
        public const string Frozen = "frozen";
    }

    public class AccountType
    {
        public const string checking = "Corrente";
        public const string savings = "Poupança";
        public const string salary = "Salário";
    }
}

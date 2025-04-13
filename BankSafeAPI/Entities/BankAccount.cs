namespace BankSafeAPI.Entities
{
    public class BankAccount
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string AccountNumber { get; set; }
        // public decimal Balance { get; set; }
        public Guid UserId { get; private set; }

        public BankAccount(string accountNumber, Guid userId)
        {
            AccountNumber = accountNumber;
            UserId = userId;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException(
                    "Para efetuar um deposito o valor precisa ser maior que 0"
                );
            // Balance += amount;
        }

        public void WithDraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException(
                    "Para efetuar um saque o valor precisa ser maior que 0"
                );
            // if (amount > Balance)
            //     throw new InvalidOperationException("Saldo insuficiente");
            // Balance -= amount;
        }
    }
}

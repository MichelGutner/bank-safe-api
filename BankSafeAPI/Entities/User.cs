using System.ComponentModel.DataAnnotations.Schema;

namespace BankSafeAPI.Entities
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Cpf { get; private set; }

        public List<BankAccount> BankAccounts { get; private set; } = [];

        public User(string name, string cpf)
        {
            if (name == string.Empty) throw new ArgumentException("Nome inválido");
            Name = name;
            Cpf = FormatCpf(cpf);

            Console.WriteLine(cpf, name);
        }

        public void AddBankAccount(BankAccount account)
        {
            BankAccounts.Add(account);
        }

        private static string FormatCpf(string cpf)
        {
            cpf = new string([.. cpf.Where(char.IsDigit)]);
            if (cpf.Length != 11) throw new ArgumentException("CPF inválido. Deve conter 11 dígitos.");
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}

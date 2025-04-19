using System.Runtime.Serialization;

namespace BankSafeAPI.Domain.Enums
{
    public enum EnumTransactionType
    {
        [EnumMember(Value = "deposit")]
        Deposit,

        [EnumMember(Value = "withdraw")]
        Withdraw,

        [EnumMember(Value = "transfer")]
        Transfer,

        [EnumMember(Value = "payment")]
        Payment,
    }
}

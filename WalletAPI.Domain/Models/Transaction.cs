using WalletAPI.Domain.Enums;

namespace WalletAPI.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Wallet Wallet { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

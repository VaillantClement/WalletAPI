using System;

namespace WalletAPI.Domain.Models
{
    public class Wallet
    {
        public Currency Currency { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
    }
}

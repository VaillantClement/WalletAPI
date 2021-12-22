using System;
using System.Data.Entity;
using System.Linq;

namespace WalletAPI.DAL.Repositories
{
    public static class WalletRepository
    {
        public static void AddWallet(Guid identityId, int currencyId)
        {
            using (var context = new WalletEntities())
            {
                var wallet = new Wallet()
                {
                    IdentityId = identityId,
                    Balance = 0,
                    CurrencyId = currencyId
                };

                context.Wallets.Add(wallet);
                context.SaveChanges();
            }
        }
    }
}
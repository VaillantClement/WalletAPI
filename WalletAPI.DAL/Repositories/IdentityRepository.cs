using System;
using System.Data.Entity;
using System.Linq;

namespace WalletAPI.DAL.Repositories
{
    public static class IdentityRepository
    {
        public static bool CheckIfUserExists(string username, string password)
        {
            using (var context = new WalletEntities())
            {
                return context.Identities.Any(i =>
                    i.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                    && i.Password.Equals(password, StringComparison.OrdinalIgnoreCase)
                );
            }
        }

        public static Identity GetIdentity(Guid id, bool includeWallets = false)
        {
            using (var context = new WalletEntities())
            {
                var identity = context.Identities.Where(i => i.Id == id);

                if (includeWallets && identity != null)
                {
                    identity = identity
                        .Include(i => i.Wallets)
                        .Include(x => x.Wallets.Select(w => w.Currency));
                }

                return identity.FirstOrDefault();
            }
        }

        public static void AddIdentity(Identity identity)
        {
            using (var context = new WalletEntities())
            {
                var identityDB = context.Identities.Add(identity);

                context.Wallets.AddRange(identity.Wallets);

                context.SaveChanges();
            }
        }

        public static void UpdateIdentity(Identity identity)
        {
            using (var context = new WalletEntities())
            {
                var identityDB = context.Identities.Find(identity.Id);

                identityDB.Email = identity.Email;
                identityDB.FirstName = identity.FirstName;
                identityDB.LastName = identity.LastName;
                identityDB.Password = identity.Password;
                identityDB.IdCardNumber = identity.IdCardNumber;
                identityDB.Username = identity.Username;
                identityDB.DateOfBirth = identity.DateOfBirth;

                context.SaveChanges();
            }
        }
    }
}

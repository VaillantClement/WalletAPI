using System;
using WalletAPI.DAL.Repositories;
using WalletAPI.Domain.Models;

namespace WalletAPI.Domain
{
    public static class IdentityService
    {
        public static bool CheckUserAuthentication(string username, string password)
        {
            return IdentityRepository.CheckIfUserExists(username, password);
        }

        public static Identity GetIdentity(Guid id, bool includeWallets = false)
        {
            Identity identity = null;

            var identityDB = IdentityRepository.GetIdentity(id, includeWallets);

            if (identityDB != null)
            {
                identity = new Identity()
                {
                    DateOfBirth = identityDB.DateOfBirth,
                    Email = identityDB.Email,
                    FirstName = identityDB.FirstName,
                    IdCardNumber = identityDB.IdCardNumber,
                    LastName = identityDB.LastName,
                    Password = identityDB.Password,
                    Username = identityDB.Username
                };

                if (includeWallets)
                {
                    foreach (var wallet in identityDB.Wallets)
                    {
                        identity.Wallets.Add(new Wallet()
                        {
                            Balance = wallet.Balance,
                            CardNumber = wallet.CardNumber,
                            Currency = new Currency()
                            {
                                CurrencyCode = wallet.Currency.CurrencyCode,
                                Rate = wallet.Currency.Rate
                            }
                        });
                    }
                }
            }

            return identity;
        }

        public static Response Create(Identity identityModel)
        {
            var response = new Response();

            var identityDb = new DAL.Identity()
            {
                Id = Guid.NewGuid(),
                DateOfBirth = identityModel.DateOfBirth,
                Email = identityModel.Email,
                FirstName = identityModel.FirstName,
                IdCardNumber = identityModel.IdCardNumber,
                LastName = identityModel.LastName,
                Password = identityModel.Password,
                Username = identityModel.Username
            };

            // When adding a new identity, create automatically a EUR wallet tied to this identity
            identityDb.Wallets.Add(new DAL.Wallet()
            {
                Balance = 0,
                CardNumber = Utilities.StringUtilities.Create16DigitString(),
                CurrencyId = (int)Enums.Currency.EUR,
                IdentityId = identityDb.Id
            });

            IdentityRepository.AddIdentity(identityDb);

            response.Success = true;

            return response;
        }

        public static Response Update(Identity identityModel)
        {
            var response = new Response<Identity>();

            var identityDb = new DAL.Identity()
            {
                DateOfBirth = identityModel.DateOfBirth,
                Email = identityModel.Email,
                FirstName = identityModel.FirstName,
                IdCardNumber = identityModel.IdCardNumber,
                LastName = identityModel.LastName,
                Password = identityModel.Password,
                Username = identityModel.Username
            };

            IdentityRepository.UpdateIdentity(identityDb);

            response.Success = true;

            return response;
        }
    }
}
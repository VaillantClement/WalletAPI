using System;
using WalletAPI.DAL.Repositories;
using WalletAPI.Domain.Models;

namespace WalletAPI.Domain
{
    public static class WalletService
    {
        public static Response AddWallet(Guid identityId, int currencyId)
        {
            var response = new Response();

            WalletRepository.AddWallet(identityId, currencyId);

            response.Success = true;

            return response;
        }
    }
}
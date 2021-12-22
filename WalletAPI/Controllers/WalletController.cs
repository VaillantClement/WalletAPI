using System;
using System.Web.Http;
using WalletAPI.Domain;
using WalletAPI.Domain.Models;
using WalletAPI.Filters;

namespace WalletAPI.Controllers
{
    [Authorize]
    public class WalletController : ApiController
    {
        [HttpPost]
        [ValidateModel]
        public Response Add([FromBody] Guid identityId, int currencyId)
        {
            return WalletService.AddWallet(identityId, currencyId);
        }

        [HttpPost]
        [ValidateModel]
        public Response Credit([FromBody] Guid identityId, int currencyId, decimal amount)
        {
            return WalletService.AddWallet(identityId, currencyId);
        }

        [HttpPost]
        [ValidateModel]
        public Response Debit([FromBody] Guid identityId, int currencyId, decimal amount)
        {
            return WalletService.AddWallet(identityId, currencyId);
        }

        [HttpPost]
        [ValidateModel]
        public Response Trade([FromBody] Guid identityId, int currencyId, decimal amount)
        {
            return WalletService.AddWallet(identityId, currencyId);
        }

        [HttpPost]
        [ValidateModel]
        public Response GetTransactions([FromBody] Guid identityId, int currencyId, decimal amount)
        {
            return WalletService.AddWallet(identityId, currencyId);
        }
    }
}

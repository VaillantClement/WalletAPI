using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using WalletAPI.Attributes;
using WalletAPI.Domain;
using WalletAPI.Domain.Models;
using WalletAPI.Filters;

namespace WalletAPI.Controllers
{
    public class IdentityController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public Response<Login> Login(Login model)
        {
            var response = new Response<Login>();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                return response;
            }

            response.Success = IdentityService.CheckUserAuthentication(model.UserName, model.Password);

            if (response.Success)
            {
                // Authenticate user
                var identity = new GenericIdentity(model.UserName);
                var principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }

            return response;
        }

        [HttpPost]
        [ValidateModel]
        public Response<Identity> Create([FromBody] Identity identityModel)
        {
            return IdentityService.Create(identityModel);
        }

        [Authorize]
        public Identity Get(Guid id)
        {
            return IdentityService.GetIdentity(id);
        }


        [HttpPost]
        [Authorize]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public Response Update([FromBody] Identity identityModel)
        {
            return IdentityService.Update(identityModel);
        }
    }
}

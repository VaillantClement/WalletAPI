using System.Web.Mvc;

namespace WalletAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}
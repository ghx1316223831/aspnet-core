using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DH.Inspection.Controllers;

namespace DH.Inspection.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : InspectionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

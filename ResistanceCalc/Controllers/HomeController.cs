using ResistanceCalc.Models;
using ResistanceCalc.Repository;
using ResistanceCalc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ResistanceCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOhmValueCalculator ohmCalculator;
        public HomeController()
        {
            ohmCalculator = new OhmValueCalculator();
        }

        public async Task<ActionResult> Index()
        {
            //Intialize the VM
            var indexVM = new IndexViewModel();

            return await Task.FromResult(View(indexVM));
        }

        [HttpPost]
        public async Task<ActionResult> Index(IndexViewModel indexVM)
        {
            var response = new IndexResponseModel();
            try
            {
                ValidateJsonAntiForgeryToken(indexVM.__RequestVerificationToken);

                if (ModelState.IsValid)
                    response.OhmValue = await Task.Run(() => ohmCalculator.CalculateOhmValue(indexVM.BandAColor, indexVM.BandBColor, indexVM.BandCColor, indexVM.BandDColor));
                else
                    throw new ECCException("Invalid parameters");
            }
            catch(ECCException ec)
            {
                response.IsError = true;
                response.ErrorMessage = ec.Message;
            }
            catch
            {
                response.IsError = true;
                response.ErrorMessage = "Unexpected Error has occurred";
            }

            return Json(response);
        }


        void ValidateJsonAntiForgeryToken(string requestForgeryFormToken)
        {
            var requestForgeryCookie = this.ControllerContext.RequestContext.HttpContext.Request.Cookies[AntiForgeryConfig.CookieName];
            AntiForgery.Validate(requestForgeryCookie.Value, requestForgeryFormToken);
        }
    }
}
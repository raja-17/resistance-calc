using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResistanceCalc;
using ResistanceCalc.Controllers;
using ResistanceCalc.Models;
using ResistanceCalc.Util;

namespace ResistanceCalc.Tests.Controllers
{
    /// <summary>
    /// Test class for HomeController
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        private readonly HomeController controller;
        public HomeControllerTest()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public async Task Index()
        {
            var result = await controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task IndexPost()
        {
            IndexViewModel indexVM = new IndexViewModel() { BandAColor = "Black", BandBColor = "Orange", BandCColor = "Red", BandDColor = "Gold" };

            var result = await controller.Index(indexVM) as JsonResult;

            var data = result.Data as IndexResponseModel;

            Assert.IsNotNull(data);

            Assert.IsFalse(data.IsError);

            Assert.IsNull(data.ErrorMessage);
        }

        //NOTE: OhmValueCalculatorTest contains most of the related test cases
        [TestMethod]
        public async Task IndexPostInvalidParams()
        {
            IndexViewModel indexVM = new IndexViewModel() { BandBColor = "Orange", BandCColor = "Red", BandDColor = "Gold" };

            var result = await controller.Index(indexVM) as JsonResult;

            var data = result.Data as IndexResponseModel;

            Assert.IsNotNull(data);

            Assert.IsTrue(data.IsError);

            Console.WriteLine(data.ErrorMessage);
        }
    }
}

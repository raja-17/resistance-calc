using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResistanceCalc.Repository;
using ResistanceCalc.Util;

namespace ResistanceCalc.Tests.Repository
{
    /// <summary>
    /// Test class for OhmValueCalculator
    /// </summary>
    [TestClass]
    public class OhmValueCalculatorTest
    {
        private readonly IOhmValueCalculator ohmValueCalculator;
        public OhmValueCalculatorTest()
        {
            ohmValueCalculator = new OhmValueCalculator();
        }
                        
        [TestMethod]
        public void MinLimitTest()
        {
            var val = ohmValueCalculator.CalculateOhmValue("Black", "Black", "Black", "Black");
            
            Assert.AreEqual(0, val);
        }
        
        [TestMethod]
        public void MaxLimitTest()
        {
            var val = ohmValueCalculator.CalculateOhmValue("White", "White", "White", "White");

            Assert.AreEqual(99000000000, val);
        }

        [TestMethod]
        [ExpectedException(typeof(ECCException), "Validation failed: No Exception Thrown")]
        public void InvalidBandATest()
        {
            var val = ohmValueCalculator.CalculateOhmValue("", "White", "White", "White");
        }

        [TestMethod]
        public void InvalidBandAMessageTest()
        {
            try
            {
                var val = ohmValueCalculator.CalculateOhmValue("HELLO", "White", "White", "White");
            }
            catch(ECCException ex)
            {
                StringAssert.Contains(ex.Message, "Invalid Band A Color: HELLO");
                Console.WriteLine(ex.Message);
                return;
            }

            Assert.Fail("No Exception Thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ECCException), "Validation failed: No Exception Thrown")]
        public void InvalidBandBTest()
        {
            var val = ohmValueCalculator.CalculateOhmValue("White", "", "White", "White");
        }

        [TestMethod]
        public void InvalidBandBMessageTest()
        {
            try
            {
                var val = ohmValueCalculator.CalculateOhmValue("White", "HELLO", "White", "White");
            }
            catch (ECCException ex)
            {
                StringAssert.Contains(ex.Message, "Invalid Band B Color: HELLO");
                Console.WriteLine(ex.Message);
                return;
            }

            Assert.Fail("No Exception Thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ECCException), "Validation failed: No Exception Thrown")]
        public void InvalidBandCTest()
        {
            var val = ohmValueCalculator.CalculateOhmValue("White", "White", "", "White");
        }

        [TestMethod]
        public void InvalidBandCMessageTest()
        {
            try
            {
                var val = ohmValueCalculator.CalculateOhmValue("White", "White", "HELLO", "White");
            }
            catch (ECCException ex)
            {
                StringAssert.Contains(ex.Message, "Invalid Band C Color: HELLO");
                Console.WriteLine(ex.Message);
                return;
            }

            Assert.Fail("No Exception Thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ECCException), "Validation failed: No Exception Thrown")]
        public void InvalidBandDTest()
        {
            var val = ohmValueCalculator.CalculateOhmValue("White", "White", "White", "");
        }

        [TestMethod]
        public void InvalidBandDMessageTest()
        {
            try
            {
                var val = ohmValueCalculator.CalculateOhmValue("White", "White", "White", "HELLO");
            }
            catch (ECCException ex)
            {
                StringAssert.Contains(ex.Message, "Invalid Band D Color: HELLO");
                Console.WriteLine(ex.Message);
                return;
            }

            Assert.Fail("No Exception Thrown");
        }


        [TestMethod]
        public void InvalidSignificantNum1Test()
        {
            var invalidFirstColors = new List<Color>() { Color.Pink, Color.Silver, Color.Gold, Color.None };

            foreach (var item in invalidFirstColors)
            {
                var color = item.ToString();
                try
                {
                    var val = ohmValueCalculator.CalculateOhmValue(color, "White", "White", "White");

                    Assert.Fail($"No Exception Thrown for Color: {color}");
                }
                catch (ECCException ex)
                {
                    StringAssert.Contains(ex.Message, $"'{color}' cannot be a Band A Color");
                    Console.WriteLine(ex.Message);
                }
            }            
        }

        [TestMethod]
        public void InvalidSignificantNum2Test()
        {
            var invalidFirstColors = new List<Color>() { Color.Pink, Color.Silver, Color.Gold, Color.None };

            foreach (var item in invalidFirstColors)
            {
                var color = item.ToString();
                try
                {
                    var val = ohmValueCalculator.CalculateOhmValue("White", color, "White", "White");

                    Assert.Fail($"No Exception Thrown for Color: {color}");
                }
                catch (ECCException ex)
                {
                    StringAssert.Contains(ex.Message, $"'{color}' cannot be a Band B Color");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        [TestMethod]
        public void InvalidMultiplierTest()
        {
            try
            {
                var val = ohmValueCalculator.CalculateOhmValue("White", "White", Color.None.ToString(), "White");

                Assert.Fail($"No Exception Thrown for Color: None");
            }
            catch (ECCException ex)
            {
                StringAssert.Contains(ex.Message, $"'None' cannot be a Band C Color");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculator.Tests
{
    [TestClass]
    public class CalculatorFixture
    {
        [TestMethod]
        public void Display_should_be_blank_for_new_calculator()
        {
            var calc = new Calculator();
            Assert.AreEqual(string.Empty, calc.DisplayText);
        }
    }
}

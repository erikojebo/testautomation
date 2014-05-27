using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using studiecirkel_1;

namespace Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void SetUp()
        {
            _calculator = new Calculator();            
        }

        [TestMethod]
        public void Adding_two_numbers_returns_sum()
        {
            var actual = _calculator.Add(1, 1);

            Assert.AreEqual(2, actual);
        }
    }
}

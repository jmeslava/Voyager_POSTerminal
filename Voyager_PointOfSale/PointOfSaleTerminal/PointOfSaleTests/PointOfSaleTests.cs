using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSaleTerminalLibrary;


namespace PointOfSaleTests
{
    
    [TestClass]
    public class PointOfSaleTest
    {
        [TestMethod]
        public void SingleA()
        {
            decimal expected = 1.25M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void SingleB()
        {
            decimal expected = 4.25M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("B");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SingleC()
        {
            decimal expected = 1.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("C");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SingleD()
        {
            decimal expected = 0.75M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("D");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TwoValidCodesInOneString()
        {
            decimal expected = 0.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("AA");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CCCCCCC()
        {
            decimal expected = 6.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ABCDABA()
        {
            decimal expected = 13.25M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ABCD()
        {
            decimal expected = 7.25M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EMPTY()
        {
            decimal expected = 0.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EmptyWithValidCodes()
        {
            decimal expected = 2.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("");
            terminal.ScanProduct("A");
            terminal.ScanProduct("D");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EmptyWithUnknownCodes()
        {
            decimal expected = 0.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("");
            terminal.ScanProduct("F");
            terminal.ScanProduct("G");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SingleUnknown()
        {
            decimal expected = 0.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("F");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AllUnknown()
        {
            decimal expected = 0.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("F");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UnknownStartWithValidCodes()
        {
            decimal expected = 2.75M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("F");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidCodesWithUnknownsMixed()
        {
            decimal expected = 5.25M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("E");
            terminal.ScanProduct("A");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CBulkCombination()
        {
            decimal expected = 5.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void C1LessFromCombination()
        {
            decimal expected = 5.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ABulkCombination()
        {
            decimal expected = 3.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void A1LessFromCombination()
        {
            decimal expected = 2.50M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ACombinationWithCCombination()
        {
            decimal expected = 8.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ChangePriceOfA()
        {
            decimal expected = 1.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing("A", 1.00);
            terminal.ScanProduct("A");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ChangePriceOfB()
        {
            decimal expected = 1.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing("B", 1.00);
            terminal.ScanProduct("B");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ChangePriceOfC()
        {
            decimal expected = 1.50M;
            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing("C", 1.50);
            terminal.ScanProduct("C");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ChangePriceOfD()
        {
            decimal expected = 1.00M;
            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing("D", 1.00);
            terminal.ScanProduct("D");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result);
        }

    }
}

using System;

namespace PointOfSaleTerminalLibrary
{

    /// <summary>
    /// Abstract class with calculate functions for products with and without bulk deals
    /// </summary>
    abstract class Compute
    {
        public abstract decimal calculate(int amount, decimal price);
        public abstract decimal calculate(int bulkAmount, decimal bulkPrice, int amount, decimal price);
    }

    /// Implements functions from Compute to calculate a total price for a product.
    /// Both functions are named calculate but takes different parameters for products with/without bulk deals
    /// </summary>
    class Calculator : Compute
    {
        public override decimal calculate(int bulkAmount, decimal bulkPrice, int amount, decimal price)
        {
            int bulkUnits = amount / bulkAmount;
            decimal bulkTotal = bulkUnits * bulkPrice;

            int singleUnits = amount % bulkAmount;
            decimal UnitsTotal = singleUnits * price;

            decimal total = bulkTotal + UnitsTotal;

            return total;
        }

        public override decimal calculate(int amount, decimal price)
        {
            decimal total = amount * price;
            return total;
        }
    }

    /// <summary>
    /// The Main Class for Point Of Sale 
    /// </summary>
    public class PointOfSaleTerminal
    {
        private int A_Amount = 0;
        private int B_Amount = 0;
        private int C_Amount = 0;
        private int D_Amount = 0;
        private int A_BULK_AMOUNT = 3;
        private int C_BULK_AMOUNT = 6;
        private decimal A_PRICE = 1.25M;
        private decimal B_PRICE = 4.25M;
        private decimal C_PRICE = 1.00M;
        private decimal D_PRICE = 0.75M;
        private decimal A_BULK_PRICE = 3.00M;
        private decimal C_BULK_PRICE = 5.00M;
        private decimal totalPrice = 0.00M;

        /// <summary>
        

        /// <summary>
        /// Function to adjust prices of existing products. Adjusts Single Unit prices only
        /// </summary>
        /// <param name="product"> Product Code of price to be changed </param>
        /// <param name="price"> Value of the Product Price to be changed to </param>
        public void SetPricing(String product, double price)
        {
            String productCode = product.ToLower();
            decimal productPrice = Math.Round(Convert.ToDecimal(price), 2);
            
            switch (productCode)
            {
                case "a":
                    A_PRICE = productPrice;
                    Console.WriteLine("Price for product ", productCode, " updated to $", productPrice);
                    break;

                case "b":
                    B_PRICE = productPrice;
                    Console.WriteLine("Price for product ", productCode, " updated to $", productPrice);
                    break;

                case "c":
                    C_PRICE = productPrice;
                    Console.WriteLine("Price for product ", productCode, " updated to $", productPrice);
                    break;

                case "d":
                    D_PRICE = productPrice;
                    Console.WriteLine("Price for product ",productCode," updated to $",productPrice);
                    break;

                default:
                    Console.WriteLine("Unknown Product Code, Prices unchanged");
                    break;
            }
        }
        
        /// <summary>
        /// Scans a Single Product Code and increases amount of said Product scanned
        /// </summary>
        /// <param name="product"> Product Code of to be Scanned </param>
        public void ScanProduct(String product)
        {
            String productCode = product.ToLower();

            switch (productCode)
            {
                case "a":
                    A_Amount += 1;
                    break;

                case "b":
                    B_Amount += 1;
                    break;

                case "c":
                    C_Amount += 1;
                    break;

                case "d":
                    D_Amount += 1;
                    break;

                default:
                    Console.WriteLine("Unknown Product Code");
                    break;
            }

        }

        /// <summary>
        /// Calculates the total of each valid Product code scanned through the Calculator Class
        /// </summary>
        /// <returns> Total Sum of all valid scanned products </returns>
        public decimal CalculateTotal()
        {
            Calculator calculator = new Calculator();
            decimal ATotal = calculator.calculate(A_BULK_AMOUNT, A_BULK_PRICE, A_Amount, A_PRICE);
            decimal BTotal = calculator.calculate(B_Amount, B_PRICE);
            decimal CTotal = calculator.calculate(C_BULK_AMOUNT, C_BULK_PRICE, C_Amount, C_PRICE);
            decimal DTotal = calculator.calculate(D_Amount, D_PRICE);
            totalPrice = ATotal + BTotal + CTotal + DTotal;

            return totalPrice;
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            var terminal = new PointOfSaleTerminal();
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            decimal result = terminal.CalculateTotal();
            Console.WriteLine(result);
           
            
        }
    }


}

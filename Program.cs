using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating a dictionay of stocks
            Dictionary<string, string> stocks = new Dictionary<string, string>() {
                { "GM", "General Motors"},
                { "CAT", "Caterpillar"},
                { "AAPL", "Apple"},
                { "MSFT", "Microsoft"},
            };
            // creating a list of shares and purchases
            List<(string ticker, int shares, double price)> purchases =
                new List<(string, int, double)>()
                {
                    ("AAPL", 201, 457.09),
                    ("CAT", 10, 109.11),
                    ("AAPL", 220, 899.27),
                    ("MSFT", 34, 92.11),
                    ("CAT", 45, 92.21),
                    ("MSFT", 77, 88.45),
                };
            // creating a dictionary
            Dictionary<string, double> portfolio = new Dictionary<string, double>();


            // Iterate over the purchases 
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                string fullCompanyName = stocks[purchase.ticker];
                // Does the company name key already exist in the report dictionary?
                if (portfolio.ContainsKey(fullCompanyName)) {
                    // If it does, update the total valuation
                    portfolio[fullCompanyName] += purchase.shares * purchase.price;
                } else {
                    // If not, add the new key and set its value
                    portfolio[fullCompanyName] = purchase.shares * purchase.price;
                }
            }
            // loop through the portfolio

            foreach (KeyValuePair<string, double> stock in portfolio)
            {
                Console.WriteLine($"I own {stock.Key} stock for a total cost of {stock.Value.ToString("C")}");
            }
        }
    }
}
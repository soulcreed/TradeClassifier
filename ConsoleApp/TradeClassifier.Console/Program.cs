using Microsoft.Extensions.DependencyInjection;
using TradeClassifier.Application.Services;
using TradeClassifier.Domain.Entities;
using TradeClassifier.Domain.Interfaces;
using TradeClassifier.Domain.Services;

class Program
{
    static void Main()
    {
        var serviceProvider = ConfigureServices();
        var tradeService = serviceProvider.GetRequiredService<TradeService>();
        while (true)
        {
            DateTime referenceDate = ReadReferenceDate();
            int n = ReadNumberOfTrades();
            var trades = new List<Trade>();
            for (int i = 0; i < n; i++)
            {
                var tradeData = Console.ReadLine()?.Split(" ");

                if (tradeData == null || tradeData.Length != 3)
                {
                    Console.WriteLine("Invalid trade input. Please enter the trade with value, sector, and next payment date.");
                    i--;
                    continue;
                }

                if (!double.TryParse(tradeData[0], out double value))
                {
                    Console.WriteLine("Invalid value format. Please enter a valid number for the trade value.");
                    i--;
                    continue;
                }

                if (!DateTime.TryParseExact(tradeData[2], "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime nextPaymentDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in MM/dd/yyyy format.");
                    i--;
                    continue;
                }

                var trade = new Trade
                {
                    Value = value,
                    ClientSector = tradeData[1],
                    NextPaymentDate = nextPaymentDate
                };

                trades.Add(trade);
            }
            var results = new List<string?>();
            foreach (var trade in trades)
            {
                tradeService.CategorizeTrade(trade, referenceDate);
                results.Add(trade.Category);
            }

            foreach (var result in results)
                Console.WriteLine(result);

            Console.WriteLine("\nWould you like to process another set of trades? (y/n): ");
            var continueInput = Console.ReadLine()?.ToLower();
            if (continueInput != "y")
            {
                Console.WriteLine("Exiting application.");
                break;
            }
        }
    }

    private static DateTime ReadReferenceDate()
    {
        while (true)
        {
            Console.WriteLine("Enter the reference date (MM/dd/yyyy): ");
            string? input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime referenceDate))
            {
                return referenceDate;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }
    }

    private static int ReadNumberOfTrades()
    {
        while (true)
        {
            Console.WriteLine("Enter the number of trades: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int numberOfTrades) && numberOfTrades > 0)
                return numberOfTrades;
            else
                Console.WriteLine("Please enter a valid number greater than 0.");
        }
    }


    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ITradeCategoryStrategy, ExpiredCategoryStrategy>();
        services.AddSingleton<ITradeCategoryStrategy, HighRiskCategoryStrategy>();
        services.AddSingleton<ITradeCategoryStrategy, MediumRiskCategoryStrategy>();
        services.AddSingleton<TradeCategorizer>();
        services.AddSingleton<TradeService>();
        return services.BuildServiceProvider();
    }
}
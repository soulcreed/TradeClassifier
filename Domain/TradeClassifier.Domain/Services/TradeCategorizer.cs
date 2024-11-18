using TradeClassifier.Domain.Entities;
using TradeClassifier.Domain.Interfaces;

namespace TradeClassifier.Domain.Services;

public class TradeCategorizer(IEnumerable<ITradeCategoryStrategy> strategies)
{
    public string? CategorizeTrade(Trade trade, DateTime referenceDate)
    {
        foreach (var strategy in strategies)
        {
            var category = strategy.Categorize(trade, referenceDate);
            if (category != null) return category;
        }

        return "UNCATEGORIZED";
    }
}
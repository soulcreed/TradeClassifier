using TradeClassifier.Domain.Entities;
using TradeClassifier.Domain.Services;

namespace TradeClassifier.Application.Services;

public class TradeService(TradeCategorizer categorizer)
{
    public void CategorizeTrade(Trade trade, DateTime referenceDate)
    {
        trade.Category = categorizer.CategorizeTrade(trade, referenceDate);
    }
}
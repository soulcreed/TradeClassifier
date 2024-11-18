using TradeClassifier.Domain.Entities;
using TradeClassifier.Domain.Interfaces;

namespace TradeClassifier.Domain.Services;

public class HighRiskCategoryStrategy : ITradeCategoryStrategy
{
    public string? Categorize(Trade trade, DateTime referenceDate)
    {
        if (trade.Value > 1000000 && trade.ClientSector == "Private")
            return "HIGHRISK";

        return null;
    }
}
using TradeClassifier.Domain.Entities;
using TradeClassifier.Domain.Interfaces;

namespace TradeClassifier.Domain.Services;

public class ExpiredCategoryStrategy : ITradeCategoryStrategy
{
    public string? Categorize(Trade trade, DateTime referenceDate)
    {
        if ((referenceDate - trade.NextPaymentDate).TotalDays > 30)
            return "EXPIRED";

        return null;
    }
}
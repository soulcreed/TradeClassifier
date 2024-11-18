using TradeClassifier.Domain.Entities;

namespace TradeClassifier.Domain.Interfaces;

public interface ITradeCategoryStrategy
{
    string? Categorize(Trade trade, DateTime referenceDate);
}
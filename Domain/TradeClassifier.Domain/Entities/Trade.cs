using TradeClassifier.Domain.Interfaces;

namespace TradeClassifier.Domain.Entities;

public class Trade : ITrade
{
    public double Value { get; set; }
    public string? ClientSector { get; set; }
    public DateTime NextPaymentDate { get; set; }
    public string? Category { get; set; }
}
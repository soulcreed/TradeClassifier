namespace TradeClassifier.Domain.Entities;

public interface ITrade
{
    double Value { get; }
    string? ClientSector { get; }
    DateTime NextPaymentDate { get; }
    public string? Category { get; set; }
}
// Strategy-Interface
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}
-----
// Kreditkarten-Bezahlung
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Bezahle {amount} CHF mit Kreditkarte.");
    }
}

// PayPal-Bezahlung
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Bezahle {amount} CHF mit PayPal.");
    }
}

// Twint-Bezahlung
public class TwintPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Bezahle {amount} CHF mit Twint.");
    }
}
------
public class Checkout
{
    private IPaymentStrategy _paymentStrategy;

    // Setze die Strategie (Bezahlmethode)
    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    // Bezahlen
    public void Pay(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("Keine Zahlungsmethode ausgewählt!");
            return;
        }

        _paymentStrategy.Pay(amount);
    }
}

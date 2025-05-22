using System;

public class CheckoutPage
{
    private PaymentMethod payment;

    public void SetPaymentMethod(PaymentMethod payment)
    {
        this.payment = payment;
    }

    public void Checkout(double total)
    {
        Console.WriteLine("\nMemproses pembayaran...");
        payment.Pay(total);
    }
}

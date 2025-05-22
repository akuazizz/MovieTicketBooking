using System;

public class QRISPayment : PaymentMethod
{
    public void Pay(double amount)
    {
        Console.WriteLine($"[QRIS] Pembayaran Rp{amount} berhasil!");
    }
}

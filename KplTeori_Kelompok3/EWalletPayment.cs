using System;

public class EWalletPayment : PaymentMethod
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Pembayaran sebesar Rp{amount} berhasil dengan E-Wallet.");
    }
}

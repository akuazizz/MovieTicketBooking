using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var ticketManager = TicketManager.GetInstance();
        var checkout = new CheckoutPage();

        Console.WriteLine("=== Selamat Datang di Bioskop ===");
        Console.Write("Masukkan nama Anda: ");
        string nama = Console.ReadLine();

        ticketManager.ShowSchedule();
        Console.Write("Pilih film (1-3): ");
        int pilihanFilm = int.Parse(Console.ReadLine());

        string[] films = { "Avengers: Endgame", "Spider-Man: No Way Home", "Interstellar" };
        string filmDipilih = films[pilihanFilm - 1];

        Console.Write("Jumlah tiket: ");
        int jumlahTiket = int.Parse(Console.ReadLine());

        List<string> kursiDipilih = new List<string>();
        Console.WriteLine("Kursi Tersedia: " + string.Join(", ", ticketManager.GetAvailableSeats()));

        for (int i = 0; i < jumlahTiket; i++)
        {
            Console.Write($"Pilih kursi ke-{i + 1}: ");
            string seat = Console.ReadLine();
            if (ticketManager.BookSeat(seat))
            {
                kursiDipilih.Add(seat);
            }
            else
            {
                Console.WriteLine("Kursi tidak tersedia, pilih yang lain.");
                i--;
            }
        }

        Console.WriteLine("Metode Pembayaran:");
        Console.WriteLine("1. QRIS");
        Console.WriteLine("2. E-Wallet");
        Console.Write("Pilih (1/2): ");
        int metode = int.Parse(Console.ReadLine());

        PaymentMethod payment;
        if (metode == 1)
        {
            payment = new QRISPayment();
        }
        else
        {
            payment = new EWalletPayment();
        }
        checkout.SetPaymentMethod(payment);

        double hargaPerTiket = 50000;
        double totalBayar = jumlahTiket * hargaPerTiket;
        checkout.Checkout(totalBayar);

        Console.WriteLine($"\n=== Tiket Berhasil Dipesan ===");
        Console.WriteLine($"Nama: {nama}");
        Console.WriteLine($"Film: {filmDipilih}");
        Console.WriteLine($"Kursi: {string.Join(", ", kursiDipilih)}");
        Console.WriteLine($"Total Bayar: Rp{totalBayar}");
        Console.WriteLine("==============================");
    }
}

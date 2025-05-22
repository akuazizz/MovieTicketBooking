using System;
using System.Collections.Generic;

public class TicketManager
{
    private static TicketManager instance;
    private List<string> availableSeats;

    private TicketManager()
    {
        availableSeats = new List<string> { "A1", "A2", "A3", "B1", "B2", "B3" };
    }

    public static TicketManager GetInstance()
    {
        if (instance == null)
            instance = new TicketManager();
        return instance;
    }

    public void ShowSchedule()
    {
        Console.WriteLine("Daftar Film Hari Ini:");
        Console.WriteLine("1. Avengers: Endgame");
        Console.WriteLine("2. Spider-Man: No Way Home");
        Console.WriteLine("3. Interstellar");
    }

    public List<string> GetAvailableSeats()
    {
        return availableSeats;
    }

    public bool BookSeat(string seat)
    {
        if (availableSeats.Contains(seat))
        {
            availableSeats.Remove(seat);
            return true;
        }
        return false;
    }
}

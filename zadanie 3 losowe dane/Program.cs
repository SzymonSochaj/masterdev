using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        string[] imiona = { "Ania", "Kasia", "Basia", "Zosia" };
        string[] nazwiska = { "Kowalska", "Nowak" };
        int rokMin = 1990;
        int rokMax = 2000;

        string currentDateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
        string filename = $"users_{currentDateTime}.csv";
        string filePath = Path.Combine(Environment.CurrentDirectory, filename);

        List<string> lines = new List<string>();

        // Dodanie nagłówka
        string header = "LP,Imię,Nazwisko,Rok urodzenia";
        lines.Add(header);

        // Generowanie danych użytkowników
        for (int i = 1; i <= 100; i++)
        {
            string imie = GetRandomElement(imiona);
            string nazwisko = GetRandomElement(nazwiska);
            int rokUrodzenia = random.Next(rokMin, rokMax + 1);

            string line = $"{i},{imie},{nazwisko},{rokUrodzenia}";
            lines.Add(line);
        }

        // Zapisywanie danych do pliku CSV
        File.WriteAllLines("C:\\Users\\yclic\\Documents\\testowanie\\test.txt", lines, Encoding.UTF8);

        Console.WriteLine("Plik CSV został wygenerowany.");
    }

    static T GetRandomElement<T>(T[] array)
    {
        int index = random.Next(array.Length);
        return array[index];
    }
}

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = @"C:\test\test_szy_soc.txt";

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int count = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    count += CountOccurrences(line, 'a');
                }

                Console.WriteLine("Liczba wystąpień litery 'a': " + count);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Wystąpił błąd: " + e.Message);
        }

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
        Console.ReadKey(true);
    }

    static int CountOccurrences(string text, char target)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (c == target)
                count++;
        }
        return count;
    }
}
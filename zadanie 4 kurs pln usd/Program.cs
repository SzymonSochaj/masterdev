using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Pobieranie kursu wymiany waluty PLN na USD z publicznego API
        decimal exchangeRate = await GetExchangeRateAsync();

        // Pobieranie kwoty w walucie PLN od użytkownika
        Console.Write("Podaj kwotę w PLN: ");
        decimal plnAmount = decimal.Parse(Console.ReadLine());

        // Konwersja kwoty na walutę USD
        decimal usdAmount = plnAmount * exchangeRate;

        // Wyświetlanie wyniku na ekranie
        Console.WriteLine($"Kwota w USD: {usdAmount:N2}");

        Console.ReadKey();
    }

    static async Task<decimal> GetExchangeRateAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiUrl = "https://api.exchangerate-api.com/v4/latest/PLN";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ExchangeRateResponse>();
                    return result.Rates.USD;
                }
                else
                {
                    Console.WriteLine("Wystąpił błąd podczas pobierania kursu wymiany walut.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
        }

        return 0;
    }
}

public class ExchangeRateResponse
{
    public string Base { get; set; }
    public RateData Rates { get; set; }
}

public class RateData
{
    public decimal USD { get; set; }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Marketplace.Services 
{
    public class CurrencyService
    {
        private const string ApiUrl = "https://www.cbr-xml-daily.ru/daily_json.js";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<double> ConvertFromRub(double priceInRub, string targetCurrency)
        {
            if (targetCurrency == "RUB") return priceInRub;
            try
            {
                var response = await _httpClient.GetStringAsync(ApiUrl);

                using (var doc = JsonDocument.Parse(response))
                {
                    var valute = doc.RootElement.GetProperty("Valute");
                    var currencyData = valute.GetProperty(targetCurrency);

                    double rate = currencyData.GetProperty("Value").GetDouble();
                    int nominal = currencyData.GetProperty("Nominal").GetInt32();

                    return Math.Round(priceInRub / (rate / nominal), 2);
                }
            }
            catch { return priceInRub; }
        }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marketplace.Services
{
    public class TelegramService
    {
        private readonly string _token = "8528107266:AAFGgw9OrSrCIlxAcsSOn6EQpXX1HV4l-H4";
        private readonly string _chatId = "1919879714";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task SendNotification(string message)
        {
            try
            {
              
                string url = $"https://api.telegram.org/bot{_token}/sendMessage?chat_id={_chatId}&text={Uri.EscapeDataString(message)}";

                
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("В телегу прилетело уведомление!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка Телеграма: " + ex.Message);
            }
        }
    }
}
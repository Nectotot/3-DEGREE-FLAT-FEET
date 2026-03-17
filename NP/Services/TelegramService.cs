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
        public async Task SendOrderNotification(User customer, Product product, Order order, double priceUsd)
        {
            try
            {
                string message =
                    $"🚀 *НОВЫЙ ЗАКАЗ В MARKETPLACE*\n" +
                    $"━━━━━━━━━━━━━━━━━━━━\n" +
                    $"📦 *Товар:* {product.ProductName}\n" +
                    $"💰 *Сумма:* {order.Price} руб. (${priceUsd})\n" +
                    $"👤 *Покупатель:* {customer.Name}\n" +
                    $"📅 *Дата:* {order.EntryDate:dd.MM.yyyy HH:mm}\n" +
                    $"━━━━━━━━━━━━━━━━━━━━\n" +
                    $"✅ *Статус:* В пути.";
                string url = $"https://api.telegram.org/bot{_token}/sendMessage?chat_id={_chatId}&text={Uri.EscapeDataString(message)}&parse_mode=Markdown";
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("✅ Уведомление в Telegram отправлено!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Ошибка Телеграма: " + ex.Message);
            }
        }
    }
}
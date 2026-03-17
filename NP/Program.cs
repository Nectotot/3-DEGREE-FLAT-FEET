using System;
using System.Threading.Tasks;
using Marketplace.Services; 
class Program
{
    static async Task Main(string[] args)
    {
        var user = new User { Name = "Тест", Email = "market-project-2026@mail.ru" };// сюды имя получателя и почту
        var prod = new Product { ProductName = "Игровой ноутбук MSI" };
        var order = new Order { ID = 777, Price = 125000, EntryDate = DateTime.Now };

        // РАБОТА С ВАЛЮТАМИ
        var currency = new CurrencyService();
        double priceInUsd = await currency.ConvertFromRub(order.Price, "USD");
        double priceInKzt = await currency.ConvertFromRub(order.Price, "KZT");
        Console.WriteLine($"Конвертация завершена: {priceInUsd} USD / {priceInKzt} KZT");

        // ОТПРАВКА ЧЕКА НА EMAIL
        var notify = new NotificationService();
        notify.SendOrderConfirmation(user.Email, user, prod, order);
        Console.WriteLine(" Email-уведомление отправлено клиенту.");

        // ШАГ 3: ОТЧЕТ В TELEGRAM
        var telegram = new TelegramService();
        //  Передаем также цену в USD, которую получили ранее
        await telegram.SendOrderNotification(user, prod, order, priceInUsd);
        Console.WriteLine("Отчет в Telegram успешно доставлен.");
        Console.ReadKey();
    }
}
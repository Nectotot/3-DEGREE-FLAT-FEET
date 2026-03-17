using System;
using System.Net;
using System.Net.Mail;

namespace Marketplace.Services
{
    public class NotificationService
    {
        private const string SenderEmail = "market-project-2026@mail.ru";
        private const string SenderPassword = "SKOgNcj6rewJxO5rQ5TW";

        public void SendOrderConfirmation(string userEmail, User customer, Product product, Order order)
        {
            try
            {
                var fromAddress = new MailAddress(SenderEmail, "🚀 Marketplace Team");
                var toAddress = new MailAddress(userEmail, customer.Name);

                using (MailMessage message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = $"✨ Ваш заказ #{order.ID} подтвержден!";
                    message.IsBodyHtml = false;
                    message.Body =
                        $"Привет, {customer.Name}! 👋\n\n" +
                        $"==========================================\n" +
                        $"🎉 РАДОСТНАЯ НОВОСТЬ!\n" +
                        $"Ваш заказ успешно оформлен и уже в пути.\n" +
                        $"==========================================\n\n" +
                        $"📦 ЧТО ВНУТРИ:\n" +
                        $"------------------------------------------\n" +
                        $"🔹 Товар: {product.ProductName}\n" +
                        $"🔹 Цена:  {order.Price} руб.\n" +
                        $"🔹 Дата:  {order.EntryDate:dd.MM.yyyy HH:mm}\n" +
                        $"------------------------------------------\n\n" +
                        $"🔥 Спасибо, что выбираете нас!\n" +
                        $"Если возникнут вопросы, просто ответьте на это письмо.\n\n" +
                        $"✌️ С уважением,3 DEGREE FLAT FEET\n";

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.mail.ru";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                        smtp.Send(message);
                    }
                }
                Console.WriteLine("Письмо успешно отправлено на " + userEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка отправки: " + ex.Message);
            }
        }
    }
}
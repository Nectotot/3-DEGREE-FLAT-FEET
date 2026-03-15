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
                var fromAddress = new MailAddress(SenderEmail, "Marketplace Team");
                var toAddress = new MailAddress(userEmail, customer.Name);
                using (MailMessage message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = "Подтверждение заказа #" + order.ID;
                    message.Body = "Привет, " + customer.Name + "!\n\n" +
                                   "Вы купили: " + product.ProductName + "\n" +
                                   "Цена: " + order.Price + " руб.\n\n" +
                                   "Спасибо за покупку!";
                    message.IsBodyHtml = false;
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
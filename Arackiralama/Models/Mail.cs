using Arackiralama.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Arackiralama.Models
{
    public class Mail
    {
        public static void MailSender()
        {

            var fromAddress = new MailAddress("alper.yazir@demircode.com");
            var toAddress = new MailAddress("blgsyrmhnds@gmail.com");
            const string subject = "AracvarArav - Şifremi Unuttum";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, "Demircode1923")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = "test" })
                {
                    smtp.Send(message);
                }
            }
        }
        public static void MailSender(string username, Accounts password)
        {
            string toAdress = password.Email;
            var fromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["mailMessageFrom"]);
            var toAddress = new MailAddress(toAdress);
            const string subject = "AracvarArav - Şifremi Unuttum";
            using (var smtp = new SmtpClient
            {
                Host = System.Configuration.ConfigurationManager.AppSettings["mailMessageHost"],

                Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["mailMessagePort"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,

                Credentials = new System.Net.NetworkCredential(fromAddress.Address, System.Configuration.ConfigurationManager.AppSettings["mailMessagePassword"])
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = password.Password })
                {
                    smtp.Send(message);
                }
            }
        }



        public static int SendMail(string FromMail, string head, string body)
        {

            string mail = System.Configuration.ConfigurationManager.AppSettings["mailMessageFrom"];
            string host = System.Configuration.ConfigurationManager.AppSettings["mailMessageHost"];
            string port = System.Configuration.ConfigurationManager.AppSettings["mailMessagePort"];
            string password = System.Configuration.ConfigurationManager.AppSettings["mailMessagePassword"];

            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(mail);
                message.To.Add(FromMail);
                message.Subject = head;
                message.IsBodyHtml = true;
                message.Body = body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Host = host;
                smtpClient.Port = Convert.ToInt32(port);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(mail, password);


                smtpClient.Send(message);

                return 1;
            }
            catch (Exception ex)
            {
               
                return 0;
            }


        }

        public static void MailSender(string body, User user)
        {




            var fromAddress = new MailAddress("alper.yazir@demircode.com");
            var toAddress = new MailAddress("blgsyrmhnds@gmail.com");
            const string subject = "AracvarArav - Şifremi Unuttum";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,

                Credentials = new System.Net.NetworkCredential(fromAddress.Address, System.Configuration.ConfigurationManager.AppSettings["mailMessagePassword"])
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = "test" })
                {
                    smtp.Send(message);
                }
            }





        }
    }

}
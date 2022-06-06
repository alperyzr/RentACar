using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;


namespace Arackiralama.Models.Helpers
{
    public class MessageSender
    {
        public bool SendMail(string path,string userName, string password, string smtp, int port, string to, Dictionary<string, string> replacements, string subject)
        {
            string body=string.Empty;
            var mailMessage = new MailMessage(); // mail adında MailMessage nesnesi yaratıyoruz.
            mailMessage.From = new MailAddress(userName); //Mailin kimden gittiğini belirtiyoruz
            mailMessage.To.Add(to); //Mailin kime gideceğini belirtiyoruz
            mailMessage.Subject = subject; //Mail konusu 

            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(path, System.Text.Encoding.GetEncoding("windows-1254")))
            {
                body = streamReader.ReadToEnd();
            }
            foreach (var key in replacements)
            {
                body = body.Replace(key.Key, key.Value);
            }

            mailMessage.Body = body;

            mailMessage.IsBodyHtml = true;
            //if (attachmentCollection != null)
            //{
            //    foreach (var attachment in attachmentCollection)
            //    {
            //        mailMessage.Attachments.Add(attachment);
            //    }
            //}
            try
            {


                var sc = new SmtpClient(); //sc adında SmtpClient nesnesi yaratıyoruz.
                sc.Port = port; //Gmail için geçerli Portu bildiriyoruz
                sc.Host = smtp; //Gmailin smtp host adresini belirttik
                sc.EnableSsl = true; //SSL’i etkinleştirdik.
                sc.Credentials = new NetworkCredential(userName, password); //Gmail hesap kontrolü için bilgilerimizi girdik

                sc.Send(mailMessage); //Mailinizi gönderiyoruz.
            }
            catch (Exception ex)
            {

                //throw;
            }
            return true;
        }
    }
}
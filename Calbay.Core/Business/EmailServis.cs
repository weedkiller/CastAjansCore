using Calbay.Core.Entities;
using Calbay.Core.Helper;
//using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
//using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Calbay.Core.Business
{
    public class EmailServis : IEmailServis
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _env;

        public EmailServis(
            IOptions<EmailSettings> emailSettings,
            IHostingEnvironment env)
        {
            _emailSettings = emailSettings.Value;
            _env = env;            
        }

        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    try
        //    {
        //        var mimeMessage = new MimeMessage();

        //        mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));

        //        mimeMessage.To.Add(new MailboxAddress(email));

        //        mimeMessage.Subject = subject;

        //        mimeMessage.Body = new TextPart("html")
        //        {
        //            Text = message
        //        };

        //        using (var client = new SmtpClient())
        //        {
        //            // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
        //            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

        //            //if (_env.IsDevelopment())
        //            //{
        //            // The third parameter is useSSL (true if the client should make an SSL-wrapped
        //            // connection to the server; otherwise, false).
        //            await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, _emailSettings.UseSLL.ToBool(false));
        //            //}
        //            //else
        //            //{
        //            //    await client.ConnectAsync(_emailSettings.MailServer);
        //            //}

        //            // Note: only needed if the SMTP server requires authentication
        //            await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);

        //            await client.SendAsync(mimeMessage);

        //            await client.DisconnectAsync(true);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // TODO: handle exception
        //        throw new InvalidOperationException(ex.Message);
        //    }
        //}

        public bool SendEmail(string To, string subject, string message, string Cc = "", List<KeyValuePair<string, Stream>> eklentiler = null)
        {
            if (To.IsNull())
                return false;

            string[] gidenliste = Listele(To);
            if (gidenliste.Length < 1)
                return false;

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName)
            };

            for (int i = 0; i < gidenliste.Length; i++)
            {
                if (!gidenliste[i].IsNull())
                {
                    mailMessage.To.Add(gidenliste[i]);
                }
            }

            string[] ccliste = Listele(Cc);
            for (int i = 0; i < ccliste.Length; i++)
            {
                if (!ccliste[i].IsNull())
                {
                    mailMessage.CC.Add(ccliste[i]);
                }
            }

            if (eklentiler.IsNotNull())
            {
                foreach (var item in eklentiler)
                {
                    if (item.Key.IsNotNull() && item.Value.IsNotNull())
                    {
                        mailMessage.Attachments.Add(new Attachment(item.Value, item.Key, MediaTypeNames.Application.Octet));
                    }
                    else if (item.Key.IsNotNull())
                    {
                        mailMessage.Attachments.Add(new Attachment(item.Key));
                    }
                }
            }

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;


            SmtpClient smtp = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort);
            if (!_emailSettings.Sender.Equals(""))
                smtp.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
            else
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;

            smtp.EnableSsl = _emailSettings.UseSLL.ToBool(false);
            try
            {
                smtp.Send(mailMessage);
            }
            //catch (SmtpException ex)
            //{
            //    return false;
            //}
            catch/* (Exception ex)*/
            {   
                return false;
            }

            return true;
        }

        private static string[] Listele(string str)
        {
            string[] liste = str.Split(',', ';', ' ');
            return liste;
        }
    }

}

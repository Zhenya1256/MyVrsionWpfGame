using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.AddColorText.Abstarct;
using WpfGame.AddColorText.Implement;
using WpfGame.OpenArchive;
using WpfGame.OpenArchive.Implement;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;
using System.Net;
using System.Net.Mail;


namespace ConsoleApplication
{
    //|| (i > j && i < size / 2)
    class Program
    {
        // private static string _location = @"E:\game2.rar";

        static void Main(string[] args)
        {
            string com = "redbull161crew@gmail.com";
            EmailSendService email = new EmailSendService();
            Result res = SendMail("smtp.gmail.com","vovchok.zhenya@gmail.com",
                "zxcqwe123", com,"Thems","Messages");
            
            Console.WriteLine(res.Success);
            Console.WriteLine(res.ErrorMessage);
            Console.WriteLine(res.ErrorCode);
    //        Пример вызова C# mail send (пробел перед именами ящиков убрать):
    //SendMail("smtp.gmail.com", "mymail@gmail.com",
    //"myPassword", "yourmail@gmail.com", 
    //"Тема письма", "Тело письма", "C:\\1.txt");
            Console.ReadKey();
        }

        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="smtpServer">Имя SMTP-сервера</param>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static Result SendMail(string smtpServer, string from, string password,
        string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
                return new Result()
                {
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new Result()
                {
                    ErrorCode = 400,
                    ErrorMessage = e.Message,
                    Success = false
                };
            }
            return new Result()
            {
                ErrorCode = 500,
                ErrorMessage = "1234",
                Success = false
            };
        }


    }
    public class EmailSendService 
    {
        private string _userName= "vovchock.vgen@yandex.ua";
        private string _password= "vvoovvcchhookk161198";
        private string _mailFrom= "vovchock.vgen@yandex.ua";
        public static readonly string MESSAGE_SEND_ERROR = "Message_entity_not_valid";

        public EmailSendService()
        {
            _userName = ConfigurationSettings.AppSettings["SmtpUserName"];
            _password = ConfigurationSettings.AppSettings["SmtpUserPassword"];
            _mailFrom = ConfigurationSettings.AppSettings["SmtpEmailFrom"];
        }

        public Result SendMessage(IEmailEntity message)
        {
            if (message.IsModelValid())
            {
                try
                {
                    NetworkCredential loginInfo = new NetworkCredential(_userName, _password);
                    MailAddress From = new MailAddress(_mailFrom, "PracticU");
                    MailMessage mailObj =
                        new MailMessage(_mailFrom, message.Email,
                        message.Subject, message.ToString());

                    mailObj.IsBodyHtml = true;
                    mailObj.BodyEncoding = System.Text.Encoding.UTF8;
                    mailObj.SubjectEncoding = System.Text.Encoding.UTF8;
                    mailObj.From = From;

                    if (message.AttachmentsFilePath != null && 
                        message.AttachmentsFilePath.Length > 0)
                    {
                        foreach (string pathToFile in message.AttachmentsFilePath)
                        {
                            mailObj.Attachments.Add(new Attachment(pathToFile));
                        }
                    }

                    SmtpClient smtpClient = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = loginInfo
                    };


                    smtpClient.Send(mailObj);
                    return new Result()
                    {
                        Success = true
                    };
                }
                catch (Exception e)
                {
                    return new Result()
                    {
                        ErrorCode = 500,
                        ErrorMessage = e.Message,
                        Success = false
                    };
                }
            }
            return new Result()
            {
                ErrorCode = 422,
                FromCaptions = true,
                Success = false,
                ErrorMessage = MESSAGE_SEND_ERROR
            };
        }

        public Result Send()
        {
            string name = "vovchock.vgen@yandex.ua";
            SmtpClient Smtp = new SmtpClient("smtp.yandex.com", 25);
            Smtp.Credentials = new NetworkCredential(name, "vvoovvcchhookk161198");
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(name);
            Message.To.Add(new MailAddress(name));
            Message.Subject = "тема";
            Message.Body = "сообщение";

            try
            {
                Smtp.Send(Message);
                return new Result()
                {
                    Success = true
                };
            }
            catch (SmtpException e)
            {
                return new Result()
                {
                    ErrorCode = 500,
                    ErrorMessage = e.Message,
                    Success = false
                };
            }

            return new Result()
            {
                ErrorCode = 422,
                FromCaptions = true,
                Success = false,
                ErrorMessage = MESSAGE_SEND_ERROR
            };
        }


    }
    public interface IEmailEntity
    {
        bool IsModelValid();
        string Email { get; set; }
        string Subject { get; set; }
        string [] AttachmentsFilePath { get; set; }

    }



    public class Result
    {
      public  bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool FromCaptions { get; set; }
    }


    public interface IVarificationService<IEmailEntity>
    {
    }



    }

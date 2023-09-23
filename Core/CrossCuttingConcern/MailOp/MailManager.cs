using Core.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.MailOp
{
    public class MailManager
    {
        public static bool Send(string to,string title,string message)
        {
            MailMessage msg = new MailMessage(CoreKeys.EMAILADDRESS, to);
            msg.Subject = title;
            msg.Body = message;
            msg.IsBodyHtml = true; //body de html kullanılacak mı kullanılmayacak mı true yazarsak mesajda html kodları da kullanılanbiliyor.
            //msg.Attachments mail kod ile dosya ekleyebiliyoruz. msg.Attachments(new Attachment("c:\\file.zip"));

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(CoreKeys.EMAILUSER, CoreKeys.EMAILPASSWORD);
            smtp.Host = "smtp-mail.outlook.com"; //ahmetpekacar.com //mail.gmail.com //smtp mail alma servisi
            smtp.Port = 587;

            smtp.EnableSsl= true; //Bu değer şirket mailleri için false olarak işaretlenmesi gerekiyor. 
            smtp.Send(msg);

            return true;
        }
        
    }
}

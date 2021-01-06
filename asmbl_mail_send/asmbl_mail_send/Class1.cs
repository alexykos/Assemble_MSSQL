using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public static class asmbl_mail_send
{
    [SqlFunction(IsDeterministic = true)]
    /**/
    public static SqlString Is_Mail_send(SqlString lMailAddress, SqlString lComment, SqlString lSMTP, SqlInt16 lPort, SqlString lLogin, SqlString lPassword, SqlString lSubject, SqlString lBody, SqlBoolean lEnableSsl)
    {

        
        try
        {

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(lLogin.ToString(), lComment.ToString());
            // кому отправляем
            MailAddress to = new MailAddress(lMailAddress.ToString());
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = lSubject.ToString();
            // текст письма
            m.Body = lBody.ToString();
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(lSMTP.ToString(), Int16.Parse(lPort.ToString()));
            // логин и пароль
            smtp.Credentials = new NetworkCredential(lLogin.ToString(), lPassword.ToString());
            smtp.EnableSsl = bool.Parse(lEnableSsl.ToString());
            smtp.Send(m);

            return "1";
        }
        catch (Exception ex)
        {
            return ex.Message;

        }
    }




    /* async*/

    public static SqlString Is_Mail_send_asunc(SqlString lMailAddress, SqlString lComment, SqlString lSMTP, SqlInt16 lPort, SqlString lLogin, SqlString lPassword, SqlString lSubject, SqlString lBody, SqlBoolean lEnableSsl)
    {


        try
        {
            Mail_send_asunc(lMailAddress.ToString(), lComment.ToString(), lSMTP.ToString(), Int16.Parse(lPort.ToString()), lLogin.ToString(), lPassword.ToString(), lSubject.ToString(), lBody.ToString(), bool.Parse(lEnableSsl.ToString()));
            return "1";
        }
        catch (Exception ex)
        {
            return ex.Message;

        }
    }


    public static async Task Mail_send_asunc(string lMailAddress, string lComment, string lSMTP, int lPort, string lLogin, string lPassword, string lSubject, string lBody, bool lEnableSsl)
    {

        // отправитель - устанавливаем адрес и отображаемое в письме имя
        MailAddress from = new MailAddress(lLogin, lComment);
        // кому отправляем
        MailAddress to = new MailAddress(lMailAddress);
        // создаем объект сообщения
        MailMessage m = new MailMessage(from, to);
        // тема письма
        m.Subject = lSubject;
        // текст письма
        m.Body = lBody;
        // письмо представляет код html
        m.IsBodyHtml = true;
        // адрес smtp-сервера и порт, с которого будем отправлять письмо
        SmtpClient smtp = new SmtpClient(lSMTP, lPort);
        // логин и пароль
        smtp.Credentials = new NetworkCredential(lLogin, lPassword);
        smtp.EnableSsl = lEnableSsl;
        await smtp.SendMailAsync(m);

    }


    /*
         public static async Task Is_Mail_send_asunc(SqlString lMailAddress, SqlString lComment, SqlString lSMTP, SqlInt16 lPort, SqlString lLogin, SqlString lPassword, SqlString lSubject, SqlString lBody, SqlBoolean lEnableSsl)
    {


       

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(lLogin.ToString(), lComment.ToString());
            // кому отправляем
            MailAddress to = new MailAddress(lMailAddress.ToString());
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = lSubject.ToString();
            // текст письма
            m.Body = lBody.ToString();
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(lSMTP.ToString(), Int16.Parse(lPort.ToString()));
            // логин и пароль
            smtp.Credentials = new NetworkCredential(lLogin.ToString(), lPassword.ToString());
            smtp.EnableSsl = bool.Parse(lEnableSsl.ToString());
        await smtp.SendMailAsync(m);
    }

     
     */

}

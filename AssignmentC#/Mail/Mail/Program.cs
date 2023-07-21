using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

class Program
{
    public static string GetPath(string keyname)
    {
        string value;
        value = ConfigurationManager.AppSettings.Get(keyname);

        return value;
    }
    static void Main(string[] args)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(GetPath("mailfrom"));
        mailMessage.To.Add(GetPath("mailto"));
        mailMessage.Subject = "Subject";
        mailMessage.IsBodyHtml = true;
        //mailMessage.Body = "This is test email";
        mailMessage.Body = "<h1 style='color: red;font-variant:small-caps'>Welcome Aboard!</h1>";
        Attachment attachment = new Attachment(GetPath("attachment"));
        mailMessage.Attachments.Add(attachment);

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = GetPath("host");
        smtpClient.Port = Int32.Parse(GetPath("port"));
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(GetPath("username"), GetPath("password"));
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
            Console.WriteLine("Email Sent Successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        Console.ReadKey();
    }
}
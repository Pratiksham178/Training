using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("liti624@gmail.com");
        mailMessage.To.Add("mfsi.pratiksham@gmail.com");
        mailMessage.Subject = "Subject";
        mailMessage.IsBodyHtml = true;
        //mailMessage.Body = "This is test email";
        mailMessage.Body = "<h1 style='color: red;font-variant:small-caps'>Welcome Abode</h1>";
        Attachment attachment = new Attachment("D:\\Projects\\Assignments\\AssignmentC#\\Logs\\19-07-2023.txt");
        mailMessage.Attachments.Add(attachment);

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "sandbox.smtp.mailtrap.io";
        smtpClient.Port = 2525;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("e3232103225356", "7b2c68df49aaa3");
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
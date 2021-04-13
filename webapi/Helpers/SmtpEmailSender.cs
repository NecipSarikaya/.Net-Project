using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace webapi.Helpers
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSL ;
        private string _username;
        private string _password;
        public SmtpEmailSender(string host,int port,bool enableSSL,string username,string password)
        {
            this._host = host;
            this._enableSSL = enableSSL;
            this._password = password;
            this._port = port;
            this._username = username;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host,_port)
            {
                Credentials = new NetworkCredential(this._username,this._password),
                EnableSsl = this._enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(this._username,email,subject,htmlMessage){
                    IsBodyHtml = true
                }
            );
        }
    }
}
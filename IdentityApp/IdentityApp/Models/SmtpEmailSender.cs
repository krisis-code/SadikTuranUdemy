namespace IdentityApp.Models
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _host;

        private int _port;

        private bool enableSSL;

        private string _username;

        private string _password;

        public SmtpEmailSender(string host , int port,)
        {
            
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}

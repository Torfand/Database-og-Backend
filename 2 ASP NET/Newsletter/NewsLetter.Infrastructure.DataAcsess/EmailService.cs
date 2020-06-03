using System;
using System.IO;
using System.Threading.Tasks;
using NewsLetter.Core._2_Domain_Services;
using NewsLetter.Core._3_Domain_Model;

namespace NewsLetter.Infrastructure.DataAcsess
{
    public class EmailService : IEmailService
    {
        public  Task<bool> Send(Email email)
        {
            string[] lines = {email.To, email.From, email.Subject, email.Content};

            File.WriteAllLines(@"C:\Users\Rizil\Desktop\New folder\a.txt", lines);
            return Task.FromResult(true);
        }
    }
}

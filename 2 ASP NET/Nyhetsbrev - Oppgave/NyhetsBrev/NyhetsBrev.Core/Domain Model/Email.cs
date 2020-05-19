using System;
using System.Collections.Generic;
using System.Text;

namespace NyhetsBrev.Core.Domain_Model
{
    public class Email
    {
        public string ToAdress { get; set; }
        public string FromAdress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Email(string toAdress, string fromAdress, string subject, string content)
        {
            ToAdress = toAdress;
            FromAdress = fromAdress;
            Subject = subject;
            Content = content;
        }

        public Email()
        {
            
        }
    }
    
}

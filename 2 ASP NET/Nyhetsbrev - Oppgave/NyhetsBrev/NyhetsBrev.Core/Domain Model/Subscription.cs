using System;
using System.Collections.Generic;
using System.Text;

namespace NyhetsBrev.Core.Domain_Model
{
    public class Subscription : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }

        public Subscription()
        {
            
        }

        public Subscription(string name, string email, string verificationCode = null)
        {
            Name = name;
            Email = email;
            VerificationCode = verificationCode ?? new Guid().ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLetter.Core._3_Domain_Model
{
    public class Subscription
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
      
        public Subscription()
        {
            
        }

        public Subscription(string name, string email, string code = null)
        {
            Name = name;
            Email = email;
            Code = code ?? new Guid().ToString();
           
        }
        
    }
}

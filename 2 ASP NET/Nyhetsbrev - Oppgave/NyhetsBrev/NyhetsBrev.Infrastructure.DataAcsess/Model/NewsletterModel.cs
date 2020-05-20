using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NyhetsBrev.Infrastructure.DataAcsess.Model
{
    class NewsletterModel
    {
        public Guid Id;
        public string Name;
        public string Email;
        public string Code;

        public NewsletterModel()
        {
            
        }

        public NewsletterModel(Guid id, string name, string email, string code)
        {
            Id = id;
            Name = name;
            Email = email;
            Code = code;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NyhetsBrev.Infrastructure.DataAcsess.Model
{
    class NewsletterModel
    {
        public string Name;
        private Guid Id;
        public string Email { get; set; }
        public string Code { get; set; }

        public NewsletterModel()
        {
            
        }

        public NewsletterModel(string name, Guid id, string email, string code)
        {
            Name = name;
            Id = id;
            Email = email;
            Code = code;
        }
    }
}

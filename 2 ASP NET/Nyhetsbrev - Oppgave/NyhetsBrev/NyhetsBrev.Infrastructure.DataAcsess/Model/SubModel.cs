using System;
using System.Collections.Generic;
using System.Text;

namespace NyhetsBrev.Infrastructure.DataAcsess.Model
{
    class SubModel
    {
        public string Email { get; set; }
        public Guid Code { get; set; }

        public SubModel()
        {
            
        }

        public SubModel(string email, Guid code)
        {
            Email = email;
            Code = code;
        }
    }
}

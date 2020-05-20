using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NyhetsBrev.Core.Domain_Model;
using NyhetsBrev.Core.Domain_Services;

namespace NyhetsBrev.Infrastructure.DataAcsess
{
   public class EmailService : IEmailService
    {
        public async Task<bool> Send(Email email)
        {
            
            return await Task.FromResult(true);
        }
    }
}

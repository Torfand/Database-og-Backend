using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NyhetsBrev.Core.Domain_Model;

namespace NyhetsBrev.Core.Domain_Services
{
  public  interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}

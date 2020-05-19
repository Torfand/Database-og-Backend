using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NyhetsBrev.Core.Domain_Model;

namespace NyhetsBrev.Core.Domain_Services
{
    public interface ISubscriptionRepository
    {
        Task<bool> Create(Subscription subscription);
        Task<Subscription> ReadByEmail(string Email);
        Task<bool> Update(Subscription subscription);
    }
}

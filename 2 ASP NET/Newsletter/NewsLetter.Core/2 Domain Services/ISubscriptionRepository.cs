using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsLetter.Core._3_Domain_Model;

namespace NewsLetter.Core._2_Domain_Services
{
    public interface ISubscriptionRepository
    {
        Task<bool> Create(Subscription subscription);
        Task<Subscription> ReadByEmail(string email);
        Task<bool> Update(Subscription subscription);
    }
}

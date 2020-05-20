using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NyhetsBrev.Core.Domain_Model;
using NyhetsBrev.Core.Domain_Services;

namespace NyhetsBrev.Core.Application_Services
{
   public class SubscriptionService
    {
        private readonly IEmailService _mailService;
        private readonly ISubscriptionRepository _subRepo;

        public SubscriptionService(
            IEmailService mailService, 
            ISubscriptionRepository subRepo)
        {
            _subRepo = subRepo;
            _mailService = mailService;
        }

        public async Task<bool> Subscribe(Subscription subRequest)
        {
            var subscription =  new Subscription(subRequest.Name, subRequest.Email);
            
            await _subRepo.Create(subscription);
            var mailContent
                = $"<a href=\"https://localhost:5001/subscription?email={subRequest.Email}&vcode={subscription.VerificationCode}\">Click here to confirm</a>";
            var email = new Email(
                subRequest.Email,
                "Nåkandulurenå@tullepost.haha",
                "Verification",
                mailContent);
           var isSendt =  await _mailService.Send(email);
           if (!isSendt) return false;
           return true;
        }

        public async Task<bool> Verify(Subscription verificationRequest)
        {
            var subscription = await _subRepo.ReadByEmail(verificationRequest.Email);
            if (verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }

            var hasUpdated = await _subRepo.Update(subscription);
            if (!hasUpdated) return false;
            
            return true;

        }
    }
}

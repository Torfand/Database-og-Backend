using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsLetter.Core._2_Domain_Services;
using NewsLetter.Core._3_Domain_Model;

namespace NewsLetter.Core._1_Application_Services
{
    public class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(IEmailService emailService, ISubscriptionRepository subscriptionRepository)
        {
            _emailService = emailService;
            _subscriptionRepository = subscriptionRepository;
        }



        public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name, request.Email, request.Code);
            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var url = $"https://localhost:44340/index.html?email={request.Email}&code={subscription.Code}";
            var text = $"Hello {request.Name}! <a href =\"{url}\">Click here to Confirm Subscription to Newsletter</a>";
            var email = new Email(
                "To :" + request.Email,
                "From : Newsletter@test.test",
                "Subject :  Confirm Subscription to newsletter",
                text

                );
            var isSendt = await _emailService.Send(email);
            if (!isSendt) return false;
            return true;



        }

        public async Task<bool> Verify(Subscription verificationRequest)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (verificationRequest.Code != subscription.Code)
            {
                return false;
            }

            var hasUpdated = await _subscriptionRepository.Update(subscription);
            if (!hasUpdated) return false;
            return true;

        }
    }
}

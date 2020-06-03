using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsLetter.Core._1_Application_Services;
using NewsLetter.Core._3_Domain_Model;

namespace NewsLetter.Infrastructure.Api.Controllers
{
    [Route("api/verify")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public VerificationController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [HttpPut]
        public async Task<bool> Verify(Verification verificationRequest)
        {
            var request = new Subscription { Email = verificationRequest.Email, Code = verificationRequest.Code };
            return await _subscriptionService.Verify(request);
        }

    
    }
}

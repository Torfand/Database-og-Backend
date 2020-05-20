using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NyhetsBrev.Core.Application_Services;
using NyhetsBrev.Core.Domain_Model;

namespace NyhetsBrev.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private SubscriptionService _subscriptionService;

        public SubscribeController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(string email)
        {
            var subscription = new Subscription {Email = email};
            return await _subscriptionService.Subscribe(subscription);
        }

    }
}

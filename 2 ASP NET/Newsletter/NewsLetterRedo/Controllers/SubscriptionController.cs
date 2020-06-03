using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;
using NewsLetter.Core._1_Application_Services;
using NewsLetter.Core._3_Domain_Model;
using NewsLetter.Infrastructure.DataAcsess;

namespace NewsLetter.Infrastructure.Api.Controllers
{
    [Route("api/subscribe")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;


        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [HttpPost]
        
        public async Task<bool> Subscribe(Person person)
        {
            var code = new BaseEntity(new Guid());
            var subscription = new Subscription { Name = person.Name, Email = person.Email, Code = code.Id.ToString()};
            return await _subscriptionService.Subscribe(subscription);
        }

        

      
   


    }
}

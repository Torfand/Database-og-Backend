using System;
using System.Threading.Tasks;
using Moq;
using NuGet.Frameworks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NyhetsBrev.Core.Application_Services;
using NyhetsBrev.Core.Domain_Model;
using NyhetsBrev.Core.Domain_Services;

namespace NyhetsBrev.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestSubscriptionOK()
        {

            //lager mock servicer
            var mailservice = new Mock<IEmailService>();
            var subrepo = new Mock<ISubscriptionRepository>();
            //setter opp mock servicer
            mailservice.Setup(ms => ms.Send(It.IsAny<Email>())).ReturnsAsync(true);
            subrepo.Setup(sr => sr.Create(It.IsAny<Subscription>())).ReturnsAsync(true);

            var service = new SubscriptionService(mailservice.Object, subrepo.Object);
            //
            var MockSubscription = new Subscription("Torfin", "tester@test.no");

            var subcriptionSucsessfull = await service.Subscribe(MockSubscription);

            //
            // verifiserer at det stemmer overens med det vi har satt ovenfor
            Assert.IsTrue(subcriptionSucsessfull);

            mailservice.Verify(ms => ms.Send(It.Is<Email>(m => m.ToAdress == "tester@test.no")));

            subrepo.Verify(sr => sr.Create(It.Is<Subscription>(s => s.Email == "tester@test.no" && s.Name == "Torfin")));
            mailservice.VerifyNoOtherCalls();
            subrepo.VerifyNoOtherCalls();


        }
        [Test]
        public async Task TestSubscriptiondbFailure()
        {
            var mailservice = new Mock<IEmailService>();
            var subrepo = new Mock<ISubscriptionRepository>();
            subrepo.Setup(sr => sr.Create(It.IsAny<Subscription>())).ReturnsAsync(false);
            var service = new SubscriptionService(mailservice.Object, subrepo.Object);
            var subscription = new Subscription("Torfin", "test@test.no");
            var isFailure = await service.Subscribe(subscription);
            Assert.IsFalse(isFailure);


            subrepo.Verify(sr => sr.Create(It.Is<Subscription>(s => s.Email == "test@test.no")));
            subrepo.VerifyNoOtherCalls();
        }
        [Test]
        public async Task TestSubEmailFail()
        {
            var mailservice = new Mock<IEmailService>();
            var subrepo = new Mock<ISubscriptionRepository>();
            mailservice.Setup(ms => ms.Send(It.IsAny<Email>())).ReturnsAsync(false);
            subrepo.Setup(sr => sr.Create(It.IsAny<Subscription>())).ReturnsAsync(true);
            var service = new SubscriptionService(mailservice.Object, subrepo.Object);
            var subscription = new Subscription("Torfin", "test@test.no");
            var Sucsess = await service.Subscribe(subscription);
            Assert.IsFalse(Sucsess);
            mailservice.Verify(ms => ms.Send(It.Is<Email>(e => e.ToAdress == "test@test.no")));
            subrepo.Verify(sr => sr.Create(It.Is<Subscription>(s => s.Email == "test@test.no")));
            mailservice.VerifyNoOtherCalls();
            subrepo.VerifyNoOtherCalls();

        }
        [Test]
        public async Task TestVerificationOK()
        {
            var verificationCode = "0a70862f-d4f9-436b-9a46-4ed1c990f7c5";
            var email = "test@test.no";
            var verificationRequest = new Subscription(null, email, verificationCode);
            var subFromDB = new Subscription(null, null, verificationCode);
            var subrepo = new Mock<ISubscriptionRepository>();
            subrepo.Setup(sr => sr.ReadByEmail(email)).ReturnsAsync(subFromDB);
            subrepo.Setup(sr => sr.Update(It.IsAny<Subscription>())).ReturnsAsync(true);
            var service = new SubscriptionService(null, subrepo.Object);
            var sucsess = await service.Verify(verificationRequest);
            Assert.IsTrue(sucsess);
            subrepo.Verify(sr => sr.Update(It.IsAny<Subscription>()));


        }
        [Test]
        public async Task TestVerificationFailed()
        {
            var verificationCode = "0a70862f-d4f9-436b-9a46-4ed1c990f7c5";
            var code2 = "0a70862f-d4f9-436b-9a46-4ed1c990f7c8";
            var email = "test@test.no";
            var verificationRequest = new Subscription(null, email, verificationCode);
            var subFromDB = new Subscription(null, null, code2);
            var subrepo = new Mock<ISubscriptionRepository>();
            subrepo.Setup(sr => sr.ReadByEmail(email)).ReturnsAsync(subFromDB);
            
            var service = new SubscriptionService(null, subrepo.Object);
            var sucsess = await service.Verify(verificationRequest);
            Assert.IsFalse(sucsess);
            subrepo.Verify(sr => sr.ReadByEmail(email));
            subrepo.VerifyNoOtherCalls();


        }

    }
}
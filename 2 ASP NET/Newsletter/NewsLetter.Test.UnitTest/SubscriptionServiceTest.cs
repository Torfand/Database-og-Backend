using System.Threading.Tasks;
using Moq;
using NewsLetter.Core._1_Application_Services;
using NewsLetter.Core._2_Domain_Services;
using NewsLetter.Core._3_Domain_Model;
using NUnit.Framework;

namespace NewsLetter.Test.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestSubOk()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>())).ReturnsAsync(true);
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>())).ReturnsAsync(true);
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);

            var subscription = new Subscription("Torfin", "test@test.no");
            var subSucsess = await service.Subscribe(subscription);
            Assert.IsTrue(subSucsess);
            emailServiceMock.Verify(es => es.Send(It.Is<Email>(e => e.To == "test@test.no")));
            subscriptionRepoMock.Verify(sr => sr.Create(It.Is<Subscription>(s => s.Email == "test@test.no")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestSubDbFailure()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>())).ReturnsAsync(false);
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            var subscription = new Subscription("Torfin", "test@test.no");
            var IsSucsess = await service.Subscribe(subscription);
            Assert.IsFalse(IsSucsess);
            subscriptionRepoMock.Verify(sr => sr.Create(It.Is<Subscription>(s => s.Email == "test@test.no")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }
        [Test]
        public async Task TestSubEmailFailure()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>())).ReturnsAsync(false);
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>())).ReturnsAsync(true);
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            var subscription = new Subscription("Torfin", "test@test.no");
            var isSucsess = await service.Subscribe(subscription);
            Assert.IsFalse(isSucsess);
            emailServiceMock.Verify(es => es.Send(It.Is<Email>(e => e.To == "test@test.no")));
            subscriptionRepoMock.Verify(sr => sr.Create(It.Is<Subscription>(s => s.Email == "test@test.no")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();

        }
        [Test]
        public async Task TestVerificationOk()
        {
            var code = "216e9ae7-5150-4a35-a995-dcc4ba36ceff";
            var email = "test@test.no";
            var verificationRequest = new Subscription(null, email, code);
            var subRequestFromDatabase = new Subscription(null, null, code);


            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.ReadByEmail(email)).ReturnsAsync(subRequestFromDatabase);
            subscriptionRepoMock.Setup(sr => sr.Update(It.IsAny<Subscription>())).ReturnsAsync(true);
            var service = new SubscriptionService(null, subscriptionRepoMock.Object);
            var isSucsess = await service.Verify(verificationRequest);
            Assert.IsTrue(isSucsess);
            subscriptionRepoMock.Verify(sr => sr.Update(It.IsAny<Subscription>()));



        }
        [Test]
        public async Task TestVerifyInvalidCode()
        {
            var code = "216e9ae7-5150-4a35-a995-dcc4ba36ceff";
            var code2 = "216e9ae7-5150-4a35-a995-dcc4ba36jeff";
            var email = "test@test.no";
            var verificationRequest = new Subscription(null, email, code);
            var subRequestFromDatabase = new Subscription(null, null, code2);


            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.ReadByEmail(email)).ReturnsAsync(subRequestFromDatabase);

            var service = new SubscriptionService(null, subscriptionRepoMock.Object);
            var isSucsess = await service.Verify(verificationRequest);
            Assert.IsFalse(isSucsess);
            subscriptionRepoMock.Verify(sr => sr.ReadByEmail(email));
            subscriptionRepoMock.VerifyNoOtherCalls();


        }

    }
}
using Moq;
using NUnit.Framework;
using SocialWorkApp.Application.Services;

namespace SocialWorkApp.Application.Dashboards
{
    [TestFixture]
    public class ManageProvidersTest
    {
        AdminDashboard dashboard;
        Mock<IRepository> repositoryMock;
        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>() { DefaultValue = DefaultValue.Mock };
            dashboard = new AdminDashboard(repositoryMock.Object);
        }

        [Test]
        public void ShouldGetProviders()
        {
            repositoryMock.Setup(r => r.Providers).Returns(new List<ProviderUser>() 
            { 
                new ProviderUser("Mickey", "Mouse"),
                new ProviderUser("Minnie", "Mouse")
            });
            Assert.That(dashboard.GetProviders(), Has.Exactly(1).Matches<ProviderUser>(
                                    p => p.FirstName == "Mickey" &&
                                         p.LastName == "Mouse"));
            Assert.That(dashboard.GetProviders(), Has.Exactly(1).Matches<ProviderUser>(
                                    p => p.FirstName == "Minnie" &&
                                         p.LastName == "Mouse"));
        }

        [Test]
        public void ShouldAddProviders()
        {
            dashboard.AddProvider(new ProviderUser("Mickey", "Mouse"));
            repositoryMock.Verify(repo => repo.Providers.Add(It.IsAny<ProviderUser>()), Times.Once);
        }


    }
}

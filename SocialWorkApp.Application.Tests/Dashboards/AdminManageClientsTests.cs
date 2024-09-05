using Moq;
using NUnit.Framework;
using SocialWorkApp.Application.Services;

namespace SocialWorkApp.Application.Dashboards
{
    public class AdminManageClientsTests
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
        public void ShouldGetClients()
        {
            repositoryMock.Setup(r => r.AllClients).Returns(new List<ClientEntry>()
            {
                new ClientEntry("SpongeBob", "SquarePants"),
                new ClientEntry("Patrick", "Star")
            });
            Assert.That(dashboard.GetAllClients(), Has.Exactly(1).Matches<ClientEntry>(
                                   p => p.FirstName == "SpongeBob" &&
                                        p.LastName == "SquarePants"));
            Assert.That(dashboard.GetAllClients(), Has.Exactly(1).Matches<ClientEntry>(
                                    p => p.FirstName == "Patrick" &&
                                         p.LastName == "Star"));
        }
    }
}

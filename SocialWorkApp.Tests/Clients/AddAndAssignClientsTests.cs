using NUnit.Framework;
using SocialWorkApp.Domain.Users;


namespace SocialWorkApp.Domain.Clients
{
    [TestFixture]
    public class AddAndAssignClientsTests
    {

        [Test]
        public void ShouldAddClient()
        {
            var client = new Client("SpongeBob", "SquarePants", new DateOnly(2024, 12, 25));

            Assert.That(client.FirstName, Is.EqualTo("SpongeBob"));
            Assert.That(client.LastName, Is.EqualTo("SquarePants"));
            Assert.That(client.ISP_YearStartDate, Is.EqualTo(new DateOnly(2024, 12, 25)));
        }
       

        [Test]
        public void ShouldAssignClient()
        {
            var client = new Client("SpongeBob", "SquarePants", new DateOnly(2024, 12, 25));
            var provider = new Provider();
            provider.AddClient(client);

            Assert.That(provider.Clients, Does.Contain(client));
        }

        [Test]
        public void ShouldReassignClient()
        {
            var client = new Client("SpongeBob", "SquarePants", new DateOnly(2024, 12, 25));
            var mickey = new Provider();
            var minnie = new Provider();
            mickey.ReassignClient(client, minnie);

            Assert.That(minnie.Clients, Does.Contain(client));
            Assert.That(mickey.Clients, Does.Not.Contain(client));
        }

    }
}

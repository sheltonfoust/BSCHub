using NUnit.Framework;
using SocialWorkApp.Core.Users;


namespace SocialWorkApp.Core.Clients
{
    [TestFixture]
    public class AddAndAssignClientsTests
    {
        [Test]
        public void ShouldAddClientsWithInfoAndProvider()
        {
            var provider = new Provider();

            provider.AddClient("Patrick", "Star", new DateOnly(2025, 4, 2));

            var clients = provider.Clients;

            Assert.That(clients, Has.Exactly(1)
                .Matches<Client>(
                    c => c.FirstName == "Patrick" &&
                            c.LastName == "Star" &&
                            c.ISP_YearEndDate == new DateOnly(2025, 4, 2)));
        }

        


    }
}

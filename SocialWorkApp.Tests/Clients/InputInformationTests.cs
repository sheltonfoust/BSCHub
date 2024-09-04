using NUnit.Framework;

namespace SocialWorkApp.Domain.Clients
{
    [TestFixture]
    public class InputInformationTests
    {
        [Test]
        public void ShouldModifyClient()
        {
            var client = new Client("SpongeBob", "SquarePants", new DateOnly(2024, 12, 25));
            var reportInfo = new ClientReportInfo()
            {
                ISP_MeetingDate = new DateOnly(2025, 3, 15),
                isSevere = true,
                hasBCIP = false,
                hasPPMP = true,
                hasRMP = false
            };

            client.InputReportInfo(reportInfo);

            Assert.That(client.ISP_MeetingDate, Is.EqualTo(new DateOnly(2025, 3, 15)));
            Assert.That(client.IsSevere, Is.EqualTo(true));
            Assert.That(client.HasBCIP, Is.EqualTo(false));
            Assert.That(client.HasPPMP, Is.EqualTo(true));
            Assert.That(client.HasRMP, Is.EqualTo(false));

        }

        [Test]
        public void ShouldModifyClientWithConstructor()
        {
            var client = new Client("SpongeBob", "SquarePants", new DateOnly(2024, 12, 25));
            var reportInfo = new ClientReportInfo(new DateOnly(2025, 3, 15), true, false, true, false);

            client.InputReportInfo(reportInfo);

            Assert.That(client.ISP_MeetingDate, Is.EqualTo(new DateOnly(2025, 3, 15)));
            Assert.That(client.IsSevere, Is.EqualTo(true));
            Assert.That(client.HasBCIP, Is.EqualTo(false));
            Assert.That(client.HasPPMP, Is.EqualTo(true));
            Assert.That(client.HasRMP, Is.EqualTo(false));

        }



    }
}

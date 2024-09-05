using NUnit.Framework;
using static SocialWorkApp.Domain.Reports.ReportType;

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
            Assert.That(client.Has(PBSA), Is.EqualTo(true));
            Assert.That(client.Has(PBSP), Is.EqualTo(true));
            Assert.That(client.Has(BCIP), Is.EqualTo(false));
            Assert.That(client.Has(PPMP), Is.EqualTo(true));
            Assert.That(client.Has(RMP), Is.EqualTo(false));

        }

        [Test]
        public void ShouldModifyClientWithConstructor()
        {
            var client = new Client("SpongeBob", "SquarePants", new DateOnly(2024, 12, 25));
            var reportInfo = new ClientReportInfo(new DateOnly(2025, 3, 15), true, false, true, false);

            client.InputReportInfo(reportInfo);

            Assert.That(client.ISP_MeetingDate, Is.EqualTo(new DateOnly(2025, 3, 15)));

            Assert.That(client.IsSevere, Is.EqualTo(true));
            Assert.That(client.Has(PBSA), Is.EqualTo(true));
            Assert.That(client.Has(PBSP), Is.EqualTo(true));
            Assert.That(client.Has(BCIP), Is.EqualTo(false));
            Assert.That(client.Has(PPMP), Is.EqualTo(true));
            Assert.That(client.Has(RMP), Is.EqualTo(false));

        }



    }
}

using NUnit.Framework;
using SocialWorkApp.Core.Clients;
using static SocialWorkApp.Core.Reports.ReportType;

namespace SocialWorkApp.Core.Reports
{

    [TestFixture]
    public class CalculateDueDates
    {
       

        [Test]
        public void ShouldCalculateDueDatesIfNotSevere()
        {
            var yearEnd = new DateOnly(2025, 4, 2);
            var meeting = new DateOnly(2025, 1, 2);
            var client = new Client("Patrick", "Star", yearEnd);
            
            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meeting,
                isSevere = false,
                hasBCIP = true,
                hasPPMP = true,
                hasRMP = true,
                
            });


            Assert.That(client.GetReport(PBSA)?.DueDate, Is.EqualTo(meeting.AddDays(-14)));
            Assert.That(client.GetReport(PBSP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));

            Assert.That(client?.GetReport(BCIP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));
            Assert.That(client?.GetReport(PPMP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));
            Assert.That(client?.GetReport(RMP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));
        }

        [Test]
        public void ShouldCalculateDueDatesIfSevere()
        {
            var yearEnd = new DateOnly(2025, 8, 22);
            var meeting = new DateOnly(2025, 5, 22);
            var client = new Client("Spongebob", "SquarePants", yearEnd);

            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meeting,
                isSevere = true,
                hasBCIP = true,
                hasPPMP = true,
                hasRMP = true,
            });


            Assert.That(client.GetReport(PBSA)?.DueDate, Is.EqualTo(meeting.AddDays(-14)));
            Assert.That(client.GetReport(PBSP)?.DueDate, Is.EqualTo(meeting.AddDays(14)));

            Assert.That(client?.GetReport(BCIP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));
            Assert.That(client?.GetReport(PPMP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));
            Assert.That(client?.GetReport(RMP)?.DueDate, Is.EqualTo(yearEnd.AddDays(1)));

        }


    }
}

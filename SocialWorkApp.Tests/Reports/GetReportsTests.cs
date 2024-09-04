using NUnit.Framework;
using SocialWorkApp.Domain.Clients;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Reports
{

    [TestFixture]
    public class GetReportsTests
    {
        DateOnly yearStart = new DateOnly(2025, 4, 2);
        DateOnly meetingDate = new DateOnly(2025, 1, 2);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        Client client;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [SetUp]
        public void SetUp()
        {
            client = new Client("Patrick", "Start", yearStart);
        }

        [Test]
        public void ShouldCalculateDueDatesIfNotSevere()
        {
            
            
            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meetingDate,
                isSevere = false,
                hasBCIP = true,
                hasPPMP = true,
                hasRMP = true,
                
            });

            var reports = client.GetReports();


            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PBSA));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PBSP));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == BCIP));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PPMP));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == RMP));



            Assert.That(reports.Where(r => r.Type == PBSA).FirstOrDefault().DueDate, Is.EqualTo(meetingDate.AddDays(-14)));
            Assert.That(reports.Where(r => r.Type == PBSP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));

            Assert.That(reports.Where(r => r.Type == BCIP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));
            Assert.That(reports.Where(r => r.Type == PPMP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));
            Assert.That(reports.Where(r => r.Type == RMP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));
        }

        [Test]
        public void ShouldCalculateDueDatesIfSevere()
        {
           
            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meetingDate,
                isSevere = true,
                hasBCIP = true,
                hasPPMP = true,
                hasRMP = true,
            });

            var reports = client.GetReports();


            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PBSA));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PBSP));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == BCIP));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PPMP));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == RMP));


            Assert.That(reports.Where(r => r.Type == PBSA).FirstOrDefault().DueDate, Is.EqualTo(meetingDate.AddDays(-14)));
            Assert.That(reports.Where(r => r.Type == PBSP).FirstOrDefault().DueDate, Is.EqualTo(meetingDate.AddDays(14)));

            Assert.That(reports.Where(r => r.Type == BCIP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));
            Assert.That(reports.Where(r => r.Type == PPMP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));
            Assert.That(reports.Where(r => r.Type == RMP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));

        }

        [Test]
        public void ShouldCalculateCorrectlyIfNoOptionalReports()
        {

            

            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meetingDate,
                isSevere = false,
                hasBCIP = false,
                hasPPMP = false,
                hasRMP = false,
            });

            var reports = client.GetReports();

            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PBSA));
            Assert.That(reports, Has.Exactly(1)
                .Matches<Report>(r => r.Type == PBSP));
            Assert.That(reports, Has.Exactly(0)
                .Matches<Report>(r => r.Type == BCIP));
            Assert.That(reports, Has.Exactly(0)
                .Matches<Report>(r => r.Type == PPMP));
            Assert.That(reports, Has.Exactly(0)
                .Matches<Report>(r => r.Type == RMP));

            // Other two should still work
            Assert.That(reports.Where(r => r.Type == PBSA).FirstOrDefault().DueDate, Is.EqualTo(meetingDate.AddDays(-14)));
            Assert.That(reports.Where(r => r.Type == PBSP).FirstOrDefault().DueDate, Is.EqualTo(yearStart));

        }



    }
}

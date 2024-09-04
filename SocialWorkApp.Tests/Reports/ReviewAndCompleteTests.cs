using NUnit.Framework;
using SocialWorkApp.Domain.Clients;
using System.ComponentModel.DataAnnotations;
using static SocialWorkApp.Domain.Reports.Status;

namespace SocialWorkApp.Domain.Reports
{
    [TestFixture]
    public class ReviewAndCompleteTests
    {
        Client client;
        [SetUp]
        public void SetUp()
        {
            client = new Client("Patrick", "Star", new DateOnly(2025, 7, 30));
            client.InputReportInfo(new ClientReportInfo(new DateOnly(2025, 4, 30), false, true, true, true));
        }
        [Test]
        public void ShouldOriginallyBeUpcoming()
        {
            foreach (var report in client.GetReports())
            {
                Assert.That(report.Status, Is.EqualTo(Upcoming));
            }
        }
        
        [Test]
        public void ShouldMarkAsComplete()
        {
            foreach(var report in client.GetReports())
            {
                Assert.That(report.Status,Is.EqualTo(Upcoming));
                report.MarkAsComplete();
                Assert.That(report.Status, Is.EqualTo(InReview));
            }
        }

        [Test]
        public void ShouldReviewWhenUpcoming()
        {
            int i = 0;
            foreach(var report in client.GetReports())
            {
                Assert.That(report.Status, Is.EqualTo(Upcoming));
                var revDate = new DateOnly(2024, 5, 12).AddDays(i);
                report.Review(revDate);
                Assert.That(report.Status, Is.EqualTo(Reviewed));
                Assert.That(report.ReviewedDate, Is.EqualTo(revDate));
                i++;
            }
        }

        [Test]
        public void ShouldReviewWhenInReview()
        {
            int i = 0;
            foreach (var report in client.GetReports())
            {
                Assert.That(report.Status, Is.EqualTo(Upcoming));
                var revDate = new DateOnly(2024, 5, 12).AddDays(i);
                report.MarkAsComplete();
                report.Review(revDate);
                Assert.That(report.Status, Is.EqualTo(Reviewed));
                Assert.That(report.ReviewedDate, Is.EqualTo(revDate));
                i++;
            }
        }





    }
}

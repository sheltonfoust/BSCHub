﻿using NUnit.Framework;
using SocialWorkApp.Domain.Clients;
using static SocialWorkApp.Domain.Reports.ReportType;

namespace SocialWorkApp.Domain.Reports
{

    [TestFixture]
    public class GetReportTests
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
            Assert.That(client.HasReportInfo, Is.EqualTo(false));
            
            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meetingDate,
                isSevere = false,
                hasBCIP = true,
                hasPPMP = true,
                hasRMP = true,
                
            });

            Assert.That(client.HasReportInfo, Is.EqualTo(true));


            Assert.That(client.GetReport(PBSA).DueDate, Is.EqualTo(meetingDate.AddDays(-14)));
            Assert.That(client.GetReport(PBSP).DueDate, Is.EqualTo(yearStart));

            Assert.That(client.GetReport(BCIP).DueDate, Is.EqualTo(yearStart));
            Assert.That(client.GetReport(PPMP).DueDate, Is.EqualTo(yearStart));
            Assert.That(client.GetReport(RMP).DueDate, Is.EqualTo(yearStart));
        }

        [Test]
        public void ShouldCalculateDueDatesIfSevere()
        {

            Assert.That(client.HasReportInfo, Is.EqualTo(false));

            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meetingDate,
                isSevere = true,
                hasBCIP = true,
                hasPPMP = true,
                hasRMP = true,
            });

            Assert.That(client.HasReportInfo, Is.EqualTo(true));

            Assert.That(client.GetReport(PBSA).DueDate, Is.EqualTo(meetingDate.AddDays(-14)));
            Assert.That(client.GetReport(PBSP).DueDate, Is.EqualTo(meetingDate.AddDays(14)));

            Assert.That(client.GetReport(BCIP).DueDate, Is.EqualTo(yearStart));
            Assert.That(client.GetReport(PPMP).DueDate, Is.EqualTo(yearStart));
            Assert.That(client.GetReport(RMP).DueDate, Is.EqualTo(yearStart));

        }

        [Test]
        public void ShouldThrowExceptionIfQueriesNonExistentReport()
        {
         

            client.InputReportInfo(new ClientReportInfo()
            {
                ISP_MeetingDate = meetingDate,
                isSevere = false,
                hasBCIP = false,
                hasPPMP = false,
                hasRMP = false,
            });

            Assert.That(() => client.GetReport(BCIP), Throws.TypeOf<ArgumentException>());
            Assert.That(() => client.GetReport(PPMP), Throws.TypeOf<ArgumentException>());
            Assert.That(() => client.GetReport(RMP), Throws.TypeOf<ArgumentException>());

            // Other two should still work
            Assert.That(client.GetReport(PBSA).DueDate, Is.EqualTo(meetingDate.AddDays(-14)));
            Assert.That(client.GetReport(PBSP).DueDate, Is.EqualTo(yearStart));

        }



    }
}

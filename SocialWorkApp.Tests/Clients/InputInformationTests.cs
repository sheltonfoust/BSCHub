using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Core.Tests.Reports
{
    [TestFixture]
    public class InputInformationTests
    {
        [Test]
        public void ShouldModifyClient()
        {
            var client = new Client();
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
    }
}

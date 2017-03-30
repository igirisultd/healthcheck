using System.Net;
using System.Threading.Tasks;

using NUnit.Framework;

namespace HealthCheck.EndToEndTests
{
    [TestFixture]
    public class CheckSampleApplication
    {
        [Test]
        public void Status_Code_Is_Good()
        {
            Assert.DoesNotThrowAsync(async () => await MakeStatusRequest());
        }

        [Test]
        public async Task There_Is_Some_Body_Content()
        {
            var response = await MakeStatusRequest();

            Assert.That(response.ContentLength, Is.GreaterThan(0));
        }

        private async Task<WebResponse> MakeStatusRequest()
        {
            return await WebRequest.CreateHttp("http://localhost:59799/status").GetResponseAsync();
        }
    }
}

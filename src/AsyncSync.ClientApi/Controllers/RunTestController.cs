using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncSync.ClientApi.Controllers
{
    [RoutePrefix("api/run-test")]
    public class RunTestController : ApiController
    {
        [HttpGet, Route("fullasync")]
        public async Task<string[]> GetFullAsync()
        {
            using (var response = await WaitApi.Client.PostAsync("wait/1", null))
            {
                using (var response2 = await WaitApi.Client.PostAsync("wait/1", null))
                {
                }
            }

            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("fullsync")]
        public string[] GetSullSync()
        {
            using (var response = WaitApi.Client.PostAsync("wait/1", null).Result)
            {
                using (var response2 = WaitApi.Client.PostAsync("wait/1", null).Result)
                {
                }
            }

            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("deadlock")]
        public async Task<string[]> GetDeadlockAsync()
         {
            using (var response = await WaitApi.Client.PostAsync("wait/1", null))
            {
                using (var response2 = WaitApi.Client.PostAsync("wait/1", null).Result)
                {
                }
            }

            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("threadpoolhack")]
        public async Task<string[]> GetThreadpoolhackAsync()
        {
            using (var response = Task.Run(() => WaitApi.Client.PostAsync("wait/1", null)).GetAwaiter().GetResult())
            {
                using (var response2 = Task.Run(() => WaitApi.Client.PostAsync("wait/1", null)).GetAwaiter().GetResult())
                {
                }
            }


            return new string[] { "value1", "value2" };
        }
    }
}

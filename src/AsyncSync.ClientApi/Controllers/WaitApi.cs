namespace AsyncSync.ClientApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Web;

    public static class WaitApi
    {
        public static HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri(ConfigurationManager.AppSettings["waitApi.url"])
        };
    }
}

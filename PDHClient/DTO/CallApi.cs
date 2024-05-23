using System.Net.Http.Headers;

namespace PDHClient.DTO
{
    public class CallApi
    {
        internal HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public CallApi()
        {
            BaseUrlSet();

        }

        public CallApi(string address, string appId, IConfiguration configuration)
        {
            BaseUrlSet(address, appId);
            this.configuration = configuration;
        }

        public void BaseUrlSet()
        {

            client.BaseAddress = new Uri(configuration.GetSection("AppSettings")["eIDMSBaseUrl"]);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("AppId", ConfigurationManager.AppSettings["AppID"]);
            //client.DefaultRequestHeaders.Add("ApiKey", ConfigurationManager.AppSettings["NSIApiKey"]);
        }

        public void BaseUrlSet(string address, string appId)
        {
            client.BaseAddress = new Uri(address);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //string secKey = ClsEnDec.Encrypt(appId);
            //client.DefaultRequestHeaders.Add(ConfigurationManager.AppSettings["SecurityKeyName"], secKey);
        }

    }
}

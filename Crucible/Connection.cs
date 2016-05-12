using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
using Newtonsoft.Json.Linq;

namespace Crucible
{
    public class Connection
    {
        public static Connection Login(Uri baseUrl, string userName, string password)
        {
            var restClient = new RestClient(baseUrl);

            var response = restClient.Execute(
                new RestRequest("auth-v1/login", Method.POST)
                .AddParameter("userName", userName)
                .AddParameter("password", password));

            dynamic content = JObject.Parse(response.Content);
            
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(content.error.Value);
            }

            var token = new AuthenticationToken(content.token.Value);
            return new Connection(token, restClient);
        }

        private Connection(AuthenticationToken token, IRestClient restClient)
        {
            AuthenticationToken = token;
            RestClient = restClient;
        }

        internal AuthenticationToken AuthenticationToken { get; private set; }
        internal IRestClient RestClient { get; private set; }
    }
}

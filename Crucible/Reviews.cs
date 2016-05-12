using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Crucible
{
    public class Reviews
    {
        private Connection _connection;

        public Reviews(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ReviewData> GetReviews(params ReviewState[] states)
        {
            var restClient = _connection.RestClient;
            string state = string.Join(",", states.Select(s => s.ToString()));

            var response = restClient.Execute(
                new RestRequest("reviews-v1", Method.GET)
                .AddParameter("state", state));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.ToString());
            }

            dynamic data = JObject.Parse(response.Content);

            IEnumerable<dynamic> results = data.reviewData;
            return results.Select(rd => new ReviewData(rd));
        }
    }
}

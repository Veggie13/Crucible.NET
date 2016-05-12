using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crucible;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = Connection.Login(new Uri("http://code-review:8060/rest-service"), "cderochie", "asdfASDF1234");
            var reviews = new Reviews(conn);
            var openReviews = reviews.GetReviews(ReviewState.Closed);
        }
    }
}

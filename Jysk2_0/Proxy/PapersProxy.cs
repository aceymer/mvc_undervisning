using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Jysk2_0.Proxy
{
    public class PapersProxy
    {
        public IEnumerable<Paper> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:1823/api/papers/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Paper>>().Result;
            }
        }
        
        public Paper Add(Paper paper)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:1823/api/papers/", paper).Result;
                return response.Content.ReadAsAsync<Paper>().Result;
            }
        }
    }
    
}
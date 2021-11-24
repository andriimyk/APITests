using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace APITests.Classes
{
    public class RestHelper
    {
        public RestClient client;
        public RestRequest request;
        public string baseUrl = "https://reqres.in/";

        public RestClient SetClient()
        {
            client = new RestClient(baseUrl);
            return client;
        }

        public RestClient SetUrl(string resourse)
        {
            string newUrl = Path.Combine(baseUrl, resourse);
            client = new RestClient(newUrl);
            return client;
        }

        public IRestResponse GetRequest()
        {
            request = new RestRequest(Method.GET);
            return client.Execute(request);
        }

        public T GetContent<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public List<int> GetListOfId(UserName answer)
        {
            return answer.data.Select(x => x.id).ToList();
        }

        public List<string> GetListOfEmails(UserName answer)
        {
            return answer.data.Select(x => x.email).ToList();
        }

        //public IRestRequest CreatePostRequest(string jsonString)
        //{
        //    request = new RestRequest(Method.POST);
        //    request.AddHeader("Accept", "application/json");
        //    request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
        //    return request;
        //}


    }
}

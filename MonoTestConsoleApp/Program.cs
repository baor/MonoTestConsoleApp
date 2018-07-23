using RestSharp;
using Shouldly;
using System;
using System.Net;

namespace MonoTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://myaccount-authentication.travix.com");
            var request = new RestRequest("/cheaptickets/account/login", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody("{\"password\":\"aaaaa\",\"emailAddress\":\"a@a.aa\",\"generateRememberMeToken\":false,\"AffiliateCode\":\"CheapticketsNL\",\"BrandName\":\"cheaptickets\",\"CountryCode\":\"NL\",\"LanguageCode\":\"nl\"}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine($"Response code: {response.StatusCode}");
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest, $"Expected status code: {HttpStatusCode.BadRequest}");
        }
    }
}

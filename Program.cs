using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Chuck
{
    class Program
    {

        // Chuck norris api

        static void Main(string[] args)
        {
             string joke = GetJoke();
             Console.WriteLine(joke);
        }

        static string GetJoke()
        {
            WebClient webClient = new WebClient();
            string webResponse = webClient.DownloadString("https://api.chucknorris.io/jokes/random");
            string joke = JObject.Parse(webResponse).GetValue("value").ToString();
            return joke;
        }

        // Another way of writing code below

        /*
        static string GetJoke_ManualJsonParse()
        {
            WebClient webClient = new WebClient();
            string webResponse = webClient.DownloadString("https://api.chucknorris.io/jokes/random");

            int jokeKeyLocation = webResponse.IndexOf("value");
            int jokeTextLocation = jokeKeyLocation + 5 + 3; // 5 for "value", 3 for quotes and colons
            string joke = webResponse.Substring(jokeKeyLocation, webResponse.Length - 2 - jokeTextLocation);
            return joke;
        }
        */
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace testChimitheque
{
    class Program
    {
        static string ReadPassword()
        {
            StringBuilder password = new StringBuilder();

            while(true)
            {
                var keyInfo = Console.ReadKey(true);
                if(keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                password.Append(keyInfo.KeyChar);
                Console.Write("*");
            }

            return password.ToString();
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string userName = Console.ReadLine();
            string password = ReadPassword();
            string apiURL = "https://imost.iut-clermont.uca.fr/chimithequedev/get-token";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"person_email\":\"" + userName + "\"," +
                              "\"person_password\":\"" + password + "\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string token;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                token = streamReader.ReadToEnd();
            }

            var cookie = httpResponse.Headers[HttpResponseHeader.SetCookie];

            

            string apiURL2 = "https://imost.iut-clermont.uca.fr/chimithequedev/storelocations";
            httpWebRequest = (HttpWebRequest)WebRequest.Create(apiURL2);
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers[HttpRequestHeader.Authorization] = $"Bearer {token}";
            httpWebRequest.Headers[HttpRequestHeader.Cookie] = cookie.Replace(",", ";");




            var httpResponse2 = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            string result;
            using (var streamReader = new StreamReader(httpResponse2.GetResponseStream(), Encoding.Default))
            {
                result = await streamReader.ReadToEndAsync();
            }

            var jsonReader = new JsonTextReader(new StringReader(result));


            JsonSerializer serializer = new JsonSerializer();
            Result results = serializer.Deserialize<Result>(jsonReader);
            Console.WriteLine(results.ToString());
        }
    }

    public class Result
    {
        public List<StoreLocation> Rows { get; set; } = new List<StoreLocation>();
        public int Total { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[Rows :");
            foreach(var r in Rows)
            {
                sb.Append($"\t{r}\n");
            }
            sb.Append($"[Total : {Total}]");
            return sb.ToString();
        }
    }

    public class StoreLocation
    {
        public StoreLocationId StoreLocation_Id { get; set; }

        public StoreLocationName StoreLocation_Name { get; set; }

        public override string ToString()
        {
            return $"[Id: {StoreLocation_Id.Int64}] ; [Name: {StoreLocation_Name.String}]";
        }
    }

    public class StoreLocationId
    {
        public long Int64 { get; set; }

        public bool Valid { get; set; }
    }

    public class StoreLocationName
    {
        public string String { get; set; }
        public bool Valid { get; set; }
    }
}

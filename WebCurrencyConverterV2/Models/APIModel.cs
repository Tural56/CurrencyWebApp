using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace WebCurrencyConverterV2.Models
{
    public class APIModel
    {

        //readonly string Key = "23CfaMSH9KeiCkN5DqumHPHaE4mNih";
        public static Currency GetResult(string from, string to, double amount)
        {
            
            string url = $"https://api.exchangerate.host/convert?from={from}&to={to}&amount={amount}";

            
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url).Result;
            Currency result;
            if (amount != 0)
            {
                result = JsonSerializer.Deserialize<Currency>(response);
            }
            else
            {
                result=null;
                
            }



            return result;
        }

        public static List<string> GetList()
        {
            string url = $"https://api.exchangerate.host/symbols";


            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url).Result;

            JObject rss = JObject.Parse(response);
            JObject itemTitle = (JObject)rss["symbols"];


            List<string> items = new List<string>();
            foreach (var item in itemTitle)
            {
                items.Add(item.Key.ToString());
                
            }
            


            

            return items;
        }
    }
}

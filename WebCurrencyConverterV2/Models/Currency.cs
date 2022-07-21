namespace WebCurrencyConverterV2.Models
{
    public class Currency
    {
        public bool success { get; set; }
        public Query query { get; set; }
        public Info info { get; set; }
        public bool historical { get; set; }
        public string date { get; set; }
        public double result { get; set; }

        public string message { get; set; }

    }

    public class Info
    {
        public double rate { get; set; }
    }

    
}

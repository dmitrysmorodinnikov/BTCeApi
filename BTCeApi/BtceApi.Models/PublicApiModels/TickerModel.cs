namespace BtceApi.Models.PublicApiModels
{
    public class TickerModel
    {
        public Ticker Ticker { get; set; }
    }

    public class Ticker
    {
        public double High { get; set; }
        public double Low { get; set; }
        public double Avg { get; set; }
        public double Vol { get; set; }
        public double Vol_Cur { get; set; }
        public double Last { get; set; }
        public double Buy { get; set; }
        public double Sell { get; set; }
        public long Updated { get; set; }
        public long ServerTime { get; set; }
    }
}

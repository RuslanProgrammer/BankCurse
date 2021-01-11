using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BankCurse
{
    public class ExchangeRate
    {
        public int ExchangeId { set; get; }
        public string ExchangeDate { set; get; } = DateTime.Today.ToString("yyyy-MM-dd");
        public double Amount { set; get; }
        public bool IsChanged { set; get; }
        public Currency Currency { set; get; }

        public ExchangeRate(int exchangeId, string exchangeDate, double amount, Currency currency)
        {
            ExchangeId = exchangeId;
            ExchangeDate = exchangeDate;
            Amount = amount;
            Currency = currency;
            IsChanged = true;
        }

        public ExchangeRate()
        {
            IsChanged = false;
        }

        public static double ParseValue(string date, string name)
        {
            try
            {
                string path = $@"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date={date}&json";
                try
                {
                    using (WebClient wc = new WebClient { Encoding = Encoding.UTF8 })
                    {
                        string html = wc.DownloadString(path);
                        var result = JsonConvert.DeserializeObject<List<Temp>>(html);
                        return result.Select(x => x).Single(x => x.Txt == name).Rate;
                    }
                }
                catch
                {
                    throw new Exception("Не вдалось загрузити файл.");
                }
            }
            catch
            {
                if(Convert.ToDateTime(date) != DateTime.Today.Date)
                    return -1;
                throw new Exception("Сталася помилка.");
            }
        }

        private class Temp
        {
            public int R030;
            public string Txt;
            public double Rate;
            public string Cc;
            public string ExchangeDate;
        }
    }
}

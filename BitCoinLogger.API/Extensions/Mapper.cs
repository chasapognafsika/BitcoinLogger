using BitcoinLogger.Api.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Extensions
{

    internal static class Mapper
    {
        internal static PriceHistoryItem ConvertJSONToCurrecyPair(string json, Source source)
        {
            if (source.Endpoint.Contains("bitstamp"))
            {
                PriceHistoryItem result = new PriceHistoryItem();

                result.SourceId = source.Id;

                dynamic tempCurrencyPair = JsonConvert.DeserializeObject(json);

                if (tempCurrencyPair == null) return null;

                result.Bid = tempCurrencyPair.last;
                if (tempCurrencyPair.timestamp != null)
                {
                    double unixTimeStamp = double.Parse(tempCurrencyPair.timestamp.ToString());
                    result.Timestamp = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    result.Timestamp = result.Timestamp.AddSeconds(unixTimeStamp).ToLocalTime();
                }

                return result;
            }
            else
            if (source.Endpoint.Contains("gdax"))
            {
                PriceHistoryItem result = new PriceHistoryItem();
                result.SourceId = source.Id;

                dynamic tempCurrencyPair = JsonConvert.DeserializeObject(json);

                if (tempCurrencyPair == null) return null;

                result.Bid = tempCurrencyPair.price;

                if (tempCurrencyPair.time != null)
                    result.Timestamp = DateTime.Parse(tempCurrencyPair.time.ToString().Replace('/', '-')).ToLocalTime();

                return result;
            }

            throw new Exception("ConvertJSONToCurrecyPair: Could not find source url.");
        }
    }
}

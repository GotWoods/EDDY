using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Transactions;

namespace My214Parser;

public class Mapped214
{
    public string TransportId { get; set; }
    public string CarrierPro { get; set; }
    public string BillOfLading { get; set; }
    public string PurchaseOrderNumber { get; set; }
    
    public List<MappedUpdate> Updates { get; set; } = new();
   
}

public class MappedUpdate
{
    public string StatusCode { get; set; }
    public DateTime EventOccurredOn { get; set; }
    public Location Location { get; set; }
    public string TrailerNumber { get; set; }
    public string StopNumber { get; set; }

}

public class Mapper
{
    public List<Mapped214> Map(Generic214 generic214)
    {
        var results = new List<Mapped214>();
        var rawJson = Newtonsoft.Json.JsonConvert.SerializeObject(generic214);
        var asJson = JObject.Parse(rawJson);
        
        //ZZ Mapper
        //It could be position based (e.g. character 1-3 is the type, 4-7 is the data
        //It could have a separator (e.g. "TM|22|C" could be 22 degrees celsius)
        //It could also be that the first occurrence of ZZ means 1 thing and then the next ZZ entry would be something else!
        //

        for (var index = 0; index < generic214.Transactions.Count; index++)
        {
            var transaction = generic214.Transactions[index];
            var result = new Mapped214();
            result.CarrierPro = transaction.ReferenceNumbers.FirstOrDefault(x => x.Key == "CN")?.Value;
            result.BillOfLading = transaction.ReferenceNumbers.FirstOrDefault(x => x.Key == "BM")?.Value;
            result.PurchaseOrderNumber = transaction.ReferenceNumbers.FirstOrDefault(x => x.Key == "PO")?.Value;

            //var customReferences = transaction.ReferenceNumbers.Where(x => x.Key == "ZZ");
            //$.Transactions[{0}].ReferenceNumbers
            
            foreach (var update in transaction.Updates)
            {
                var mu = new MappedUpdate();
                mu.Location = update.Location;
                mu.StatusCode = update.StatusCode;
                mu.EventOccurredOn = update.EventDate;
                mu.TrailerNumber = update.EquipmentNumber; //Sometimes this is NONE or TBD but would vary by carrier
                mu.StopNumber = transaction.ReferenceNumbers.FirstOrDefault(x => x.Key == "QN")?.Value;
                
                result.Updates.Add(mu);
            }

            //these would be loaded from the database (and cached)
            var maps = new Dictionary<string, string>();
            maps.Add("AACT", ""); //AA Cooper
            maps.Add("CCNI", "$.ShipmentId"); //Cardinal
            maps.Add("RBTW", "$.ShipmentId"); //CHRobinson  (also stored as last L11 with a ZZ type)
            maps.Add("FXFE", ""); //FedEx
            maps.Add("HMES", "$.ShipmentId"); //Holland These tend to have the BOL/PO/Etc fields but put NA in for blanks (PO UNAVAILABLE is also a blank item)
            maps.Add("KLGE", "$.ShipmentId"); //KLGExpress
            maps.Add("KNIG", "$.ShipmentId"); //Knight
            maps.Add("LRGR", "$.ShipmentId"); //Landstar
            maps.Add("LIVS", "$.ShipmentId"); //LIV Enterprise
            maps.Add("LONE", "$.Transactions[{0}].ReferenceNumbers[?(@.Key == 'SI')]"); //LOAD
            maps.Add("MGXB", "$.ShipmentId"); //Magellan
            maps.Add("PYLE", "$.ShipmentId"); //Pyle
            maps.Add("RTCY", "$.ShipmentId"); //R2 Logistics

          

            //Debug.WriteLine(rawJson.ToString());
            //result.TransportId = asJson.SelectTokens(search).FirstOrDefault().ToString();

            if (maps[generic214.From] != "")
            {
                var searchResult = asJson.SelectToken(string.Format(maps[generic214.From], index));

                if (searchResult is JObject) //key/value pair
                {
                    result.TransportId = searchResult["Value"].ToString();
                }
                else
                {
                    result.TransportId = searchResult.Value<string>();
                }
            }

            results.Add(result);
        }

        return results;
    }
}
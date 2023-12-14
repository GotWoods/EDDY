// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Eddy.x12;
using My214Parser;
using My214Parser.Converters;


//G:\EdiSamples\CHRobinson\214\OUT\2023\02\RBTW_214_202302010000461241.txt
//is a good example of a record that has one 214 message but two transactions in that 214 (an Arrival and a CompletedUnloading at the same stop)

//G:\EdiSamples\Holland\214\IN\2023\02\USFC214_11001.edi
//has both. It has 2 214 segments both with 2 transactions each (the transactions happen at different times, this may be a milkrun)

//Questions for UI
//Upload a simple file (we do maps off that)
//Upload a file that has more than one transaction update in it (if you have it)
//Upload a file that has more than one transport update in it (if you have it)
//Upload a file with sensor readings
//Upload a file with stops in it
//Timezones upload a timezone with daylight time and standard time
//Any other custom values?


var paths = new List<string>
{
    "G:\\EdiSamples\\AAACooper\\214\\IN\\2023\\02",
    "G:\\EdiSamples\\CardinalLogisticsManagement\\214\\IN\\2023\\03",
     "G:\\EdiSamples\\CHRobinson\\214\\IN\\2023\\03", //these can have ZZ identifiers
    //"G:\\EdiSamples\\CHRobinson\\214\\OUT\\2023\\02",
    "G:\\EdiSamples\\FedEx\\214\\IN\\2023\\02",
    
    "G:\\EdiSamples\\Holland\\214\\IN\\2023\\02",
    "G:\\EdiSamples\\KLGExpress\\214\\IN\\2023\\02",
    "G:\\EdiSamples\\knight\\214\\IN\\2023\\02",
    "G:\\EdiSamples\\LandstarAgent\\214\\IN\\2023\\02",
    "G:\\EdiSamples\\LIVEnterprises\\214\\IN\\2023\\02",
    "G:\\EdiSamples\\Load\\214\\IN\\2023\\02", //this has one estimated arrivals in it
    "G:\\EdiSamples\\Magellan\\214\\IN",
    "G:\\EdiSamples\\Magna\\214\\OUT\\2023\\02",
    "G:\\EdiSamples\\pyle\\214\\2023\\02",
    "G:\\EdiSamples\\R2Logistics\\214\\IN\\2023\\02",
    
    //"G:\\EdiSamples\\FreightSOL\\214\\IN";
};

var sw = new Stopwatch();
var fileCount = 0;
sw.Start();

var mapper = new Mapper();

foreach (var folder in paths)
{
    Console.WriteLine("Parsing folder " + folder);
    foreach (var filePath in Directory.GetFiles(folder))
    {
        fileCount++;
        //var filePath = "C:\\CMAC_BUG_L1851696_1.txt";
        Console.WriteLine("Parsing file " + filePath);
        var data = File.ReadAllText(filePath);
        var document = x12Document.Parse(data);

        //Console.WriteLine(filePath);
        var converter = new v4010Converter();
        foreach (var section in document.Sections)
        {
            var result = converter.Convert(section.Segments);

            foreach (var item in result.Transactions)
                // foreach (var customVariables in item.ReferenceNumbers.Where(x => x.Key == "ZZ").Select(x => x.Value))
                //     Console.WriteLine("Custom: " + customVariables);

                result.From = document.InterchangeControlHeader.InterchangeSenderID.Trim();
            result.To = document.InterchangeControlHeader.InterchangeReceiverID.Trim();

            var mapped = mapper.Map(result);


            foreach (var mapped214 in mapped)
            {
                Console.WriteLine("TransportId: \t" + mapped214.TransportId);
                if (!string.IsNullOrEmpty(mapped214.BillOfLading)) Console.WriteLine("BOL:\t\t" + mapped214.BillOfLading);
                if (!string.IsNullOrEmpty(mapped214.CarrierPro)) Console.WriteLine("Carrier Pro:\t" + mapped214.CarrierPro);
                if (!string.IsNullOrEmpty(mapped214.PurchaseOrderNumber)) Console.WriteLine("PO:\t\t" + mapped214.PurchaseOrderNumber);

                foreach (var update in mapped214.Updates)
                {
                    Console.WriteLine("\tEvent Happened At: " + update.EventOccurredOn);
                    if (!string.IsNullOrEmpty(update.StopNumber)) Console.WriteLine("\tStop: " + update.StopNumber);
                    if (update.Location != null)
                        Console.WriteLine("\tLocation: " + update.Location.City + ", " + update.Location.StateProvinceCode + ", " + update.Location.CountryCode);
                    else
                        Console.WriteLine("\tLocation not specified");

                    if (!string.IsNullOrEmpty(update.TrailerNumber)) Console.WriteLine("\tTrailer: " + update.TrailerNumber);
                    Console.Write("\tStatus: ");
                    switch (update.StatusCode)
                    {
                        case "X3":
                            Console.WriteLine("Arrived at Pick-up Location");
                            break;
                        case "AF":
                            Console.WriteLine("Carrier Departed Pick-up Location with Shipment");
                            break;
                        case "X6":
                            Console.WriteLine("En Route To Destination");
                            break;

                        case "X1":
                            Console.WriteLine("Arrived at Delivery Location");
                            break;

                        case "D1":
                            Console.WriteLine("Completed Unloading at Delivery Location");
                            break;

                        case "AP":
                            Console.WriteLine("Delivery Not Completed");
                            break;
                        case "AG":
                            Console.WriteLine("Estimated Delivery");
                            break;
                        case null:
                            Console.WriteLine("Unkown");
                            break;
                        default:
                            Console.WriteLine("Unkown");
                            break;
                    }

                    foreach (var shipmentWeightPackagingAndQuantityData in update.ShipmentWeightPackagingAndQuantityData)
                    {
                        if (shipmentWeightPackagingAndQuantityData.Weight != null)
                        {

                            var weightUnit = "";
                            switch (shipmentWeightPackagingAndQuantityData.Weight.Qualifier)
                            {
                                case "L":
                                    weightUnit = "Lbs";
                                    break;
                                case "K":
                                    weightUnit = "Kg";
                                    break;
                                case "G":
                                    weightUnit = "Grams";
                                    break;
                                default:
                                    weightUnit = shipmentWeightPackagingAndQuantityData.Weight.Qualifier;
                                    break;
                            }
                            Console.WriteLine("\tWeight: " + shipmentWeightPackagingAndQuantityData.Weight.Item + weightUnit);
                        }

                        if (shipmentWeightPackagingAndQuantityData.Quantity != null)
                            Console.WriteLine("\tQuantity: " + shipmentWeightPackagingAndQuantityData.Quantity.Item);
                        if (shipmentWeightPackagingAndQuantityData.Volume != null)
                        {
                            var volumeUnit = "";
                            switch (shipmentWeightPackagingAndQuantityData.Volume.Qualifier)
                            {
                                case "E":
                                    volumeUnit = " Cubic Feet";
                                    break;
                                case "G":
                                    volumeUnit = " Gallons";
                                    break;
                                case "X":
                                    volumeUnit = " Cubic Meters";
                                    break;
                                default:
                                    volumeUnit = shipmentWeightPackagingAndQuantityData.Weight.Qualifier;
                                    break;
                            }
                            if (shipmentWeightPackagingAndQuantityData.Volume.Item > 0)
                                Console.WriteLine("\tVolume: " + shipmentWeightPackagingAndQuantityData.Volume.Item + volumeUnit);
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}


sw.Stop();
Console.WriteLine($"Finished processing {fileCount} files in {sw.ElapsedMilliseconds}ms ({Math.Round(sw.ElapsedMilliseconds / (double)fileCount, 2)}ms/file)");
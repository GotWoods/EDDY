// See https://aka.ms/new-console-template for more information

using System.Text;
using Eddy.x12;
using Eddy.x12.DomainModels.Transportation.v4010;
using Eddy.x12.Mapping;

var paths = new List<string>();
{
//var path = "G:\\EdiSamples\\AAACooper\\214\\IN\\2023\\02";

//var path = "G:\\EdiSamples\\CardinalLogisticsManagement\\214\\IN\\2023\\03";
//var path = "G:\\EdiSamples\\CHRobinson\\214\\IN\\2023\\03";
//var path = "G:\\EdiSamples\\CHRobinson\\214\\OUT\\2023\\02";
//var path = "G:\\EdiSamples\\FedEx\\214\\IN\\2023\\02";
//NOT WORKING var path = "G:\\EdiSamples\\FreightSOL\\214\\IN";
//var path = "G:\\EdiSamples\\Holland\\214\\IN\\2023\\02";
//var path = "G:\\EdiSamples\\KLGExpress\\214\\IN\\2023\\02";
//var path = "G:\\EdiSamples\\knight\\214\\IN\\2023\\02";
//var path = "G:\\EdiSamples\\LandstarAgent\\214\\IN\\2023\\02";
//var path = "G:\\EdiSamples\\LIVEnterprises\\214\\IN\\2023\\02";
//var path = "G:\\EdiSamples\\Load\\214\\IN\\2023\\02"; //this has one estimated arrival entry
//var path = "G:\\EdiSamples\\Magellan\\214\\IN";
//var path = "G:\\EdiSamples\\Magna\\214\\OUT\\2023\\02";
//var path = "G:\\EdiSamples\\pyle\\214\\2023\\02";
//var path = "G:\\EdiSamples\\R2Logistics\\214\\IN\\2023\\02";
}

//var path = "G:\\EdiSamples\\PureTransportation\\214\\IN\\2023\\02";
var path = "G:\\EdiSamples\\Magellan\\214\\IN";
foreach (var filePath in Directory.GetFiles(path))
{
//var filePath = "C:\\CMAC_BUG_L1851696_1.txt";
Console.WriteLine("Parsing file " + filePath);
var data = File.ReadAllText(filePath);
var document = x12Document.Parse(data);

//if (document.Sections.Count > 1) throw new Exception("More than one in a file!");

foreach (var section in document.Sections)
{
    var mapper = new DomainMapper(section.Segments);
    var edi214 = mapper.Map<Edi214_TransportationCarrierShipmentStatusMessage>();
    Console.WriteLine("Shipment Identification Number: " + edi214.Detail.ShipmentIdentificationNumber);
    Console.WriteLine("Carrier SCAC: " + edi214.Detail.StandardCarrierAlphaCode);
    
    foreach (var referenceNumber in edi214.BusinessInstructionsAndReferenceNumbers)
        switch (referenceNumber.ReferenceIdentificationQualifier)
        {
            case "BM":
                Console.WriteLine("Bill Of Lading: " + referenceNumber.ReferenceIdentification);
                break;
            case "SI":
                Console.WriteLine("Shipper Identifier: " + referenceNumber.ReferenceIdentification);
                break;
            case "CN":
                Console.WriteLine("Carrier Pro: " + referenceNumber.ReferenceIdentification);
                break;
            case "CO":
                Console.WriteLine("Customer Order Number: " + referenceNumber.ReferenceIdentification);
                break;
            case "CR":
                Console.WriteLine("Customer Reference Number: " + referenceNumber.ReferenceIdentification);
                break;
            case "11":
                Console.WriteLine("Account Number: " + referenceNumber.ReferenceIdentification);
                break;
            case "PO":
                Console.WriteLine("Purchase Order: " + referenceNumber.ReferenceIdentification);
                break;
            case "BN":
                Console.WriteLine("Booking Number: " + referenceNumber.ReferenceIdentification);
                break;
            case "OQ":
                Console.WriteLine("Order Number: " + referenceNumber.ReferenceIdentification);
                break;
            case "TN":
                Console.WriteLine("Transaction Reference Number: " + referenceNumber.ReferenceIdentification);
                break;
            case "ZZ":
                Console.WriteLine("Custom Identifier: " + referenceNumber.ReferenceIdentification);
                //ZZ*75|F
                //ZZ*TEMP:43:Unit:C
                break;
            default:
                Console.WriteLine("Unknown Reference Identifier: " + referenceNumber.ReferenceIdentificationQualifier);
                break;
        }


    foreach (var detail in edi214.Details)
    {
        foreach (var status in detail.ShipmentStatusDetails)
        {
            //missing date and time
            Console.WriteLine("Event Happened At: " + status.Details.Date + ":" + status.Details.Time);

            //interesting maps here https://www.stedi.com/edi/x12-008020/segment/AT7
            //status.
            if (status.Location != null)
            {
                var location = new StringBuilder();
                location.AppendLine(status.Location.CityName + ", " + status.Location.StateOrProvinceCode + ", " + status.Location.CountryCode);
                Console.WriteLine("Location: " + location);
            }
            else
            {
                Console.WriteLine("Location not specified");
            }



            switch (status.Details.ShipmentStatusCode)
            {
                case "X6":
                    Console.WriteLine("En Route To Destination");
                    break;
                case "D1":
                    Console.WriteLine("Completed Unloading at Delivery Location");
                    break;
                case "AF":
                    Console.WriteLine("Carrier Departed Pick-up Location with Shipment");
                    break;
                case "AP":
                    Console.WriteLine("Delivery Not Completed");
                    break;
                case "X1":
                    Console.WriteLine("Arrived at Delivery Location");
                    break;
                case "X3":
                    Console.WriteLine("Arrived at Pick-up Location");
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
        }


        foreach (var status in detail.BusinessInstructionsAndReferenceNumbers)
            switch (status.ReferenceIdentificationQualifier)
            {
                case "QN":
                    Console.WriteLine("Stop #: " + status.ReferenceIdentification);
                    break;
                case "BM":
                    Console.WriteLine("Detail Bill of Lading Number: " + status.ReferenceIdentification);
                    break;
                case "WH":
                    Console.WriteLine("Detail Master Reference (Link) Number: " + status.ReferenceIdentification);
                    break;
                case "P8":
                    Console.WriteLine("Detail Pickup Reference Number: " + status.ReferenceIdentification);
                    break;
                case "PO":
                    Console.WriteLine("Detail Purchase Order Number: " + status.ReferenceIdentification);
                    break;
                case "SI":
                    Console.WriteLine("Detail Shipper Identifying Number (SID): " + status.ReferenceIdentification);
                    break;
                case "BN":
                    Console.WriteLine("Detail Booking Number: " + status.ReferenceIdentification);
                    break;
                default:
                    Console.WriteLine("Unknown Detail Reference Identifier: " + status.ReferenceIdentificationQualifier);
                    break;
            }

        foreach (var shipmentWeightPackagingAndQuantityData in detail.ShipmentWeightPackagingAndQuantity)
        {
            //https://www.stedi.com/edi/x12-008020/segment/AT8
            var weightUnit = "";
            switch (shipmentWeightPackagingAndQuantityData.WeightUnitCode)
            {
                case "L":
                    weightUnit = "Lbs";
                    break;
                case "K":
                    weightUnit = "Kg";
                    break;
            }

            Console.WriteLine("Weight: " + shipmentWeightPackagingAndQuantityData.Weight + weightUnit);
            Console.WriteLine("Quantity: " + shipmentWeightPackagingAndQuantityData.LadingQuantity);
        }


        Console.WriteLine();
        Console.WriteLine();
    }
}
}
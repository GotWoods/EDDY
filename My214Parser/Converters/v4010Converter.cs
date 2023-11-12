using Eddy.x12.DomainModels.Transportation.v4010;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace My214Parser.Converters;

internal class v4010Converter
{
    public Generic214 Convert(List<EdiX12Segment> segments)
    {
        var result = new Generic214();
        var mapper = new DomainMapper(segments);
        var edi214 = mapper.Map<Edi214_TransportationCarrierShipmentStatusMessage>();

        result.ReferenceIdentification = edi214.BeginningSegmentForTransportationCarrierShipmentStatusMessage.ReferenceIdentification;
        result.ShipmentId = edi214.BeginningSegmentForTransportationCarrierShipmentStatusMessage.ShipmentIdentificationNumber;


        foreach (var detail in edi214.L0200)
        {
            var transaction = new Transaction();

            foreach (var status in detail.L0205)
            {
                var update = new Update();
                //update.EventDate = status.ShipmentStatusDetails.Date + ":" + status.ShipmentStatusDetails.Time;
                if (status.EquipmentShipmentOrRealPropertyLocation != null)
                    update.Location = new Location
                    {
                        City = status.EquipmentShipmentOrRealPropertyLocation.CityName,
                        StateProvinceCode = status.EquipmentShipmentOrRealPropertyLocation.StateOrProvinceCode,
                        CountryCode = status.EquipmentShipmentOrRealPropertyLocation.CountryCode
                    };
                update.StatusCode = status.ShipmentStatusDetails.ShipmentStatusCode;
                if (status.EquipmentOrContainerOwnerAndType != null)
                {
                    var trailerCodes = new List<string> { "TL", "TA", "TB", "TC", "TF", "TG", "TH", "TI", "TJ", "TM", "TP", "TQ", "TT", "TV" };
                    if (trailerCodes.Contains(status.EquipmentOrContainerOwnerAndType.EquipmentDescriptionCode))
                        update.EquipmentNumber = status.EquipmentOrContainerOwnerAndType.EquipmentNumber;
                }

                transaction.Updates.Add(update);
            }


            foreach (var referenceNumber in detail.BusinessInstructionsAndReferenceNumber) transaction.ReferenceNumbers.Add(new Pair(referenceNumber.ReferenceIdentificationQualifier, referenceNumber.ReferenceIdentification));
            foreach (var referenceNumber in detail.MarksAndNumbers) transaction.MarksAndNumbers.Add(new Pair(referenceNumber.MarksAndNumbersQualifier, referenceNumber.MarksAndNumbers));

            //this comes from the high level but after 4010, it does not exist in this location. So we put it all in the transaction space
            foreach (var referenceNumber in edi214.BusinessInstructionsAndReferenceNumber)
                //TODO: make sure the reference number type does not already exist (maybe except for ZZ)
                transaction.ReferenceNumbers.Add(new Pair(referenceNumber.ReferenceIdentificationQualifier, referenceNumber.ReferenceIdentification));

            foreach (var referenceNumber in edi214.MarksAndNumbers)
                //TODO: make sure the type does not already exist (maybe except for ZZ)
                transaction.MarksAndNumbers.Add(new Pair(referenceNumber.MarksAndNumbersQualifier, referenceNumber.MarksAndNumbers));

            //detail.ShipmentWeightPackagingAndQuantityData

            //detail.ShipmentWeightPackagingAndQuantityData[0].
            // foreach (var shipmentWeightPackagingAndQuantityData in detail.L0250)
            // {
            //     //https://www.stedi.com/edi/x12-008020/segment/AT8
            //     var weightUnit = "";
            //     switch (shipmentWeightPackagingAndQuantityData.ShipmentPurchaseOrderDetail.WeightUnitCode)
            //     {
            //         case "L":
            //             weightUnit = "Lbs";
            //             break;
            //         case "K":
            //             weightUnit = "Kg";
            //             break;
            //     }
            //     Console.WriteLine("Weight: " + shipmentWeightPackagingAndQuantityData.ShipmentPurchaseOrderDetail.Weight + weightUnit);
            //     Console.WriteLine("Quantity: " + shipmentWeightPackagingAndQuantityData.ShipmentPurchaseOrderDetail.Quantity);
            // }

            result.Transactions.Add(transaction);
        }

        return result;
    }
}
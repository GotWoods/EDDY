using Eddy.x12.DomainModels.Transportation.v5010;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace My214Parser.Converters;

internal class v5010Converter
{
    public Generic214 Convert(List<EdiX12Segment> segments)
    {
        var result = new Generic214();
        var mapper = new DomainMapper(segments);
        var edi214 = mapper.Map<Edi214_TransportationCarrierShipmentStatusMessage>();

        result.ReferenceIdentification = edi214.BeginningSegmentForTransportationCarrierShipmentStatusMessage.ReferenceIdentification;
        result.ShipmentId = edi214.BeginningSegmentForTransportationCarrierShipmentStatusMessage.ShipmentIdentificationNumber;
      


        foreach (var detail in edi214.L1000)
        {
            var transaction = new Transaction();

            foreach (var status in detail.L1100)
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
                update.StatusCode = status.ShipmentStatusDetails.ShipmentStatusIndicator;
                transaction.Updates.Add(update);
            }

            foreach (var referenceNumber in detail.BusinessInstructionsAndReferenceNumber) 
                transaction.ReferenceNumbers.Add(new Pair(referenceNumber.ReferenceIdentificationQualifier, referenceNumber.ReferenceIdentification));

            foreach (var referenceNumber in detail.MarksAndNumbersInformation)
                transaction.MarksAndNumbers.Add(new Pair(referenceNumber.MarksAndNumbersQualifier, referenceNumber.MarksAndNumbers));

            foreach (var data in detail.ShipmentWeightPackagingAndQuantityData)
            {
                var item = new ShipmentWeightPackagingAndQuantityData();
                if (data.Weight != null)
                    item.Weight = new ItemWithQualifier<decimal?>(data.Weight, data.WeightQualifier);
                if (data.Volume != null)
                    item.Volume = new ItemWithQualifier<decimal?>(data.Volume, data.VolumeUnitQualifier);
                if (data.LadingQuantity != null)
                    item.Quantity = new ItemWithQualifier<int?>(data.LadingQuantity, "");
                transaction.ShipmentWeightPackagingAndQuantityData.Add(item);
            }

            result.Transactions.Add(transaction);
        }

        return result;
    }
}
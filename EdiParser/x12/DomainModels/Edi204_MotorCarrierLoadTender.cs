using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._204;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.DomainModels;

public class Edi204_MotorCarrierLoadTender
{
    [SectionPosition(1)] public B2_BeginningSegmentForShipmentInformationTransaction ShipmentInformation { get; set; } = new();

    [SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; }

    [SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();

    [SectionPosition(4)] public G62_DateTime OrderDate { get; set; }

    [SectionPosition(5)] public MS3_InterlineInformation InterlineInformation { get; set; }

    [SectionPosition(6)] //AT5
    public List<BillOfLadingHandlingInfo> BillOfLadingHandlingInfo { get; set; } = new();

    [SectionPosition(7)] public PLD_PalletShipmentInformation PalletInformation { get; set; }

    [SectionPosition(8)] public List<LH6_HazardousCertification> HazardousCertifications { get; set; } = new();

    [SectionPosition(9)] public List<NTE_Note> Notes { get; set; } = new();

    [SectionPosition(10)] //N1
    public List<Entity> Entities { get; set; } = new();

    [SectionPosition(11)] //N7
    public List<EquipmentDetails> EquipmentDetails { get; set; } = new();


    [SectionPosition(12)] //N5
    public List<StopOffDetails> Stops { get; set; } = new();

    [SectionPosition(13)] public L3_TotalWeightAndCharges Totals { get; set; }

    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "204";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;


        s.Segments.Add(ShipmentInformation);
        s.Segments.Add(SetPurpose);

        //s.Segments.Add(new C3_CurrencyIdentifier());

        foreach (var referenceNumber in ReferenceNumbers)
            s.Segments.Add(referenceNumber);

        if (OrderDate != null)
            s.Segments.Add(OrderDate);
        if (InterlineInformation != null)
            s.Segments.Add(InterlineInformation);

        foreach (var billOfLadingHandlingInfo in BillOfLadingHandlingInfo)
        {
            s.Segments.Add(billOfLadingHandlingInfo.HandlingRequirements);
            s.Segments.Add(billOfLadingHandlingInfo.FreightRateInformation);
            s.Segments.Add(billOfLadingHandlingInfo.Currency);
        }

        //s.Segments.Add(new G62_DateTime());
        //s.Segments.Add(new MS3_InterlineInformation());
        //AT5 loop

        if (PalletInformation != null)
            s.Segments.Add(PalletInformation);

        //TODO LH6

        foreach (var note in Notes) s.Segments.Add(note);

        foreach (var entity in Entities)
        {
            s.Segments.Add(entity.PartyIdentification);

            if (entity.AdditionalNameInformation != null)
                s.Segments.Add(entity.AdditionalNameInformation);

            foreach (var n3PartyLocation in entity.PartyLocation) s.Segments.Add(n3PartyLocation);

            if (entity.GeographicLocation != null)
                s.Segments.Add(entity.GeographicLocation);


            foreach (var contact in entity.Contacts)
                s.Segments.Add(contact);
        }

        foreach (var equipmentDetail in EquipmentDetails)
        {
            s.Segments.Add(equipmentDetail.Details);
            foreach (var equipmentDetailSealNumber in equipmentDetail.SealNumbers)
                s.Segments.Add(equipmentDetailSealNumber);
        }

        foreach (var stop in Stops)
        {
            s.Segments.Add(stop.Detail);

            foreach (var stopReferenceNumber in stop.ReferenceNumbers) s.Segments.Add(stopReferenceNumber);

            foreach (var date in stop.Dates) s.Segments.Add(date);

            if (stop.ShipmentWeightPackagingAndQuantityData != null) s.Segments.Add(stop.ShipmentWeightPackagingAndQuantityData);

            foreach (var stopNote in stop.Notes) s.Segments.Add(stopNote);

            if (stop.Entity != null)
            {
                s.Segments.Add(stop.Entity.PartyIdentification);

                if (stop.Entity.AdditionalNameInformation != null)
                    s.Segments.Add(stop.Entity.AdditionalNameInformation);

                foreach (var partyLocation in stop.Entity.PartyLocation)
                    s.Segments.Add(partyLocation);

                if (stop.Entity.GeographicLocation != null)
                    s.Segments.Add(stop.Entity.GeographicLocation);

                foreach (var contact in stop.Entity.Contacts)
                    s.Segments.Add(contact);
            }

            foreach (var detail in stop.ShipmentDetails)
            {
                s.Segments.Add(detail.DescriptionMarksAndNumbers);
                s.Segments.Add(detail.ShipmentWeightPackagingQuantity);
                //323

                foreach (var shipmentDetailContact in detail.Detail)
                {
                    s.Segments.Add(shipmentDetailContact.Info);
                    //TODO: Reference numbers L11

                    foreach (var certification in shipmentDetailContact.HazardosCertifications) s.Segments.Add(certification);

                    //TODO: this is the same as the orderinfo
                    foreach (var hazMatInfo in shipmentDetailContact.HazMatInfo)
                    {
                        if (hazMatInfo.IdentificationInfo != null)
                            s.Segments.Add(hazMatInfo.IdentificationInfo);
                        foreach (var classificationInformation in hazMatInfo.Classification) s.Segments.Add(classificationInformation);

                        foreach (var shippingNameInformation in hazMatInfo.ShippingName) s.Segments.Add(shippingNameInformation);

                        foreach (var freeFormHazardousMaterialInformation in hazMatInfo.FreeFormInfo) s.Segments.Add(freeFormHazardousMaterialInformation);

                        foreach (var lepEpaRequiredData in hazMatInfo.EpaData) s.Segments.Add(lepEpaRequiredData);


                        if (hazMatInfo.CanadianRequierments != null)
                            s.Segments.Add(hazMatInfo.CanadianRequierments);

                        foreach (var transborderRequirement in hazMatInfo.TransborderRequirements) s.Segments.Add(transborderRequirement);
                    }
                }

                foreach (var referenceNumber in detail.ReferenceNumbers) s.Segments.Add(referenceNumber);

                foreach (var measurement in detail.Measurements) s.Segments.Add(measurement);

                if (detail.Measurement != null)
                    s.Segments.Add(detail.Measurement);
            }

            foreach (var stopDetail in stop.Details)
            {
                s.Segments.Add(stopDetail.Detail);
                foreach (var ladingInformation in stopDetail.LadingInformation) s.Segments.Add(ladingInformation);
                foreach (var orderInformationShipmentData in stopDetail.OrderInformationShipmentData)
                {
                    s.Segments.Add(orderInformationShipmentData.DescriptionMarksAndNumbers);
                    if (orderInformationShipmentData.ShipmentWeightPackagingAndQuantity != null) s.Segments.Add(orderInformationShipmentData.ShipmentWeightPackagingAndQuantity);
                    if (orderInformationShipmentData.Measurement != null) s.Segments.Add(orderInformationShipmentData.Measurement);
                    foreach (var hazMat in orderInformationShipmentData.HazMat)
                    {
                        s.Segments.Add(hazMat.Contact);

                        foreach (var hazMatInfo in hazMat.HazMatInfo)
                        {
                            if (hazMatInfo.IdentificationInfo != null)
                                s.Segments.Add(hazMatInfo.IdentificationInfo);
                            foreach (var classificationInformation in hazMatInfo.Classification) s.Segments.Add(classificationInformation);

                            foreach (var shippingNameInformation in hazMatInfo.ShippingName) s.Segments.Add(shippingNameInformation);

                            foreach (var freeFormHazardousMaterialInformation in hazMatInfo.FreeFormInfo) s.Segments.Add(freeFormHazardousMaterialInformation);

                            foreach (var lepEpaRequiredData in hazMatInfo.EpaData) s.Segments.Add(lepEpaRequiredData);

                            if (hazMatInfo.CanadianRequierments != null)
                                s.Segments.Add(hazMatInfo.CanadianRequierments);

                            foreach (var transborderRequirement in hazMatInfo.TransborderRequirements) s.Segments.Add(transborderRequirement);
                        }
                    }
                }
         
            }
        }

        if (Totals != null)
            s.Segments.Add(Totals);

        return s;
    }

    public void Validate()
    {
        //needs a b2 entry
        //needs a b2a entry
    }
}
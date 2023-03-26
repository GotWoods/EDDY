using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._204;
using EdiParser.x12.Models;

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


    /*
     * list of segments aligns with "some" of these properties. Date needs a convert but others like Entity,EquipmentDetails, StopOffDetails, etc. are a list
     *
     *
     * [CustomMap("G62")] //or could it just have a convertFrom and expect it to be a G62 and do a type check from within?
     * public Date OrderDate { get; set;}
     *
     * [CustomMapList("N1")]
     * public List<Entity> Entities { get; set; } = new();
     */
//
//     public void LoadFrom(Section section)
//     {
//         if (section.SectionType != "204")
//             throw new ArgumentOutOfRangeException("Expected a section type of 204 but was provied a type of " + section.SectionType);
//
//         //TODO: L11/MEA/PER/L4 exists between some loops
//
//
//         var root = new GroupingRule("Root", new[] { "B2", "B2A", "C3", "L11", "G62", "MS3", "PLD", "LH6", "NTE", "L3" }, new List<GroupingRule>
//         {
//             new("BillOfLading", new[] { "AT5", "RTT", "C3" }), //0050
//             new("Parties", new[] { "N1", "N2", "N3", "N4", "L11", "G61" }), //0100
//             new("EquipmentDetails", new[] { "N7", "N7A", "N7B", "MEA", "M7" }), //0200
//             new("StopOffDetails", new[] { "S5", "L11", "G62", "AT8", "LAD", "NTE", "PLD" },
//                 new List<GroupingRule>
//                 {
//                     new("HandlingRequirements", new[] { "AT5", "RTT", "C3" }), //0305
//                     new("StopParties", new[] { "N1", "N2", "N3", "N4", "G61" }), //0310
//                     new("ShipmentDetail", new[] { "L5", "AT8", "L11", "MEA", "L4" }, new List<GroupingRule>() //0320 //TODO: PER code implementation
//                     {
//                         new("OrderDetails", new[] { "AT5", "RTT", "C3" }), //323
//                         new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //325
//                         {
//                             new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //330
//                         })
//                     }),
//                     new("OrderInformationDetail", new[] { "OID", "G62", "LAD" }, new List<GroupingRule>() //0350
//                     {
//                         new("OrderData", new[] { "L5", "AT8", "L4" }, new List<GroupingRule>() //360
//                         {
//                             new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //365
//                             {
//                                 new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //370
//                             })
//                         })
//                     }),
//                     new("OtherEquipmentDetails", new[] { "N7", "N7A", "N7B", "MEA", "M7" }) //0380
//                 }),
//             new("Summary", new[] { "LX", "L4" }) //1000
//         });
//
//
//         var groupReader = new GroupedSectionReader(section, root);
//         var groupedSection = groupReader.Read();
//
//
//         ReadHeader(groupedSection);
//         ReadDetail(groupedSection);
//     }
//
//     private void ReadHeader(Group groupedSection)
//     {
//         foreach (var segment in groupedSection.Segments)
//             switch (segment)
//             {
//                 case B2_BeginningSegmentForShipmentInformationTransaction b2:
//                     ShipmentInformation = b2;
//                     break;
//                 case B2A_SetPurpose b2a:
//                     SetPurpose = b2a;
//                     break;
//                 case G62_DateTime g62:
//                     OrderDate = g62;
//                     break;
//                 case L11_BusinessInstructionsAndReferenceNumber l11:
//                     ReferenceNumbers.Add(l11);
//                     break;
//                 case MS3_InterlineInformation ms3:
//                     InterlineInformation = ms3;
//                     break;
//                 case PLD_PalletShipmentInformation pld:
//                     PalletInformation = pld;
//                     break;
//                 case NTE_Note nte:
//                     Notes.Add(nte);
//                     break;
//                 case L3_TotalWeightAndCharges l3:
//                     Totals = l3;
//                     break;
//             }
//
//
//         foreach (var handling in groupedSection.Children.Where(x => x.Rule.Name == "BillOfLading"))
//         {
//             var bolInfo = new BillOfLadingHandlingInfo();
//             foreach (var segment in handling.Segments)
//                 switch (segment)
//                 {
//                     case AT5_BillOfLadingHandlingRequirements at5:
//                         bolInfo.HandlingRequirements = at5;
//                         break;
//                     case RTT_FreightRateInformation rtt:
//                         bolInfo.FreightRateInformation = rtt;
//                         break;
//                     case C3_CurrencyIdentifier c3:
//                         bolInfo.Currency = c3;
//                         break;
//                 }
//
//             BillOfLadingHandlingInfo.Add(bolInfo);
//         }
//
//         foreach (var party in groupedSection.Children.Where(x => x.Rule.Name == "Parties"))
//         {
//             var entity = new Entity();
//             foreach (var segment in party.Segments)
//                 switch (segment)
//                 {
//                     case N1_PartyIdentification n1:
//                         entity.PartyIdentification = n1;
//                         break;
//                     case N2_AdditionalNameInformation n2:
//                         //additional name is this used?
//                         break;
//                     case N3_PartyLocation n3: //n3 can be here twice so maybe an address3/address4?
//                         entity.PartyLocation.Add(n3);
//                         break;
//                     case N4_GeographicLocation n4:
//                         entity.GeographicLocation = n4;
//                         break;
//                     case L11_BusinessInstructionsAndReferenceNumber l11:
//                         break;
//                     case G61_Contact g61: //there can be 3 of these
// //                        entity.AddContact(g61); //TODO: re-introduce contact
//                         break;
//                 }
//
//             Entities.Add(entity);
//         }
//
//         foreach (var equipmentDetail in groupedSection.Children.Where(x => x.Rule.Name == "EquipmentDetails"))
//         {
//             var details = new EquipmentDetails();
//             foreach (var segment in equipmentDetail.Segments)
//                 switch (segment)
//                 {
//                     case N7_EquipmentDetails n7:
//                         details.Details = n7;
//                         break;
//                     case M7_SealNumbers m7:
//                         details.SealNumbers.Add(m7);
//                         break;
//                 }
//
//             EquipmentDetails.Add(details);
//         }
//     }
//
//     private void ReadDetail(Group groupedSection)
//     {
//         //StopOffDetails
//         // new("HandlingRequirements", new[] { "AT5", "RTT", "C3" }), //0305
//         // new("StopParties", new[] { "N1", "N2", "N3", "N4", "G61" }), //0310
//         // new("ShipmentDetail", new[] { "L5", "AT8", "L11", "MEA", "L4" }, new List<GroupingRule>() //0320 //TODO: PER code implementation
//         // {
//         //     new("OrderDetails", new[] { "AT5", "RTT", "C3" }), //323
//         //     new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //325
//         //     {
//         //         new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //330
//         //     })
//         // }),
//         // new("OrderInformationDetail", new[] { "OID", "G62", "LAD" }, new List<GroupingRule>() //0350
//         // {
//         //     new("OrderData", new[] { "L5", "AT8", "L4" }, new List<GroupingRule>() //360
//         //     {
//         //         new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //365
//         //         {
//         //             new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //370
//         //         })
//         //     })
//         // }),
//         // new("OtherEquipmentDetails", new[] { "N7", "N7A", "N7B", "MEA", "M7" }) //0380
//
//
//         foreach (var stopSegment in groupedSection.Children.Where(x => x.Rule.Name == "StopOffDetails"))
//         {
//             var stop = new StopOffDetails();
//             foreach (var segment in stopSegment.Segments)
//                 switch (segment)
//                 {
//                     case S5_StopOffDetails s5:
//                         stop.Detail = s5;
//                         break;
//                     case L11_BusinessInstructionsAndReferenceNumber l11:
//                         stop.ReferenceNumbers.Add(l11);
//                         break;
//                     case G62_DateTime g62:
//                         stop.Dates.Add(g62);
//                         break;
//                     case NTE_Note nte:
//                         stop.Notes.Add(nte);
//                         break;
//                     case AT8_ShipmentWeightPackagingAndQuantityData at8:
//                         stop.ShipmentWeightPackagingAndQuantityData = at8;
//                         break;
//                 }
//
//             //var handlingRequirements= stopSegment.Children.FirstOrDefault(x => x.Rule.Name == "HandlingRequirements");
//
//             var partyGroup = stopSegment.Children.FirstOrDefault(x => x.Rule.Name == "StopParties");
//             if (partyGroup != null)
//             {
//                 var entity = new Entity();
//                 foreach (var segment in partyGroup.Segments)
//                     switch (segment)
//                     {
//                         case N1_PartyIdentification n1:
//                             entity.PartyIdentification = n1;
//                             break;
//                         case N2_AdditionalNameInformation n2:
//                             entity.AdditionalNameInformation = n2;
//                             break;
//                         case N3_PartyLocation n3:
//                             entity.PartyLocation.Add(n3);
//                             break;
//                         case N4_GeographicLocation n4:
//                             entity.GeographicLocation = n4;
//                             break;
//                         case L11_BusinessInstructionsAndReferenceNumber l11:
//                             break;
//                         case G61_Contact g61: //there can be 3 of these
//                             entity.Contacts.Add(g61);
//                             break;
//                     }
//
//                 stop.Entity = entity;
//             }
//
//             //started by an L5
//             foreach (var shipmentData in stopSegment.Children.Where(x => x.Rule.Name == "ShipmentDetail"))
//                 stop.ShipmentDetails.Add(ProcessShipmentInformationDetail(shipmentData));
//
//             //started by an OID
//             // foreach (var orderInfo in stopSegment.Children.Where(x => x.Rule.Name == "OrderInformationDetail")) 
//             //     stop.Details.Add(ProcessOrderInformationDetail(orderInfo));
//
//             //var otherEquipmentDetails = stopSegment.Children.FirstOrDefault(x=>x.Rule.Name== "OtherEquipmentDetails")
//             Stops.Add(stop);
//         }
//     }
//
//     private ShipmentInformationDetail ProcessShipmentInformationDetail(Group shipmentData)
//     {
//         // new("ShipmentDetail", new[] { "L5", "AT8", "L11", "MEA", "L4" }, new List<GroupingRule>() //0320 //TODO: PER code implementation
//         // {
//         //     new("OrderDetails", new[] { "AT5", "RTT", "C3" }), //323
//         //     new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //325
//         //     {
//         //         new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //330
//         //     })
//         // }),
//
//         var detail = new ShipmentInformationDetail();
//         foreach (var segment in shipmentData.Segments)
//             switch (segment)
//             {
//                 case L5_DescriptionMarksAndNumbers l5:
//                     detail.DescriptionMarksAndNumbers = l5;
//                     break;
//                 case AT8_ShipmentWeightPackagingAndQuantityData at8:
//                     detail.ShipmentWeightPackagingQuantity = at8;
//                     break;
//                 case L11_BusinessInstructionsAndReferenceNumber l11:
//                     detail.ReferenceNumbers.Add(l11);
//                     break;
//                 case MEA_Measurements mea:
//                     detail.Measurements.Add(mea);
//                     break;
//                 case L4_Measurement l4:
//                     detail.Measurement = l4;
//                     break;
//             }
//
//         //TODO: this is pretty the same as the OrderDetails
//         foreach (var contactGroup in shipmentData.Children.Where(x => x.Rule.Name == "Contact"))
//         {
//             var contact = new ShipmentDetailContact();
//             foreach (var contactSegment in contactGroup.Segments)
//                 switch (contactSegment)
//                 {
//                     case G61_Contact g61:
//                         contact.Info = g61;
//                         break;
//                     case L11_BusinessInstructionsAndReferenceNumber l11:
//                         break;
//                     case LH6_HazardousCertification lh6:
//                         break;
//                 }
//
//             foreach (var hazMatGroup in contactGroup.Children.Where(x => x.Rule.Name == "HazMat"))
//             {
//                 var hazMatInfo = new HazMatInfo();
//                 foreach (var hazMatSegment in hazMatGroup.Segments)
//                     switch (hazMatSegment)
//                     {
//                         case LH1_HazardousIdentificationInformation lh1:
//                             hazMatInfo.IdentificationInfo = lh1;
//                             break;
//                         case LH2_HazardousClassificationInformation lh2:
//                             hazMatInfo.Classification.Add(lh2);
//                             break;
//                         case LH3_HazardousMaterialShippingNameInformation lh3:
//                             hazMatInfo.ShippingName.Add(lh3);
//                             break;
//                         case LFH_FreeFormHazardousMaterialInformation lfh:
//                             hazMatInfo.FreeFormInfo.Add(lfh);
//                             break;
//                         case LEP_EPARequiredData lep:
//                             hazMatInfo.EpaData.Add(lep);
//                             break;
//                         case LH4_CanadianDangerousRequirements lh4:
//                             hazMatInfo.CanadianRequierments = lh4;
//                             break;
//                         case LHT_TransborderHazardousRequirements lht:
//                             hazMatInfo.TransborderRequirements.Add(lht);
//                             break;
//                     }
//
//                 contact.HazMatInfo.Add(hazMatInfo);
//             }
//
//             detail.Detail.Add(contact);
//         }
//
//         return detail;
//     }
//
//     private OrderInformationDetail ProcessOrderInformationDetail(Group orderInfo)
//     {
//         var detail = new OrderInformationDetail();
//
//         foreach (var segment in orderInfo.Segments)
//             switch (segment)
//             {
//                 case OID_OrderInformationDetail oid:
//                     detail.Summary = oid;
//                     break;
//                 case G62_DateTime g62:
//                     break;
//                 case LAD_LadingDetail lad: //this looks to mirror the OID but use different codes, it can repeat though
//                     detail.LadingInformation.Add(lad);
//                     break;
//             }
//
//         foreach (var l5Group in orderInfo.Children.Where(x => x.Rule.Name == "OrderData"))
//         {
//             var orderDetail = new OrderDetail();
//             foreach (var segment in l5Group.Segments)
//                 switch (segment)
//                 {
//                     case L5_DescriptionMarksAndNumbers l5:
//                         orderDetail.DescriptionMarksAndNumbers = l5;
//                         break;
//                     case AT8_ShipmentWeightPackagingAndQuantityData at8:
//                         orderDetail.ShipmentWeightPackagingAndQuantityData = at8;
//                         break;
//                 }
//
//             //G61 group
//             foreach (var contactGroup in l5Group.Children.Where(x => x.Rule.Name == "Contact"))
//             {
//                 var contact = new ShipmentDetailContact();
//                 foreach (var contactSegment in contactGroup.Segments)
//                     switch (contactSegment)
//                     {
//                         case G61_Contact g61:
//                             contact.Info = g61;
//                             break;
//                         case L11_BusinessInstructionsAndReferenceNumber l11:
//                             break;
//                         case LH6_HazardousCertification lh6:
//                             break;
//                     }
//
//                 foreach (var hazMatGroup in contactGroup.Children.Where(x => x.Rule.Name == "HazMat"))
//                 {
//                     var hazMatInfo = new HazMatInfo();
//                     foreach (var hazMatSegment in hazMatGroup.Segments)
//                         switch (hazMatSegment)
//                         {
//                             case LH1_HazardousIdentificationInformation lh1:
//                                 hazMatInfo.IdentificationInfo = lh1;
//                                 break;
//                             case LH2_HazardousClassificationInformation lh2:
//                                 hazMatInfo.Classification.Add(lh2);
//                                 break;
//                             case LH3_HazardousMaterialShippingNameInformation lh3:
//                                 hazMatInfo.ShippingName.Add(lh3);
//                                 break;
//                             case LFH_FreeFormHazardousMaterialInformation lfh:
//                                 hazMatInfo.FreeFormInfo.Add(lfh);
//                                 break;
//                             case LEP_EPARequiredData lep:
//                                 hazMatInfo.EpaData.Add(lep);
//                                 break;
//                             case LH4_CanadianDangerousRequirements lh4:
//                                 hazMatInfo.CanadianRequierments = lh4;
//                                 break;
//                             case LHT_TransborderHazardousRequirements lht:
//                                 hazMatInfo.TransborderRequirements.Add(lht);
//                                 break;
//                         }
//
//                     contact.HazMatInfo.Add(hazMatInfo);
//                 }
//
//                 orderDetail.Contacts.Add(contact);
//             }
//
//             detail.OrderDetails.Add(orderDetail);
//         }
//
//         return detail;
//     }


    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "204";
        s.TransactionSetControlNumber = transactionSetControlNumber;
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
                    foreach (var hazMatInfo in orderInformationShipmentData.HazMatInfo)
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
                // foreach (var detail in stopDetail.OrderDetails)
                // {
                //     s.Segments.Add(detail.DescriptionMarksAndNumbers);
                //     s.Segments.Add(detail.ShipmentWeightPackagingAndQuantityData);
                //     
                //     foreach (var contact in detail.Contacts)
                //     {
                //         s.Segments.Add(contact.Info);
                //         foreach (var hazMatInfo in contact.HazMatInfo)
                //         {
                //             if (hazMatInfo.IdentificationInfo != null)    
                //                 s.Segments.Add(hazMatInfo.IdentificationInfo);
                //             foreach (var classificationInformation in hazMatInfo.Classiciation)
                //             {
                //                 s.Segments.Add(classificationInformation);
                //             }
                //
                //             foreach (var shippingNameInformation in hazMatInfo.ShippingName)
                //             {
                //                 s.Segments.Add(shippingNameInformation);
                //             }
                //
                //             foreach (var freeFormHazardousMaterialInformation in hazMatInfo.FreeFormInfo)
                //             {
                //                 s.Segments.Add(freeFormHazardousMaterialInformation);
                //             }
                //
                //             foreach (var lepEpaRequiredData in hazMatInfo.EpaData)
                //             {
                //                 s.Segments.Add(lepEpaRequiredData);
                //             }
                //
                //
                //             if (hazMatInfo.CanadianRequierments != null)
                //                 s.Segments.Add(hazMatInfo.CanadianRequierments);
                //
                //             foreach (var transborderRequirement in hazMatInfo.TransborderRequirements)
                //             {
                //                 s.Segments.Add(transborderRequirement);
                //             }
                //         }
                //
                //         
                //     }
                // }
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
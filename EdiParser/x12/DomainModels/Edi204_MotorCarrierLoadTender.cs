using System;
using System.Collections.Generic;
using System.Linq;
using EdiParser.x12.DomainModels._204;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;
using static System.String;

namespace EdiParser.x12.DomainModels;

public class Edi204_MotorCarrierLoadTender
{
    //public string CarrierStandardCarrierAlphaCode { get; set; }
    //public string ShipmentIdentificationNumber { get; set; }
    //public string ShipmentMethodOfPaymentCode { get; set; }
    public Date OrderDate { get; set; }
    public string Purpose { get; set; }


    public List<Entity> Entities { get; set; } = new();
    public List<StopOffDetails> Stops { get; set; } = new();
    public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();
    public List<EquipmentDetails> EquipmentDetails { get; set; } = new();
    public InterlineInformation InterlineInformation { get; set; }
    public List<NTE_Note> Notes { get; set; } = new();
    public List<BillOfLadingHandlingInfo> BillOfLadingHandlingInfo { get; set; } = new();
    public L3_TotalWeightAndCharges Totals { get; set; }
    public B2_BeginningSegmentForShipmentInformationTransaction ShipmentInformation { get; set; } = new();

    public string ApplicationType { get; set; }

    public PLD_PalletShipmentInformation PalletInformation { get; set; }

    //public string ShipmentWeightCode { get; set; }

    //public string PaymentMethodCode { get; set; }

    private void ReadHeader(Group groupedSection)
    {
        foreach (var segment in groupedSection.Segments)
            switch (segment)
            {
                case B2_BeginningSegmentForShipmentInformationTransaction b2:
                    ShipmentInformation = b2;
                    break;
                case B2A_SetPurpose b2a:
                    Purpose = b2a.TransactionSetPurposeCode;
                    ApplicationType = b2a.ApplicationTypeCode;
                    break;
                case G62_DateTime g62:
                    OrderDate = Date.From(g62);
                    break;
                case L11_BusinessInstructionsAndReferenceNumber l11:
                    ReferenceNumbers.Add(l11);
                    break;
                case MS3_InterlineInformation ms3:
                    InterlineInformation = InterlineInformation.FromMS3(ms3);
                    break;
                case PLD_PalletShipmentInformation pld:
                    PalletInformation = pld;
                    break;
                case NTE_Note nte:
                    Notes.Add(nte);
                    break;
                case L3_TotalWeightAndCharges l3:
                    Totals = l3;
                    break;
            }


        foreach (var handling in groupedSection.Children.Where(x => x.Rule.Name == "BillOfLading"))
        {
            var bolInfo = new BillOfLadingHandlingInfo();
            foreach (var segment in handling.Segments)
                switch (segment)
                {
                    case AT5_BillOfLadingHandlingRequirements at5:
                        bolInfo.HandlingRequirements = at5;
                        break;
                    case RTT_FreightRateInformation rtt:
                        bolInfo.FreightRateInformation = rtt;
                        break;
                    case C3_CurrencyIdentifier c3:
                        bolInfo.Currency = c3;
                        break;
                }

            BillOfLadingHandlingInfo.Add(bolInfo);
        }

        foreach (var party in groupedSection.Children.Where(x => x.Rule.Name == "Parties"))
        {
            var entity = new Entity();
            foreach (var segment in party.Segments)
                switch (segment)
                {
                    case N1_PartyIdentification n1:
                        entity.EntityIdentifierCode = n1.EntityIdentifierCode;
                        entity.Name = n1.Name;
                        entity.IdentificationCodeQualifier = n1.IdentificationCodeQualifier;
                        entity.IdentificationCode = n1.IdentificationCode;
                        break;
                    case N2_AdditionalNameInformation n2:
                        //additional name is this used?
                        break;
                    case N3_PartyLocation n3: //n3 can be here twice so maybe an address3/address4?
                        entity.Add(n3);
                        break;
                    case N4_GeographicLocation n4:
                        entity.City = n4.CityName;
                        entity.ProvinceState = n4.StateOrProvinceCode;
                        entity.Country = n4.CountryCode;
                        entity.PostalZip = n4.PostalCode;
                        break;
                    case L11_BusinessInstructionsAndReferenceNumber l11:
                        break;
                    case G61_Contact g61: //there can be 3 of these
                        entity.AddContact(g61);
                        break;
                }

            Entities.Add(entity);
        }

        foreach (var equipmentDetail in groupedSection.Children.Where(x => x.Rule.Name == "EquipmentDetails"))
        {
            var details = new EquipmentDetails();
            foreach (var segment in equipmentDetail.Segments)
                switch (segment)
                {
                    case N7_EquipmentDetails n7:
                        details.LineData = n7;
                        break;
                    case M7_SealNumbers m7:
                        details.SealNumbers.Add(m7.SealNumber);
                        if (!IsNullOrWhiteSpace(m7.SealNumber2))
                            details.SealNumbers.Add(m7.SealNumber2);
                        if (!IsNullOrWhiteSpace(m7.SealNumber3))
                            details.SealNumbers.Add(m7.SealNumber3);
                        if (!IsNullOrWhiteSpace(m7.SealNumber4))
                            details.SealNumbers.Add(m7.SealNumber4);
                        break;
                }

            EquipmentDetails.Add(details);
        }
    }


    public void LoadFrom(Section section)
    {
        if (section.SectionType != "204")
            throw new ArgumentOutOfRangeException("Expected a section type of 204 but was provied a type of " + section.SectionType);

        //TODO: L11/MEA/PER/L4 exists between some loops
        var root = new GroupingRule("Root", new[] { "B2", "B2A", "C3", "L11", "G62", "MS3", "PLD", "LH6", "NTE", "L3" }, new List<GroupingRule>
        {
            new("BillOfLading", new[] { "AT5", "RTT", "C3" }), //0050
            new("Parties", new[] { "N1", "N2", "N3", "N4", "L11", "G61" }), //0100
            new("EquipmentDetails", new[] { "N7", "N7A", "N7B", "MEA", "M7" }), //0200
            new("StopOffDetails", new[] { "S5", "L11", "G62", "AT8", "LAD", "NTE", "PLD" },
                new List<GroupingRule>
                {
                    new("HandlingRequirements", new[] { "AT5", "RTT", "C3" }), //0305
                    new("StopParties", new[] { "N1", "N2", "N3", "N4", "G61" }), //0310
                    new("ShipmentDetail", new[] { "L5", "AT8", "L11", "MEA", "L4" }, new List<GroupingRule>() //0320 //TODO: PER code implementation
                    {
                        new("OrderDetails", new[] { "AT5", "RTT", "C3" }), //323
                        new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //325
                        {
                            new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //330
                        })
                    }),
                    new("OrderInformationDetail", new[] { "OID", "G62", "LAD" }, new List<GroupingRule>() //0350
                    {
                        new("OrderData", new[] { "L5", "AT8", "L4" }, new List<GroupingRule>() //360
                        {
                            new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //365
                            {
                                new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //370
                            })
                        })
                    }),
                    new("OtherEquipmentDetails", new[] { "N7", "N7A", "N7B", "MEA", "M7" }) //0380
                }),
            new("Summary", new[] { "LX", "L4" }) //1000
        });


        var groupReader = new GroupedSectionReader(section);
        var groupedSection = groupReader.Read(root);


        ReadHeader(groupedSection);
        ReadDetail(groupedSection);
    }

    private void ReadDetail(Group groupedSection)
    {
        //StopOffDetails
        // new("HandlingRequirements", new[] { "AT5", "RTT", "C3" }), //0305
        // new("StopParties", new[] { "N1", "N2", "N3", "N4", "G61" }), //0310
        // new("ShipmentDetail", new[] { "L5", "AT8", "L11", "MEA", "L4" }, new List<GroupingRule>() //0320 //TODO: PER code implementation
        // {
        //     new("OrderDetails", new[] { "AT5", "RTT", "C3" }), //323
        //     new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //325
        //     {
        //         new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //330
        //     })
        // }),
        // new("OrderInformationDetail", new[] { "OID", "G62", "LAD" }, new List<GroupingRule>() //0350
        // {
        //     new("OrderData", new[] { "L5", "AT8", "L4" }, new List<GroupingRule>() //360
        //     {
        //         new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //365
        //         {
        //             new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //370
        //         })
        //     })
        // }),
        // new("OtherEquipmentDetails", new[] { "N7", "N7A", "N7B", "MEA", "M7" }) //0380


        foreach (var stopSegment in groupedSection.Children.Where(x => x.Rule.Name == "StopOffDetails"))
        {
            var stop = new StopOffDetails();
            foreach (var segment in stopSegment.Segments)
                switch (segment)
                {
                    case S5_StopOffDetails s5:
                        stop.WeightUnitCode = s5.WeightUnitCode;
                        stop.StopSequenceNumber = s5.StopSequenceNumber;
                        stop.StopReasonCode = s5.StopReasonCode;
                        stop.Weight = s5.Weight;
                        stop.WeightUnitCode = s5.WeightUnitCode;
                        stop.NumberOfUnitsShipped = s5.NumberOfUnitsShipped;
                        stop.UnitOrBasisForMeasurementCode = s5.UnitOrBasisForMeasurementCode;
                        stop.Volume = s5.Volume;
                        stop.VolumeUnitQualifier = s5.VolumeUnitQualifier;
                        stop.Description = s5.Description;
                        stop.StandardPointLocationCode = s5.StandardPointLocationCode;
                        stop.AccomplishCode = s5.AccomplishCode;
                        break;
                    case L11_BusinessInstructionsAndReferenceNumber l11:
                        stop.ReferenceNumbers.Add(new KeyValuePair<string, string>(l11.ReferenceIdentificationQualifier, l11.ReferenceIdentification));
                        break;
                    case G62_DateTime g62:
                        stop.Dates.Add(Date.From(g62));
                        break;
                    case NTE_Note nte:
                        stop.Notes.Add(new Note { Description = nte.Description, ReferenceCode = nte.NoteReferenceCode });
                        break;
                    case AT8_ShipmentWeightPackagingAndQuantityData at8:
                        stop.ShipmentWeightPackagingAndQuantityData = at8;
                        break;
                }

            //var handlingRequirements= stopSegment.Children.FirstOrDefault(x => x.Rule.Name == "HandlingRequirements");

            var partyGroup = stopSegment.Children.FirstOrDefault(x => x.Rule.Name == "StopParties");
            if (partyGroup != null)
            {
                var entity = new Entity();
                foreach (var segment in partyGroup.Segments)
                    switch (segment)
                    {
                        case N1_PartyIdentification n1:
                            entity.EntityIdentifierCode = n1.EntityIdentifierCode;
                            entity.Name = n1.Name;
                            entity.IdentificationCodeQualifier = n1.IdentificationCodeQualifier;
                            entity.IdentificationCode = n1.IdentificationCode;
                            break;
                        case N2_AdditionalNameInformation n2:
                            //additional name is this used?
                            break;
                        case N3_PartyLocation n3:
                            entity.Add(n3);
                            break;
                        case N4_GeographicLocation n4:
                            entity.City = n4.CityName;
                            entity.ProvinceState = n4.StateOrProvinceCode;
                            entity.Country = n4.CountryCode;
                            entity.PostalZip = n4.PostalCode;
                            break;
                        case L11_BusinessInstructionsAndReferenceNumber l11:
                            break;
                        case G61_Contact g61: //there can be 3 of these
                            entity.AddContact(g61);
                            break;
                    }

                stop.Entity = entity;
            }

            //started by an L5
            foreach (var shipmentData in stopSegment.Children.Where(x => x.Rule.Name == "ShipmentDetail")) 
                stop.ShipmentDetails.Add(ProcessShipmentInformationDetail(shipmentData));

            //started by an OID
            foreach (var orderInfo in stopSegment.Children.Where(x => x.Rule.Name == "OrderInformationDetail")) 
                stop.Details.Add(ProcessOrderInformationDetail(orderInfo));

            //var otherEquipmentDetails = stopSegment.Children.FirstOrDefault(x=>x.Rule.Name== "OtherEquipmentDetails")
            Stops.Add(stop);
        }
    }

    private ShipmentInformationDetail ProcessShipmentInformationDetail(Group shipmentData)
    {
        // new("ShipmentDetail", new[] { "L5", "AT8", "L11", "MEA", "L4" }, new List<GroupingRule>() //0320 //TODO: PER code implementation
        // {
        //     new("OrderDetails", new[] { "AT5", "RTT", "C3" }), //323
        //     new("Contact", new[] { "G61", "L11", "LH6" }, new List<GroupingRule>() //325
        //     {
        //         new("HazMat", new[] { "LH1", "LH2", "LH3", "LFH", "LEP", "LH4", "LHT" }) //330
        //     })
        // }),

        var detail = new ShipmentInformationDetail();
        foreach (var segment in shipmentData.Segments)
            switch (segment)
            {
                case L5_DescriptionMarksAndNumbers l5:
                    detail.DescriptionMarksAndNumbers = l5;
                    break;
                case AT8_ShipmentWeightPackagingAndQuantityData at8:
                    detail.ShipmentWeightPackagingQuantity = at8;
                    break;
                case L11_BusinessInstructionsAndReferenceNumber l11:
                    detail.ReferenceNumbers.Add(l11);
                    break;
                case MEA_Measurements mea:
                    detail.Measurements.Add(mea);
                    break;
                case L4_Measurement l4:
                    detail.Measuresment = l4;
                    break;
            }

        //TODO: this is pretty the same as the OrderDetails
        foreach (var contactGroup in shipmentData.Children.Where(x=>x.Rule.Name == "Contact"))
        {
            var contact = new ShipmentDetailContact();
            foreach (var contactSegment in contactGroup.Segments)
                switch (contactSegment)
                {
                    case G61_Contact g61:
                        contact.Info = g61;
                        break;
                    case L11_BusinessInstructionsAndReferenceNumber l11:
                        break;
                    case LH6_HazardousCertification lh6:
                        break;
                }

            foreach (var hazMatGroup in contactGroup.Children.Where(x => x.Rule.Name == "HazMat"))
            {
                var hazMatInfo = new HazMatInfo();
                foreach (var hazMatSegment in hazMatGroup.Segments)
                {
                    switch (hazMatSegment)
                    {
                        case LH1_HazardousIdentificationInformation lh1:
                            hazMatInfo.IdentificationInfo = lh1;
                            break;
                        case LH2_HazardousClassificationInformation lh2:
                            hazMatInfo.Classiciation.Add(lh2);
                            break;
                        case LH3_HazardousMaterialShippingNameInformation lh3:
                            hazMatInfo.ShippingName.Add(lh3);
                            break;
                        case LFH_FreeFormHazardousMaterialInformation lfh:
                            hazMatInfo.FreeFormInfo.Add(lfh);
                            break;
                        case LEP_EPARequiredData lep:
                            hazMatInfo.EpaData.Add(lep);
                            break;
                        case LH4_CanadianDangerousRequirements lh4:
                            hazMatInfo.CanadianRequierments = lh4;
                            break;
                        case LHT_TransborderHazardousRequirements lht:
                            hazMatInfo.TransborderRequirements.Add(lht);
                            break;
                    }
                }
                contact.HazMatInfo.Add(hazMatInfo);
            }

            detail.Detail.Add(contact);
        }
        return detail;
       

    }

    private OrderInformationDetail ProcessOrderInformationDetail(Group orderInfo)
    {
        var detail = new OrderInformationDetail();

        foreach (var segment in orderInfo.Segments)
            switch (segment)
            {
                case OID_OrderInformationDetail oid:
                    detail.Summary = oid;
                    break;
                case G62_DateTime g62:
                    break;
                case LAD_LadingDetail lad: //this looks to mirror the OID but use different codes, it can repeat though
                    detail.LadingInformation.Add(LadingInformation.FromLAD(lad));
                    break;
            }

        foreach (var l5Group in orderInfo.Children.Where(x => x.Rule.Name == "OrderData"))
        {
            var orderDetail = new OrderDetail();
            foreach (var segment in l5Group.Segments)
                switch (segment)
                {
                    case L5_DescriptionMarksAndNumbers l5:
                        orderDetail.DescriptionMarksAndNumbers = l5;
                        break;
                    case AT8_ShipmentWeightPackagingAndQuantityData at8:
                        orderDetail.ShipmentWeightPackagingAndQuantityData = at8;
                        break;
                }

            //G61 group
            foreach (var contactGroup in l5Group.Children.Where(x => x.Rule.Name == "Contact"))
            {
                var contact = new ShipmentDetailContact();
                foreach (var contactSegment in contactGroup.Segments)
                    switch (contactSegment)
                    {
                        case G61_Contact g61:
                            contact.Info = g61;
                            break;
                        case L11_BusinessInstructionsAndReferenceNumber l11:
                            break;
                        case LH6_HazardousCertification lh6:
                            break;
                    }

                foreach (var hazMatGroup in contactGroup.Children.Where(x=>x.Rule.Name== "HazMat"))
                {
                    var hazMatInfo = new HazMatInfo();
                    foreach (var hazMatSegment in hazMatGroup.Segments)
                    {
                        switch (hazMatSegment)
                        {
                            case LH1_HazardousIdentificationInformation lh1:
                                hazMatInfo.IdentificationInfo = lh1;
                                break;
                            case LH2_HazardousClassificationInformation lh2:
                                hazMatInfo.Classiciation.Add(lh2);
                                break;
                            case LH3_HazardousMaterialShippingNameInformation lh3:
                                hazMatInfo.ShippingName.Add(lh3);
                                break;
                            case LFH_FreeFormHazardousMaterialInformation lfh:
                                hazMatInfo.FreeFormInfo.Add(lfh);
                                break;
                            case LEP_EPARequiredData lep:
                                hazMatInfo.EpaData.Add(lep);
                                break;
                            case LH4_CanadianDangerousRequirements lh4:
                                hazMatInfo.CanadianRequierments = lh4;
                                break;
                            case LHT_TransborderHazardousRequirements lht:
                                hazMatInfo.TransborderRequirements.Add(lht);
                                break;
                        }
                    }
                    contact.HazMatInfo.Add(hazMatInfo);
                }

                orderDetail.Contacts.Add(contact);
            }

            detail.OrderDetails.Add(orderDetail);
        }

        return detail;
    }


    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "204";
        s.TransactionSetControlNumber = transactionSetControlNumber;
        s.Segments.Add(ShipmentInformation);

        s.Segments.Add(new B2A_SetPurpose
        {
            TransactionSetPurposeCode = Purpose,
            ApplicationTypeCode = ApplicationType
        });

        //s.Segments.Add(new C3_CurrencyIdentifier());

        foreach (var referenceNumber in ReferenceNumbers) s.Segments.Add(referenceNumber);

        if (OrderDate != null)
            s.Segments.Add(OrderDate.ToG62());
        if (InterlineInformation != null)
            s.Segments.Add(InterlineInformation.ToMS3());

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
            var n1 = new N1_PartyIdentification
            {
                Name = entity.Name,
                EntityIdentifierCode = entity.EntityIdentifierCode,
                IdentificationCodeQualifier = entity.IdentificationCodeQualifier,
                IdentificationCode = entity.IdentificationCode
            };
            s.Segments.Add(n1);

            //TODO: N2
            var n2 = new N2_AdditionalNameInformation();

            if (!IsNullOrEmpty(entity.Address1) || !IsNullOrEmpty(entity.Address2))
            {
                var n3 = new N3_PartyLocation
                {
                    AddressInformation = entity.Address1,
                    AddressInformation2 = entity.Address2
                };
                s.Segments.Add(n3);
            }

            if (!IsNullOrEmpty(entity.Address3) || !IsNullOrEmpty(entity.Address4))
            {
                var n3 = new N3_PartyLocation
                {
                    AddressInformation = entity.Address3,
                    AddressInformation2 = entity.Address4
                };
                s.Segments.Add(n3);
            }

            if (!IsNullOrEmpty(entity.City) || !IsNullOrEmpty(entity.Country) || !IsNullOrEmpty(entity.PostalZip) || !IsNullOrEmpty(entity.ProvinceState))
            {
                var n4 = new N4_GeographicLocation
                {
                    CityName = entity.City,
                    CountryCode = entity.Country,
                    PostalCode = entity.PostalZip,
                    StateOrProvinceCode = entity.ProvinceState
                };
                s.Segments.Add(n4);
            }

            foreach (var contact in entity.Contacts) s.Segments.Add(contact.ToG61());
        }

        foreach (var equipmentDetail in EquipmentDetails)
        {
            s.Segments.Add(equipmentDetail.LineData);
            foreach (var equipmentDetailSealNumber in equipmentDetail.SealNumbers) s.Segments.Add(new M7_SealNumbers { SealNumber = equipmentDetailSealNumber });
        }

        foreach (var stop in Stops)
        {
            s.Segments.Add(new S5_StopOffDetails
            {
                StopSequenceNumber = stop.StopSequenceNumber,
                StopReasonCode = stop.StopReasonCode,
                Weight = stop.Weight,
                WeightUnitCode = stop.WeightUnitCode,
                NumberOfUnitsShipped = stop.NumberOfUnitsShipped,
                UnitOrBasisForMeasurementCode = stop.UnitOrBasisForMeasurementCode,
                Volume = stop.Volume,
                VolumeUnitQualifier = stop.VolumeUnitQualifier,
                Description = stop.Description,
                StandardPointLocationCode = stop.StandardPointLocationCode,
                AccomplishCode = stop.AccomplishCode
            });

            foreach (var stopReferenceNumber in stop.ReferenceNumbers) s.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = stopReferenceNumber.Value, ReferenceIdentificationQualifier = stopReferenceNumber.Key });

            foreach (var date in stop.Dates) s.Segments.Add(date.ToG62());

            if (stop.ShipmentWeightPackagingAndQuantityData != null) s.Segments.Add(stop.ShipmentWeightPackagingAndQuantityData);

            foreach (var stopNote in stop.Notes) s.Segments.Add(new NTE_Note { Description = stopNote.Description, NoteReferenceCode = stopNote.ReferenceCode });

            if (stop.Entity != null)
            {
                var n1 = new N1_PartyIdentification
                {
                    Name = stop.Entity.Name,
                    EntityIdentifierCode = stop.Entity.EntityIdentifierCode,
                    IdentificationCodeQualifier = stop.Entity.IdentificationCodeQualifier,
                    IdentificationCode = stop.Entity.IdentificationCode
                };
                s.Segments.Add(n1);

                //TODO: N2
                var n2 = new N2_AdditionalNameInformation();
                s.Segments.Add(new N3_PartyLocation
                {
                    AddressInformation = stop.Entity.Address1,
                    AddressInformation2 = stop.Entity.Address2
                });

                if (stop.Entity.Address3 != null)
                    s.Segments.Add(new N3_PartyLocation
                    {
                        AddressInformation = stop.Entity.Address3,
                        AddressInformation2 = stop.Entity.Address4
                    });

                s.Segments.Add(new N4_GeographicLocation
                {
                    CityName = stop.Entity.City,
                    CountryCode = stop.Entity.Country,
                    PostalCode = stop.Entity.PostalZip,
                    StateOrProvinceCode = stop.Entity.ProvinceState
                });

                foreach (var contact in stop.Entity.Contacts) s.Segments.Add(contact.ToG61());
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

                    foreach (var certification in shipmentDetailContact.HazardosCertifications)
                    {
                        s.Segments.Add(certification);
                    }

                    //TODO: this is the same as the orderinfo
                    foreach (var hazMatInfo in shipmentDetailContact.HazMatInfo)
                    {
                        if (hazMatInfo.IdentificationInfo != null)
                            s.Segments.Add(hazMatInfo.IdentificationInfo);
                        foreach (var classificationInformation in hazMatInfo.Classiciation)
                        {
                            s.Segments.Add(classificationInformation);
                        }

                        foreach (var shippingNameInformation in hazMatInfo.ShippingName)
                        {
                            s.Segments.Add(shippingNameInformation);
                        }

                        foreach (var freeFormHazardousMaterialInformation in hazMatInfo.FreeFormInfo)
                        {
                            s.Segments.Add(freeFormHazardousMaterialInformation);
                        }

                        foreach (var lepEpaRequiredData in hazMatInfo.EpaData)
                        {
                            s.Segments.Add(lepEpaRequiredData);
                        }


                        if (hazMatInfo.CanadianRequierments != null)
                            s.Segments.Add(hazMatInfo.CanadianRequierments);

                        foreach (var transborderRequirement in hazMatInfo.TransborderRequirements)
                        {
                            s.Segments.Add(transborderRequirement);
                        }
                    }
                        

                }

                foreach (var referenceNumber in detail.ReferenceNumbers) s.Segments.Add(referenceNumber);

                foreach (var measurement in detail.Measurements) s.Segments.Add(measurement);

                if (detail.Measuresment != null)
                    s.Segments.Add(detail.Measuresment);



            }

            foreach (var stopDetail in stop.Details)
            {
                s.Segments.Add(stopDetail.Summary);
                foreach (var ladingInformation in stopDetail.LadingInformation) s.Segments.Add(ladingInformation.ToLAD());
                foreach (var detail in stopDetail.OrderDetails)
                {
                    s.Segments.Add(detail.DescriptionMarksAndNumbers);
                    s.Segments.Add(detail.ShipmentWeightPackagingAndQuantityData);
                    
                    foreach (var contact in detail.Contacts)
                    {
                        s.Segments.Add(contact.Info);
                        foreach (var hazMatInfo in contact.HazMatInfo)
                        {
                            if (hazMatInfo.IdentificationInfo != null)    
                                s.Segments.Add(hazMatInfo.IdentificationInfo);
                            foreach (var classificationInformation in hazMatInfo.Classiciation)
                            {
                                s.Segments.Add(classificationInformation);
                            }

                            foreach (var shippingNameInformation in hazMatInfo.ShippingName)
                            {
                                s.Segments.Add(shippingNameInformation);
                            }

                            foreach (var freeFormHazardousMaterialInformation in hazMatInfo.FreeFormInfo)
                            {
                                s.Segments.Add(freeFormHazardousMaterialInformation);
                            }

                            foreach (var lepEpaRequiredData in hazMatInfo.EpaData)
                            {
                                s.Segments.Add(lepEpaRequiredData);
                            }


                            if (hazMatInfo.CanadianRequierments != null)
                                s.Segments.Add(hazMatInfo.CanadianRequierments);

                            foreach (var transborderRequirement in hazMatInfo.TransborderRequirements)
                            {
                                s.Segments.Add(transborderRequirement);
                            }
                        }

                        
                    }
                }
            }
        }

        if (Totals!=null)
            s.Segments.Add(Totals);

        return s;
    }

    public void Validate()
    {
        //needs a b2 entry
        //needs a b2a entry
    }
}
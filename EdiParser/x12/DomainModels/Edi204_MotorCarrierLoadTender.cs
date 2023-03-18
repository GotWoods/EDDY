using System;
using System.Collections.Generic;
using System.Linq;
using EdiParser.x12.DomainModels._210;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;
using static System.String;

namespace EdiParser.x12.DomainModels;

public class Edi204_MotorCarrierLoadTender
{
    public string CarrierStandardCarrierAlphaCode { get; set; }
    public string ShipmentIdentificationNumber { get; set; }
    public string ShipmentMethodOfPaymentCode { get; set; }
    public List<Entity> Entities { get; set; } = new();
    public List<StopOffDetails> Stops { get; set; } = new();
    public List<KeyValuePair<string, string>> ReferenceNumbers { get; set; } = new();
    public List<EquipmentDetails> EquipmentDetails { get; set; } = new();
    public Date OrderDate { get; set; }
    public InterlineInformation InterlineInformation { get; set; }

    // public string Receiver { get; set; }
    //
    // public string Sender { get; set; }

    public DateTime CreationDate { get; set; }
    public string Purpose { get; set; }
    public List<Note> Notes { get; set; } = new();

    public L3_TotalWeightAndCharges Totals { get; set; } = new();



    public void LoadFrom(Section section)
    {
        //this.CreationDate = document.IsaInterchangeControlHeader.CreationDate;
        // Sender = document.IsaInterchangeControlHeader.InterchangeSenderId;
        // Receiver = document.IsaInterchangeControlHeader.InterchangeReceiverId;
        //
        // var section = document.Sections[0]; //it is possible a document contains multiple instructions
        var groupedSectionReader = new GroupedSectionReader(section);

        //0050
        var billOfLadingRules = new GroupingRule("Bill Of Lading", typeof(AT5_BillOfLadingHandlingRequirements), typeof(RTT_FreightRateInformation), typeof(C3_CurrencyIdentifier));

        //0100
        var partyRules = new GroupingRule("Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(G61_Contact));

        //0200
        var equipmentDetailRules = new GroupingRule("Equipment Details", typeof(N7_EquipmentDetails), typeof(N7A_AccessorialEquipmentDetails), typeof(N7B_AdditionalEquipmentDetails), typeof(MEA_Measurements), typeof(M7_SealNumbers));
        
        //0300
        var stopDetailsRules = new GroupingRule("StopOffDetails", typeof(S5_StopOffDetails), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(G62_DateTime), typeof(AT8_ShipmentWeightPackagingAndQuantityData), typeof(LAD_LadingDetail), typeof(NTE_Note), typeof(PLD_PalletShipmentInformation));
        
        //0305
        stopDetailsRules.AddSubRule("Handling Requirements", typeof(AT5_BillOfLadingHandlingRequirements), typeof(RTT_FreightRateInformation), typeof(C3_CurrencyIdentifier));
        //PLD/NTE can exist as standalones here... even though it is in a loop?
        
        //0310
        var stopPartiesRules = stopDetailsRules.AddSubRule("Stop Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(G61_Contact));
        
        //0320
        var shipmentDataRules = stopDetailsRules.AddSubRule("Shipment Data", typeof(L5_DescriptionMarksAndNumbers), typeof(AT8_ShipmentWeightPackagingAndQuantityData));

        //0323
        shipmentDataRules.AddSubRule(new GroupingRule("Handling Requirements", typeof(AT5_BillOfLadingHandlingRequirements), typeof(RTT_FreightRateInformation), typeof(C3_CurrencyIdentifier)));
        //L11/MEA/PER/L4 can just exist here even though it is in a loop?

        //0325
        var contactRules = shipmentDataRules.AddSubRule("Contact", typeof(G61_Contact), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(LH6_HazardousCertification));

        //0330
        contactRules.AddSubRule("HazMat", typeof(LH1_HazardousIdentificationInformation), typeof(LH2_HazardousClassificationInformation), typeof(LH3_HazardousMaterialShippingNameInformation), typeof(LFH_FreeFormHazardousMaterialInformation), typeof(LEP_EPARequiredData), typeof(LH4_CanadianDangerousRequirements), typeof(LHT_TransborderHazardousRequirements));

        //0350
        var stopOrderInfoRule = stopDetailsRules.AddSubRule("Stop Order Information", typeof(OID_OrderInformationDetail), typeof(G62_DateTime), typeof(LAD_LadingDetail));

        //0360
        var orderDetailRules = stopOrderInfoRule.AddSubRule("Order Details", typeof(L5_DescriptionMarksAndNumbers), typeof(AT8_ShipmentWeightPackagingAndQuantityData), typeof(L4_Measurement));

        //0365
        var orderDetailsContactRules = orderDetailRules.AddSubRule("Order Detail Contact", typeof(G61_Contact), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(LH6_HazardousCertification));

        //0370
        orderDetailsContactRules.AddSubRule("Hazmat Details", typeof(LH1_HazardousIdentificationInformation), typeof(LH2_HazardousClassificationInformation), typeof(LH3_HazardousMaterialShippingNameInformation), typeof(LFH_FreeFormHazardousMaterialInformation), typeof(LEP_EPARequiredData), typeof(LH4_CanadianDangerousRequirements), typeof(LHT_TransborderHazardousRequirements));

        //0380
        stopDetailsRules.AddSubRule("Other EquipmentDetails", typeof(N7_EquipmentDetails), typeof(N7A_AccessorialEquipmentDetails), typeof(N7B_AdditionalEquipmentDetails), typeof(MEA_Measurements), typeof(M7_SealNumbers));

        //1000
        var summary = new GroupingRule("Summary", typeof(LX_TransactionSetLineNumber), typeof(L4_Measurement));

        var groupReader = new GroupedSectionReader(section);

        var groupedSection = groupReader.Read(partyRules, billOfLadingRules, equipmentDetailRules, stopDetailsRules, summary);
        
        foreach (var segment in groupedSection.Segments)
            switch (segment)
            {
                case B2_BeginningSegmentForShipmentInformationTransaction b2:
                    CarrierStandardCarrierAlphaCode = b2.StandardCarrierAlphaCode;
                    ShipmentIdentificationNumber = b2.ShipmentIdentificationNumber;
                    ShipmentMethodOfPaymentCode = b2.ShipmentMethodOfPaymentCode;
                    ShipmentMethodOfPaymentCode = b2.ShipmentMethodOfPaymentCode;
                    PaymentMethodCode = b2.PaymentMethodCode;
                    ShipmentWeightCode = b2.ShipmentWeightCode;
                    break;
                case B2A_SetPurpose b2a:
                    Purpose = b2a.TransactionSetPurposeCode;
                    ApplicationType = b2a.ApplicationTypeCode;
                    break;
                case G62_DateTime g62:
                    OrderDate = Date.From(g62);
                    break;
                case L11_BusinessInstructionsAndReferenceNumber l11:
                    ReferenceNumbers.Add(new KeyValuePair<string, string>(l11.ReferenceIdentificationQualifier, l11.ReferenceIdentification));
                    //can be up to 99999 of these
                    //var l11 = (L11_BusinessInstructionsAndReferenceNumber)document.Sections[0].Segments.First(x => x.GetType() == typeof(L11_BusinessInstructionsAndReferenceNumber));
                    //     public string Purpose { get; set; } //always being set to revised but B2A is the purpose of the document
                    //l11 exists on the stops as well
                    // switch (l11.ReferenceIdentificationQualifier.ToUpperInvariant())
                    // {
                    //     case "BN":
                    //         TenderRequestId = l11.ReferenceIdentification;
                    //         break;
                    //     case "RU":
                    //         RouteName = l11.ReferenceIdentification;
                    //         break;
                    //     case "R1":
                    //         Control_VersionID = l11.ReferenceIdentification;
                    //         break;
                    //     case "IN":
                    //         CarrierInvoiceNumber = l11.ReferenceIdentification;
                    //         break;
                    //     case "CN":
                    //     case "SI":
                    //         ProNumber = l11.ReferenceIdentification;
                    //         break;
                    //     case "CR":
                    //     case "TN":
                    //         CarrierReleaseNumber = l11.ReferenceIdentification;
                    //         break;
                    //     case "TH":
                    //     case "11":
                    //     case "DD":
                    //         AccountCode = l11.ReferenceIdentification;
                    //         break;
                    // }

                    break;
                case MS3_InterlineInformation ms3:
                    this.InterlineInformation = InterlineInformation.FromMS3(ms3);
                    // if (ms3.TransportationMethodTypeCode == "O")
                    // {
                    // }
                    //
                    // //TransportationMode = ms3.TransportationMethodTypeCode;
                    // if (ms3.TransportationMethodTypeCode == "LT")
                    // {
                    // }
                    //PreferedCarrierSCAC = b2.StandardCarrierAlphaCode
                    break;
                case PLD_PalletShipmentInformation pld:
                    this.PalletInformation = pld;
                    break;
                case NTE_Note nte:
                
                    var note = new Note();
                    note.ReferenceCode = nte.NoteReferenceCode;
                    note.Description = nte.Description;
                    this.Notes.Add(note);
                    // switch (nte.NoteReferenceCode)
                    // {
                    //
                    //     case "OTH":
                    //         //CheckCallRequirements = NTE.Description
                    //         break;
                    //     case "BOL":
                    //     case "ALT":
                    //     case "INT":
                    //     case "ADD":
                    //         //TenderRequestComments = NTE.Description
                    //         //SpecialInstructions = NTE.Description
                    //         break;
                    //     case "CBH":
                    //         //EstimatedCost = NTE.Description
                    //         break;
                    //     case "ECM":
                    //         //EstimatedCostComments = NTE.Description
                    //         break;
                    // }

                    break;
                case L3_TotalWeightAndCharges l3:
                    this.Totals = l3;
                    break;
        }

        foreach (var party in groupedSection.Children.Where(x => x.Rule == partyRules))
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
                        entity.Address1 = n3.AddressInformation;
                        entity.Address2 = n3.AddressInformation2;
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

        foreach (var equipmentDetail in groupedSection.Children.Where(x => x.Rule == equipmentDetailRules))
        {
            var details = new EquipmentDetails();
            foreach (var segment in equipmentDetail.Segments)
                switch (segment)
                {
                    case N7_EquipmentDetails n7:
                        details.LineData = n7;
                        // details.EquipmentNumber = n7.EquipmentNumber;
                        // details.EquipmentDescriptionCode = n7.EquipmentDescriptionCode;
                        // details.EquipmentLength = n7.EquipmentLength;
                        // details.Weight = n7.Weight;
                        // details.WeightQualifier = n7.WeightQualifier;
                        // details.Height = n7.Height;
                        // details.Width = n7.Width;
                        break;
                    case M7_SealNumbers m7: //TODO: max 2
                        details.SealNumbers.Add(m7.SealNumber);
                        if (!IsNullOrWhiteSpace(m7.SealNumber2))
                            details.SealNumbers.Add(m7.SealNumber2);
                        if (!IsNullOrWhiteSpace(m7.SealNumber3))
                            details.SealNumbers.Add(m7.SealNumber3);
                        if (!IsNullOrWhiteSpace(m7.SealNumber4))
                            details.SealNumbers.Add(m7.SealNumber4);
                        break;
                }
            this.EquipmentDetails.Add(details);
        }

        foreach (var stopSegment in groupedSection.Children.Where(x => x.Rule == stopDetailsRules))
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
                    stop.Notes.Add(new Note() { Description = nte.Description, ReferenceCode = nte.NoteReferenceCode });
                    break;
                case AT8_ShipmentWeightPackagingAndQuantityData at8:
                        stop.ShipmentWeightPackagingAndQuantityData = at8;
                    break;
            }

            var partyGroup = stopSegment.Children.FirstOrDefault(x => x.Rule == stopPartiesRules);
            if (partyGroup != null)
            {
                var entity = new Entity();
                foreach (var segment in partyGroup.Segments)
                {
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
                            entity.Address1 = n3.AddressInformation;
                            entity.Address2 = n3.AddressInformation2;
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
                }
                stop.Entity = entity;
            }

            foreach (var stopDetails in stopSegment.Children.Where(x => x.Rule == stopOrderInfoRule))
            {
                var detail = new StopDetails();

                foreach (var segment in stopDetails.Segments)
                {
                    switch (segment)
                    {
                        case OID_OrderInformationDetail oid:
                            detail.Weight = oid.Weight;
                            detail.PurchaseOrderNumber = oid.PurchaseOrderNumber;
                            detail.WeightUnitCode = oid.WeightUnitCode;
                            detail.PackagingFormCode = oid.PackagingFormCode;
                            detail.Quantity = oid.Quantity;
                            detail.ReferenceIdentification = oid.ReferenceIdentification;
                            break;
                        case G62_DateTime g62:
                            break;
                        case LAD_LadingDetail lad: //this looks to mirror the OID but use different codes, it can repeat though
                            detail.LadingInformation.Add(LadingInformation.FromLAD(lad)); 
                            break;
                    }
                }

                foreach (var l5Group in stopDetails.Children.Where(x=>x.Rule == orderDetailRules))
                {
                    foreach (var segment in l5Group.Segments)
                    {
                        switch (segment)
                        {
                            case L5_DescriptionMarksAndNumbers l5:
                                detail.DescriptionAndMarks.Add(DescriptionMarksAndNumbers.CreateFromL5(l5));
                                break;
                            case AT8_ShipmentWeightPackagingAndQuantityData at8:
                                detail.ShipmentWeightPackagingInformation = at8;
                                break;
                        }
                    }
                }

                stop.Details.Add(detail);
            }
                this.Stops.Add(stop);
        }

                //contacts can go N1,N2,N3,N4,L11,G61
                //equipment details can go //n7,n7a,n7b,MEA,M7


                // var N1 = (N1_PartyIdentification)document.Sections[0].Segments.First(x => x.GetType() == typeof(N1_PartyIdentification));
                //
                // if (N1.EntityIdentifierCode == "SH") //shipper 
                // {
                //
                // }
                //
                //
                // if (N1.EntityIdentifierCode == "QD" || N1!.EntityIdentifierCode == "BT")  //Responsible Party / Bill To Party
                // {
                //     // this.ResponsiblePartyEntityName = N1.Name;
                //     // this.ResponsiblePartyEntityIDCode = N1.IdentificationCode;
                //     //this.ResponsiblePartyAddress1 = N3.[01]
                //     //this.ResponsiblePartyAddress2 = N3.[02]
                //     //     public string ResponsiblePartyAddress3 { get; set; }
                //     //     public string ResponsiblePartyAddress4 { get; set; }
                //     //this.ResponsiblePartyCity = N4.Name
                //     //this.ResponsiblePartyState_Province = N4.[02]
                //     //this.ResponsiblePartyPostalCode = N4.[03]
                //     //this.ResponsiblePartyPostalCountry= N4.[04]
                //     // var G61 = (G61_Contact)document.Sections[0].Segments.First(x => x.GetType() == typeof(G61_Contact));
                //     // this.ResponsiblePartyPhoneNumber = G61.ContactFunctionCode + G61.CommunicationNumberQualifier + G61.CommunicationNumber
                //     //     public string ResponsiblePartyContactCountry { get; set; }
                //     //     public string ResponsiblePartyContactEmail { get; set; }
                //     //     public string ResponsiblePartyContactFax { get; set; }
                //     //     public string ResponsiblePartyContactFaxCode { get; set; }
                //     //     public string ResponsiblePartyContactName { get; set; }
                //     //     public string ResponsiblePartyContactPhone { get; set; }
                //     //     public string ResponsiblePartyContactPhoneCode { get; set; }
                //     //     public string ResponsiblePartyEntityIdCode { get; set; }
                //     //     public string ResponsiblePartyEntityName { get; set; }
                //     //     public string ResponsiblePartyFaxCode { get; set; }
                //     //     public string ResponsiblePartyFaxNumber { get; set; }
                //     //     public string ResponsiblePartyPhoneCode { get; set; }
                //     //     public string ResponsiblePartyPhoneNumber { get; set; }
                //
                //
                //
                // }
                // if (new[] { "RM", "VI", "PF", "OB" }.Contains(N1.EntityIdentifierCode)) //Remittance Party, (VI) Contact Person, (PF) Part to receive freight bill, (OB) Ordered By
                // {
                //     // this.ResponsiblePartyLocationEntityName = N1.Name;
                //     // this.ResponsiblePartyLocationEntityIDCode = N1.IdentificationCode;
                //     //this.ResponsiblePartyLocationAddress1 = N3.[01]
                //     //this.ResponsiblePartyLocationAddress2 = N3.[02]
                //     //this.ResponsiblePartyLocationCity = N4.[01]
                //     //this.ResponsiblePartyLocationState_Province = N4.[02]
                //     //ResponsiblePartyLocationPostalCode = N4.[03]
                //     //ResponsiblePartyLocationCountry = N4.[04]
                //
                //     //     public string ResponsiblePartyLocationContactCountry { get; set; }
                //     //     public string ResponsiblePartyLocationContactEmail { get; set; }
                //     //     public string ResponsiblePartyLocationContactFax { get; set; }
                //     //     public string ResponsiblePartyLocationContactFaxCode { get; set; }
                //     //     public string ResponsiblePartyLocationContactName { get; set; }
                //     //     public string ResponsiblePartyLocationContactPhone { get; set; }
                //     //     public string ResponsiblePartyLocationContactPhoneCode { get; set; }
                //
                //     //     public string ResponsiblePartyLocationFaxCode { get; set; }
                //     //     public string ResponsiblePartyLocationFaxNumber { get; set; }
                //     //     public string ResponsiblePartyLocationPhoneCode { get; set; }
                //     //     public string ResponsiblePartyLocationPhoneNumber { get; set; }
                //     //     public string ResponsiblePartyLocationPostalCode { get; set; }
                //     //     public string ResponsiblePartyLocationState_Province { get; set; }
                //     //     public string ResponsiblePartyLocationTimeZone { get; set; }
                // }


                //if in a stop
                // switch (l11.ReferenceIdentificationQualifier)
                // {
                //     case "P8":
                //         StopReferenceId = l11.ReferenceIdentification;
                //         break;
                //     case "CMNA":
                //         ShipToAddress3 = l11.ReferenceIdentification;
                //         break;
                //     case "11":
                //     case "BM":
                //         BillOfLading = l11.ReferenceIdentification;
                //         break;
                //     case "PO":
                //         PurchaseOrder = l11.ReferenceIdentification;
                //         break;
                //     case "PK":
                //         PackingSlipNumber = l11.ReferenceIdentification;
                //         break;
                //     case "4H":
                //         ComercialInvoice = l11.ReferenceIdentification;
                //         break;
                //     case "2I":
                //         ShipmentStopTrackingID = l11.ReferenceIdentification;
                //         break;
                //     case "BB":
                //         PickupAuthorizationNumber = l11.ReferenceIdentification;
                //
                //
                // }


                //            if (l11.ReferenceIdentificationQualifier == "RU")
        }

    public string ApplicationType { get; set; }

    public PLD_PalletShipmentInformation PalletInformation { get; set; }

    public string ShipmentWeightCode { get; set; }


    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "204";
        s.TransactionSetControlNumber = transactionSetControlNumber;
        s.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction
        {
            StandardCarrierAlphaCode = CarrierStandardCarrierAlphaCode,
            ShipmentIdentificationNumber = ShipmentIdentificationNumber,
            ShipmentMethodOfPaymentCode = ShipmentMethodOfPaymentCode,
            PaymentMethodCode = PaymentMethodCode,
            ShipmentWeightCode = ShipmentWeightCode,
        });
        s.Segments.Add(new B2A_SetPurpose
        {
            TransactionSetPurposeCode = Purpose,
            ApplicationTypeCode = ApplicationType
        });
        
        //s.Segments.Add(new C3_CurrencyIdentifier());

        foreach (var referenceNumber in ReferenceNumbers)
        {
            var l11 = new L11_BusinessInstructionsAndReferenceNumber()
            {
                ReferenceIdentificationQualifier = referenceNumber.Key,
                ReferenceIdentification = referenceNumber.Value
            };
            s.Segments.Add(l11);
        }

        if (this.OrderDate != null) 
            s.Segments.Add(this.OrderDate.ToG62());
        if (this.InterlineInformation != null)
            s.Segments.Add(this.InterlineInformation.ToMS3());


        //s.Segments.Add(new G62_DateTime());
        //s.Segments.Add(new MS3_InterlineInformation());

        //AT5 loop
        
        if (PalletInformation!=null) 
            s.Segments.Add(PalletInformation);

        //LH6


        foreach (var note in Notes)
        {
            s.Segments.Add(new NTE_Note
            {
                Description = note.Description,
                NoteReferenceCode = note.ReferenceCode
            });
        }

        foreach (var entity in Entities)
        {
            var n1 = new N1_PartyIdentification()
            {
                Name = entity.Name,
                EntityIdentifierCode = entity.EntityIdentifierCode,
                IdentificationCodeQualifier = entity.IdentificationCodeQualifier,
                IdentificationCode = entity.IdentificationCode,
            };
            s.Segments.Add(n1);

            //TODO: N2
            var n2 = new N2_AdditionalNameInformation()
            {

            };

            if (!string.IsNullOrEmpty(entity.Address1) || !string.IsNullOrEmpty(entity.Address1))
            {
                var n3 = new N3_PartyLocation()
                {
                    AddressInformation = entity.Address1,
                    AddressInformation2 = entity.Address2
                    
            };
                s.Segments.Add(n3);
            }

            if (!IsNullOrEmpty(entity.City) || !IsNullOrEmpty(entity.Country) || !IsNullOrEmpty(entity.PostalZip) || !IsNullOrEmpty(entity.ProvinceState))
            {
                var n4 = new N4_GeographicLocation()
                {
                    CityName = entity.City,
                    CountryCode = entity.Country,
                    PostalCode = entity.PostalZip,
                    StateOrProvinceCode = entity.ProvinceState
                };
                s.Segments.Add(n4);
            }
            foreach (var contact in entity.Contacts)
            {
                s.Segments.Add(contact.ToG61());
            }

        }

        foreach (var equipmentDetail in EquipmentDetails)
        {
            s.Segments.Add(equipmentDetail.LineData);
            foreach (var equipmentDetailSealNumber in equipmentDetail.SealNumbers)
            {
                s.Segments.Add(new M7_SealNumbers() { SealNumber = equipmentDetailSealNumber});
            }
        }

        foreach (var stop in Stops)
        {
            s.Segments.Add(new S5_StopOffDetails()
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
                AccomplishCode = stop.AccomplishCode,
            });

            foreach (var stopReferenceNumber in stop.ReferenceNumbers)
            {
                s.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = stopReferenceNumber.Value, ReferenceIdentificationQualifier = stopReferenceNumber.Key});
            }

            foreach (var date in stop.Dates)
            {
                s.Segments.Add(date.ToG62());
            }

            if (stop.ShipmentWeightPackagingAndQuantityData != null)
            {
                s.Segments.Add(stop.ShipmentWeightPackagingAndQuantityData);
            }

            foreach (var stopNote in stop.Notes)
            {
                s.Segments.Add(new NTE_Note() { Description = stopNote.Description, NoteReferenceCode = stopNote.ReferenceCode });
            }

            if (stop.Entity != null)
            {
                var n1 = new N1_PartyIdentification()
                {
                    Name = stop.Entity.Name,
                    EntityIdentifierCode = stop.Entity.EntityIdentifierCode,
                    IdentificationCodeQualifier = stop.Entity.IdentificationCodeQualifier,
                    IdentificationCode = stop.Entity.IdentificationCode,
                };

                //TODO: N2
                var n2 = new N2_AdditionalNameInformation()
                {

                };
                var n3 = new N3_PartyLocation()
                {
                    AddressInformation = stop.Entity.Address1,
                    AddressInformation2 = stop.Entity.Address2
                };

                var n4 = new N4_GeographicLocation()
                {
                    CityName = stop.Entity.City,
                    CountryCode = stop.Entity.Country,
                    PostalCode = stop.Entity.PostalZip,
                    StateOrProvinceCode = stop.Entity.ProvinceState
                };

                s.Segments.Add(n1);
                s.Segments.Add(n3);
                s.Segments.Add(n4);

                foreach (var contact in stop.Entity.Contacts)
                {
                    s.Segments.Add(contact.ToG61());
                }

                foreach (var stopDetail in stop.Details)
                {
                    s.Segments.Add(new OID_OrderInformationDetail() { ReferenceIdentification = stopDetail.ReferenceIdentification, PackagingFormCode = stopDetail.PackagingFormCode, Weight = stopDetail.Weight, WeightUnitCode = stopDetail.WeightUnitCode, Quantity = stopDetail.Quantity, PurchaseOrderNumber = stopDetail.PurchaseOrderNumber});
                    foreach (var ladingInformation in stopDetail.LadingInformation)
                    {
                        s.Segments.Add(ladingInformation.ToLAD());                        
                    }
                    foreach (var descriptionAndMark in stopDetail.DescriptionAndMarks)
                    {
                        s.Segments.Add(descriptionAndMark.ToL5());
                    }
                }
            }
        }

        s.Segments.Add(this.Totals);

        return s;
    }

    public string PaymentMethodCode { get; set; }

    public void Validate()
    {
        //needs a b2 entry
        //needs a b2a entry
    }
}

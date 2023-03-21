using System;
using System.Collections.Generic;
using System.Linq;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;
using static System.String;

namespace EdiParser.x12.DomainModels;

public class Edi210_MotorCarrierFreightDetailsAndInvoice
{
    public DateTime CreationDate { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }

    public string InvoiceNumber { get; set; }
    public string ShipmentIdentificationNumber { get; set; }
    public string Date { get; set; }
    public string DeliveryDate { get; set; }
    public List<Entity> Entities { get; set; } = new();
    public List<EquipmentDetails> EquipmentDetails { get; set; } = new();
  
    public L3_TotalWeightAndCharges Totals { get; set; }

    public void LoadFrom(x12Document document)
    {
        //this.CreationDate = document.IsaInterchangeControlHeader.CreationDate;
        Sender = document.IsaInterchangeControlHeader.InterchangeSenderId;
        Receiver = document.IsaInterchangeControlHeader.InterchangeReceiverId;
        //document.IsaInterchangeControlHeader.
        // var equipmentLocation = document.Sections[0].Segments.Where(x => x.GetType() == typeof(MS1_EquipmentShipmentOrRealPropertyLocation));
        // var weight = document.Sections[0].Segments.Where(x => x.GetType() == typeof(AT8_ShipmentWeightPackagingAndQuantityData));

        //structure of file
        //single linedata items at top
        //Parties[]
        //EquipmentDetais[]
        //OrderInformation[]
        //Stops[]
        //  OrderInformation[]
        //  Parties[]
        //  Equipmentdetails[]
        //TransactionSets[]
        //  OrderInformation[]
        //  Parties[]
        //    Carton/PackageDetails[]
        //    OrderInformation[]
        //single line summary items at bottom


        var partyRules = new GroupingRule("Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(L11_BusinessInstructionsAndReferenceNumber));
        var equipmentDetailsRules = new GroupingRule("Equipment Details", typeof(N7_EquipmentDetails), typeof(M7_SealNumbers));
        var orderInformationRules = new GroupingRule("Order Information", typeof(OID_OrderInformationDetail), typeof(SDQ_DestinationQuantity));
        
        
        //300
        var stopRules = new GroupingRule("Stop Info", typeof(S5_StopOffDetails), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(G62_DateTime), typeof(H3_SpecialHandlingInstructions));
        //305
        stopRules.AddSubRule("Stop Order Detail", typeof(OID_OrderInformationDetail), typeof(SDQ_DestinationQuantity));
        //310
        var stopPartiesRule = stopRules.AddSubRule("Stop Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(L11_BusinessInstructionsAndReferenceNumber));
        //320
        stopPartiesRule.AddSubRule("Stop Party Equipment", typeof(N7_EquipmentDetails), typeof(M7_SealNumbers));

        //400
        var transactionSetRules = new GroupingRule("Transaction Sets", typeof(LX_TransactionSetLineNumber), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(L5_DescriptionMarksAndNumbers), typeof(H1_HazardousMaterial), typeof(H2_AdditionalHazardousMaterialDescription), typeof(L0_LineItemQuantityAndWeight), typeof(L1_RateAndCharges), typeof(L4_Measurement), typeof(L7_TariffReference), typeof(K1_Remarks));
        //430
        transactionSetRules.AddSubRule(new GroupingRule("Transaction Set Order Information", typeof(OID_OrderInformationDetail), typeof(SDQ_DestinationQuantity)));
        //460
        var transactionSetPartiesRule = transactionSetRules.AddSubRule("Transaction Set Parties", typeof(N1_PartyIdentification), typeof(N2_AdditionalNameInformation), typeof(N3_PartyLocation), typeof(N4_GeographicLocation), typeof(L11_BusinessInstructionsAndReferenceNumber));
        //463
        transactionSetPartiesRule.AddSubRule(new GroupingRule("Carton/Package Detail", typeof(CD3_CartonPackageDetail), typeof(L11_BusinessInstructionsAndReferenceNumber), typeof(H6_SpecialServices), typeof(L9_ChargeDetail), typeof(POD_ProofOfDelivery), typeof(G62_DateTime)));
        //465
        transactionSetPartiesRule.AddSubRule(new GroupingRule("transaction Set Order Information", typeof(OID_OrderInformationDetail), typeof(SDQ_DestinationQuantity)));


        var section = document.Sections[0]; //it is possible a document contains multiple instructions
        var groupReader = new GroupedSectionReader(section);

        // var groupedSection = groupReader.Read(partyRules, equipmentDetailsRules, orderInformationRules, stopRules, transactionSetRules);
        //
        //
        // foreach (var segment in groupedSection.Segments)
        // {
        //     switch (segment)
        //     {
        //         case B3_BeginningSegmentForCarriersInvoice b3:
        //             InvoiceNumber = b3.InvoiceNumber;
        //             ShipmentIdentificationNumber = b3.ShipmentIdentificationNumber;
        //             DeliveryDate = b3.DeliveryDate;
        //             //TOOD: b3.DateTimeQualifier;
        //             break;
        //         case C2_BankID c2:
        //             break;
        //         case C3_CurrencyIdentifier c3:
        //             break;
        //         case ITD_TermsOfSaleDeferredTermsOfSale itd:
        //             break;
        //         case L11_BusinessInstructionsAndReferenceNumber l11:
        //             break;
        //         case G62_DateTime g62:
        //             break;
        //         case R3_RouteInformationMotor r3:
        //             break;
        //         case H3_SpecialHandlingInstructions h3:
        //             break;
        //         case K1_Remarks k1:
        //             break;
        //       
        //         case L3_TotalWeightAndCharges l3:
        //             this.Totals = l3;
        //             break;
        //     }
        // }
        //
        // foreach (var party in groupedSection.Children.Where(x => x.Rule == partyRules))
        // {
        //     var entity = new Entity();
        //     foreach (var segment in party.Segments)
        //         switch (segment)
        //         {
        //             case N1_PartyIdentification n1:
        //                 entity.EntityIdentifierCode = n1.EntityIdentifierCode;
        //                 entity.Name = n1.Name;
        //                 break;
        //             case N2_AdditionalNameInformation n2:
        //                 //additional name is this used?
        //                 break;
        //             case N3_PartyLocation n3: //n3 can be here twice so maybe an address3/address4?
        //                 entity.Address1 = n3.AddressInformation;
        //                 entity.Address2 = n3.AddressInformation2;
        //                 break;
        //             case N4_GeographicLocation n4:
        //                 entity.City = n4.CityName;
        //                 entity.ProvinceState = n4.StateOrProvinceCode;
        //                 entity.Country = n4.CountryCode;
        //                 entity.PostalZip = n4.PostalCode;
        //                 break;
        //             case L11_BusinessInstructionsAndReferenceNumber l11:
        //                 break;
        //             case G61_Contact g61: //there can be 3 of these
        //                 entity.AddContact(g61);
        //                 break;
        //         }
        //
        //     Entities.Add(entity);
        // }
        //
        // foreach (var equipmentDetail in groupedSection.Children.Where(x => x.Rule == equipmentDetailsRules))
        // {
        //     var details = new EquipmentDetails();
        //     foreach (var segment in equipmentDetail.Segments)
        //         switch (segment)
        //         {
        //             case N7_EquipmentDetails n7: //TODO: only once
        //                 details.LineData = n7;
        //                 break;
        //             case M7_SealNumbers m7: //TODO: max 2
        //                 details.SealNumbers.Add(m7.SealNumber);
        //                 if (!IsNullOrWhiteSpace(m7.SealNumber2))
        //                     details.SealNumbers.Add(m7.SealNumber2);
        //                 if (!IsNullOrWhiteSpace(m7.SealNumber3))
        //                     details.SealNumbers.Add(m7.SealNumber3);
        //                 if (!IsNullOrWhiteSpace(m7.SealNumber4))
        //                     details.SealNumbers.Add(m7.SealNumber4);
        //                 break;
        //         }
        //     EquipmentDetails.Add(details);
        // }
        //
        // foreach (var transactionSets in groupedSection.Children.Where(x => x.Rule == transactionSetRules))
        // {
        //     var transactionSet = new TransactionSet();
        //     foreach (var segment in transactionSets.Segments)
        //         switch (segment)
        //         {
        //             case L11_BusinessInstructionsAndReferenceNumber l11:
        //                 break;
        //             case L5_DescriptionMarksAndNumbers l5:
        //                 break;
        //             case H1_HazardousMaterial:
        //                 break;
        //             case H2_AdditionalHazardousMaterialDescription:
        //                 break;
        //             case L0_LineItemQuantityAndWeight l0:
        //                 break;
        //             case L1_RateAndCharges l1:
        //                 break;
        //             case L4_Measurement:
        //                 break;
        //             case L7_TariffReference l7:
        //                 break;
        //             case K1_Remarks k1:
        //                 break;
        //             //OID/SDQ can be a subloop
        //             //n1/ns/n3/n4/l11 can be a subloop (that can contain more subitems
        //         }
        //  
        // }
        
    }
}
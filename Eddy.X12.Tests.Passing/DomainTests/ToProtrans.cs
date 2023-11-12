using Eddy.x12.DomainModels.Transportation.Old.v8020;
using Eddy.x12.DomainModels.Transportation.v8020;

namespace Eddy.Tests.x12.DomainTests;

public class ToProtrans
{
    [Fact]
    public void ExampleMap()
    {
        var edi204 = new Edi204_MotorCarrierLoadTender();

        foreach (var VARIABLE in edi204.ReferenceNumbers)
        {
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
        }

        if (edi204.InterlineInformation != null)
        {
            // if (ms3.TransportationMethodTypeCode == "O")
            // {
            // }
            //
            // //TransportationMode = ms3.TransportationMethodTypeCode;
            // if (ms3.TransportationMethodTypeCode == "LT")
            // {
            // }
            //PreferedCarrierSCAC = b2.StandardCarrierAlphaCode
        }

        foreach (var edi204Note in edi204.Notes)
        {
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
        }



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
}
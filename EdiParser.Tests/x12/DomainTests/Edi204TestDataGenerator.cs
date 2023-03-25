using System.Collections;
using EdiParser.x12.DomainModels;
using EdiParser.x12.DomainModels._204;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.DomainTests;

public class Edi204TestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { @"G:\EdiSamples\CardinalLogisticsManagement\204\OUT\2023\03\CCNI_204_202303012041232279.txt", BuildCardinal() };
        yield return new object[] { @"G:\EdiSamples\CHRobinson\204\IN\204_20201117131126445.txt", BuildChRobinson() };
        // yield return new object[] { -4, -6, -10 };
        // yield return new object[] { -2, 2, 0 };
        // yield return new object[] { int.MinValue, -1, int.MaxValue };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Edi204_MotorCarrierLoadTender BuildChRobinson()
    {
        var expected = new Edi204_MotorCarrierLoadTender();
        expected.ShipmentInformation.StandardCarrierAlphaCode = "PNII";
        expected.ShipmentInformation.ShipmentIdentificationNumber = "340186303";
        expected.ShipmentInformation.ShipmentMethodOfPaymentCode = "TP";
        expected.SetPurpose = new B2A_SetPurpose { TransactionSetPurposeCode = "00" };

        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "VD", ReferenceIdentification = "T5227893" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "SI", ReferenceIdentification = "1032301-FW62-FW62-LTL-20201117" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "SI", ReferenceIdentification = "1032301-FW64-FW64-LTL-20201117" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "CR", ReferenceIdentification = "-60860-INBOUND" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "CR", ReferenceIdentification = "-60864-INBOUND" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "OW", ReferenceIdentification = "TMC29316100" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "RB", ReferenceIdentification = "USD" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "TH", ReferenceIdentification = "TMC APTIV" });

        expected.Notes.Add(new NTE_Note { NoteReferenceCode = "ZZZ", Description = "1387" });


        expected.Entities.Add(new Entity
        {
            Name = "Protrans",
            Address1 = "PO Box 42069",
            City = "INDIANAPOLIS",
            ProvinceState = "IN",
            PostalZip = "46242",
            EntityIdentifierCode = "BT"
        });

        expected.Entities.Add(new Entity
        {
            Name = "CH ROBINSON CONTACT",
            EntityIdentifierCode = "VI"
        });

        //g61
        //n7

        expected.Stops.Add(new StopOffDetails
        {
            Detail = new S5_StopOffDetails()
            {
                StopSequenceNumber = 1,
                StopReasonCode = "LD",
            },
            Entity = new Entity
            {
                EntityIdentifierCode = "SF",
                Name = "SHAWCOR LTD (8035865)",
                Address1 = "173 Commerce Dr",
                City = "LOVELAND",
                ProvinceState = "OH",
                Country = "US",
                PostalZip = "45140-7727"
            },
            ReferenceNumbers = new List<L11_BusinessInstructionsAndReferenceNumber>() { new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "PU", ReferenceIdentification = "1032301" } },
            Notes = new List<NTE_Note>
            {
                new() { NoteReferenceCode = "OTH", Description = "No Touch" },
                new() { NoteReferenceCode = "SPH", Description = "D120550 - 19 CTNS; D120127 - 33 CTNS 1 SKID W/ 17 CTNS 1 SKID W/ 16 CTNS" },
                new() { NoteReferenceCode = "PKG", Description = "Dimensions H(in)40 W(in)42 L(ft)04 L(in)04" }
            },
            // Details = new List<OrderInformationDetail>
            // {
            //     new()
            //     {
            //         Summary = new OID_OrderInformationDetail
            //         {
            //             PackagingFormCode = "PL",
            //             ReferenceIdentification = "FW62",
            //             Weight = 343,
            //             WeightUnitCode = "L",
            //             Quantity = 1
            //         }
            //     },
            //     new()
            //     {
            //         Summary = new OID_OrderInformationDetail
            //         {
            //             PackagingFormCode = "PL",
            //             ReferenceIdentification = "FW64",
            //             Weight = 214,
            //             WeightUnitCode = "L",
            //             Quantity = 1
            //         }
            //     },
            //     new()
            //     {
            //         Summary = new OID_OrderInformationDetail
            //         {
            //             PackagingFormCode = "PL",
            //             ReferenceIdentification = "FW64",
            //             Weight = 264,
            //             WeightUnitCode = "L",
            //             Quantity = 1
            //         }
            //     }
            // }
        });


        expected.Stops.Add(new StopOffDetails
        {
            Detail = new S5_StopOffDetails()
            {
                StopSequenceNumber = 2,
                StopReasonCode = "UL",
            },
            Entity = new Entity
            {
                EntityIdentifierCode = "ST",
                Name = "Aptiv Vallecillos X-Dock (8139213)",
                Address1 = "301 Vallecillo Rd",
                City = "Laredo",
                ProvinceState = "TX",
                Country = "US",
                PostalZip = "78045"
            },
            Notes = new List<NTE_Note>
            {
                new() { NoteReferenceCode = "OTH", Description = "No Touch" },
                new() { NoteReferenceCode = "PKG", Description = "Dimensions H(in)40 W(in)42 L(ft)04 L(in)04" }
            },
            // Details = new List<OrderInformationDetail>
            // {
            //     new()
            //     {
            //         Summary = new OID_OrderInformationDetail
            //         {
            //             PackagingFormCode = "PL",
            //             ReferenceIdentification = "FW62",
            //             Weight = 343,
            //             WeightUnitCode = "L",
            //             Quantity = 1
            //         }
            //     },
            //     new()
            //     {
            //         Summary = new OID_OrderInformationDetail
            //         {
            //             PackagingFormCode = "PL",
            //             ReferenceIdentification = "FW64",
            //             Weight = 214,
            //             WeightUnitCode = "L",
            //             Quantity = 1
            //         }
            //     },
            //     new()
            //     {
            //         Summary = new OID_OrderInformationDetail
            //         {
            //             PackagingFormCode = "PL",
            //             ReferenceIdentification = "FW64",
            //             Weight = 264,
            //             WeightUnitCode = "L",
            //             Quantity = 1
            //         }
            //     }
            // }
        });

        expected.Totals.Weight = 821;
        expected.Totals.WeightQualifier = "G";
        expected.Totals.FreightRate = "137.2917";
        expected.Totals.RateValueQualifier = "FR";
        expected.Totals.AmountCharged = "14759";
        expected.Totals.Advances = "1030";
        expected.Totals.LadingQuantity = "3";
        return expected;
    }

    public Edi204_MotorCarrierLoadTender BuildCardinal()
    {
        var expected = new Edi204_MotorCarrierLoadTender();
        expected.ShipmentInformation.StandardCarrierAlphaCode = "CCNI";
        expected.ShipmentInformation.ShipmentIdentificationNumber = "L11005765";
        expected.ShipmentInformation.ShipmentMethodOfPaymentCode = "TP";
        expected.SetPurpose = new B2A_SetPurpose { TransactionSetPurposeCode = "00" };

        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "BN", ReferenceIdentification = "30722781" });
        expected.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "RU", ReferenceIdentification = "MID508v1" });

        expected.Notes.Add(new NTE_Note());
        expected.Notes[0].Description = "Stop Dep; Interval -None;";
        expected.Notes[0].NoteReferenceCode = "OTH";

        expected.Notes.Add(new NTE_Note());
        expected.Notes[1].Description = "Solo";
        expected.Notes[1].NoteReferenceCode = "CAJ";

        expected.Notes.Add(new NTE_Note());
        expected.Notes[2].Description = "NA";
        expected.Notes[2].NoteReferenceCode = "ALT";

        expected.Notes.Add(new NTE_Note());
        expected.Notes[3].Description = "1228.25";
        expected.Notes[3].NoteReferenceCode = "CBH";

        expected.Notes.Add(new NTE_Note());
        expected.Notes[4].Description = "(USD) Base Rate Only";
        expected.Notes[4].NoteReferenceCode = "ECM";

        expected.Entities.Add(new Entity());
        expected.Entities[0].Name = "Cabinetworks CO TRAX";
        expected.Entities[0].Address1 = "Cabinetworks group co trax technologies po box 42903";
        expected.Entities[0].City = "Indianapolis";
        expected.Entities[0].ProvinceState = "IN";
        expected.Entities[0].PostalZip = "46242";
        expected.Entities[0].Country = "US";
        expected.Entities[0].EntityIdentifierCode = "RM";
        expected.Entities[0].Contacts.Add(new Contact { CommunicationNumber = "NA", CommunicationNumberQualifier = "TE", ContactFunctionCode = "AP", ContactInquiryReference = null, Name = "NA" });

        expected.Entities.Add(new Entity());
        expected.Entities[1].Name = "Cabinetworks MACA";
        expected.Entities[1].Address1 = "Cabinetworks group co trax technologies po box 42903";
        expected.Entities[1].City = "Indianapolis";
        expected.Entities[1].ProvinceState = "IN";
        expected.Entities[1].PostalZip = "46242";
        expected.Entities[1].Country = "US";
        expected.Entities[1].EntityIdentifierCode = "QD";
        expected.Entities[1].Contacts.Add(new Contact { CommunicationNumber = "NA", CommunicationNumberQualifier = "TE", ContactFunctionCode = "RP", ContactInquiryReference = null, Name = "NA" });

        //g61
        //n7

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[0].Detail = new S5_StopOffDetails
        {
            StopSequenceNumber = 1,
            StopReasonCode = "LD",
            Weight = 2,
            WeightUnitCode = "L",
            NumberOfUnitsShipped = 2,
            UnitOrBasisForMeasurementCode = "PL"
        };

        expected.Stops[0].Notes.Add(new NTE_Note() { NoteReferenceCode = "ALT", Description = "NA" });
        expected.Stops[0].Entity = new Entity();
        expected.Stops[0].Entity.EntityIdentifierCode = "SF";
        expected.Stops[0].Entity.Name = "Cabinetworks Middlefield, Plant 2";
        expected.Stops[0].Entity.Address1 = "15535 South State Avenue";
        expected.Stops[0].Entity.City = "Middlefield";
        expected.Stops[0].Entity.ProvinceState = "OH";
        expected.Stops[0].Entity.Country = "US";
        expected.Stops[0].Entity.PostalZip = "44062";
        expected.Stops[0].Entity.IdentificationCodeQualifier = "93";
        expected.Stops[0].Entity.IdentificationCode = "103043";
        expected.Stops[0].Entity.Contacts.Add(new Contact { CommunicationNumber = "NA", CommunicationNumberQualifier = "TE", ContactFunctionCode = "SH", ContactInquiryReference = null, Name = "NA" });

        // expected.Stops[0].Details.Add(new OrderInformationDetail());
        // expected.Stops[0].Details[0].Summary = new OID_OrderInformationDetail
        // {
        //     PackagingFormCode = "PL",
        //     ReferenceIdentification = "S14083098",
        //     Weight = 1,
        //     WeightUnitCode = "L",
        //     Quantity = 0
        // };
        // expected.Stops[0].Details.Add(new OrderInformationDetail());
        // expected.Stops[0].Details[0].Summary = new OID_OrderInformationDetail
        // {
        //     PackagingFormCode = "PL",
        //     ReferenceIdentification = "S14083099",
        //     Weight = 1,
        //     WeightUnitCode = "L",
        //     Quantity = 1
        // };

        expected.Stops[0].Dates.Add(new G62_DateTime());   //(new Date { DateQualifier = "10", DateTime = new DateTime(2023, 03, 06, 03, 00, 00), IncludeSecondsInDateTime = true, IncludeTime = true, TimeCode = "ET", TimeQualifer = "I" });
        expected.Stops[0].Dates.Add(new G62_DateTime());  //(new Date { DateQualifier = "10", DateTime = new DateTime(2023, 03, 06, 03, 10, 00), IncludeSecondsInDateTime = true, IncludeTime = true, TimeCode = "ET", TimeQualifer = "K" });

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[1].Detail = new S5_StopOffDetails
        {
            StopSequenceNumber = 2,
            StopReasonCode = "UL",
            Weight = 1,
            WeightUnitCode = "L",
            NumberOfUnitsShipped = 1,
            UnitOrBasisForMeasurementCode = "PL"
        };
        expected.Stops[1].Notes.Add(new NTE_Note { NoteReferenceCode = "ALT", Description = "NA" });
        expected.Stops[1].Entity = new Entity();
        expected.Stops[1].Entity.EntityIdentifierCode = "ST";
        expected.Stops[1].Entity.Name = "Cabinetworks Sayre 100 Lamoka";
        expected.Stops[1].Entity.Address1 = "100 Lamoka Road";
        expected.Stops[1].Entity.City = "Sayre";
        expected.Stops[1].Entity.ProvinceState = "PA";
        expected.Stops[1].Entity.Country = "US";
        expected.Stops[1].Entity.PostalZip = "18840";
        //expected.Stops[1].Details.Add(new OrderInformationDetail());
        // expected.Stops[1].Details[0].Summary = new OID_OrderInformationDetail
        // {
        //     PackagingFormCode = "PL",
        //     ReferenceIdentification = "S14083098",
        //     Weight = 1,
        //     WeightUnitCode = "L",
        //     Quantity = 1
        // };

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[2].Detail = new S5_StopOffDetails
        {
            StopSequenceNumber = 3,
            StopReasonCode = "UL",
            Weight = 1,
            WeightUnitCode = "L",
            NumberOfUnitsShipped = 1,
            UnitOrBasisForMeasurementCode = "PL"
        };
        expected.Stops[2].Notes.Add(new NTE_Note() { NoteReferenceCode = "ALT", Description = "NA" });
        expected.Stops[2].Entity = new Entity();
        expected.Stops[2].Entity.EntityIdentifierCode = "ST";
        expected.Stops[2].Entity.Name = "Cabinetworks Orwell, Plant 3";
        expected.Stops[2].Entity.Address1 = "150 Grand Valley Avenue";
        expected.Stops[2].Entity.City = "Orwell";
        expected.Stops[2].Entity.ProvinceState = "OH";
        expected.Stops[2].Entity.Country = "US";
        expected.Stops[2].Entity.PostalZip = "44076";
        //expected.Stops[2].Details.Add(new OrderInformationDetail());
        // expected.Stops[2].Details[0].Summary = new OID_OrderInformationDetail
        // {
        //     PackagingFormCode = "PL",
        //     ReferenceIdentification = "S14083099",
        //     Weight = 1,
        //     WeightUnitCode = "L",
        //     Quantity = 1
        // };

        expected.Totals.Weight = 2;
        expected.Totals.WeightQualifier = "G";
        expected.Totals.LadingQuantity = "2";
        expected.Totals.AmountCharged = "122825";
        expected.Totals.WeightUnitCode = "L";

        return expected;
    }
}
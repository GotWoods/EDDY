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
        expected.SetPurpose = new B2A_SetPurpose() { TransactionSetPurposeCode = "00" };

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
            PartyIdentification = new N1_PartyIdentification() { Name = "Protrans", EntityIdentifierCode = "BT" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "PO Box 42069" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "INDIANAPOLIS", StateOrProvinceCode = "IN", PostalCode = "46242" }
        });

        expected.Entities.Add(new Entity
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "CH ROBINSON CONTACT", EntityIdentifierCode = "VI" },
        });

        //g61
        //n7

        expected.Stops.Add(new StopOffDetails
        {
            Detail = new S5_StopOffDetails() { StopSequenceNumber = 1, StopReasonCode = "LD" },
            Entity = new Entity
            {
                    PartyIdentification = new N1_PartyIdentification() { Name = "SHAWCOR LTD (8035865)", EntityIdentifierCode = "SF" },
                    PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "173 Commerce Dr" } },
                    GeographicLocation = new N4_GeographicLocation() { CityName = "LOVELAND", StateOrProvinceCode = "OH", PostalCode = "45140-7727", CountryCode = "US" }
            },
            ReferenceNumbers = new List<L11_BusinessInstructionsAndReferenceNumber> { new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "PU", ReferenceIdentification = "1032301" } },
            Notes = new List<NTE_Note>
            {
                new() { NoteReferenceCode = "OTH", Description = "No Touch" },
                new() { NoteReferenceCode = "SPH", Description = "D120550 - 19 CTNS; D120127 - 33 CTNS 1 SKID W/ 17 CTNS 1 SKID W/ 16 CTNS" },
                new() { NoteReferenceCode = "PKG", Description = "Dimensions H(in)40 W(in)42 L(ft)04 L(in)04" }
            },
            Details = new List<OrderInformationDetail2>
            {
                new()
                {
                    Detail = new OID_OrderInformationDetail
                    {
                        PackagingFormCode = "PL",
                        ReferenceIdentification = "FW62",
                        Weight = 343,
                        WeightUnitCode = "L",
                        Quantity = 1
                    }
                },
                new()
                {
                    Detail = new OID_OrderInformationDetail
                    {
                        PackagingFormCode = "PL",
                        ReferenceIdentification = "FW64",
                        Weight = 214,
                        WeightUnitCode = "L",
                        Quantity = 1
                    }
                },
                new()
                {
                    Detail = new OID_OrderInformationDetail
                    {
                        PackagingFormCode = "PL",
                        ReferenceIdentification = "FW64",
                        Weight = 264,
                        WeightUnitCode = "L",
                        Quantity = 1
                    }
                }
            }
        });


        expected.Stops.Add(new StopOffDetails
        {
            Detail = new S5_StopOffDetails() { StopSequenceNumber = 2, StopReasonCode = "UL" },
            Entity = new Entity
            {
                PartyIdentification = new N1_PartyIdentification() { Name = "Aptiv Vallecillos X-Dock (8139213)", EntityIdentifierCode = "ST" },
                    PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "301 Vallecillo Rd" } },
                    GeographicLocation = new N4_GeographicLocation() { CityName = "Laredo", StateOrProvinceCode = "TX", PostalCode = "78045", CountryCode = "US" }
            },
            Notes = new List<NTE_Note>
            {
                new() { NoteReferenceCode = "OTH", Description = "No Touch" },
                new() { NoteReferenceCode = "PKG", Description = "Dimensions H(in)40 W(in)42 L(ft)04 L(in)04" }
            },
            Details = new List<OrderInformationDetail2>
            {
                new()
                {
                    Detail = new OID_OrderInformationDetail
                    {
                        PackagingFormCode = "PL",
                        ReferenceIdentification = "FW62",
                        Weight = 343,
                        WeightUnitCode = "L",
                        Quantity = 1
                    }
                },
                new()
                {
                    Detail = new OID_OrderInformationDetail
                    {
                        PackagingFormCode = "PL",
                        ReferenceIdentification = "FW64",
                        Weight = 214,
                        WeightUnitCode = "L",
                        Quantity = 1
                    }
                },
                new()
                {
                    Detail = new OID_OrderInformationDetail
                    {
                        PackagingFormCode = "PL",
                        ReferenceIdentification = "FW64",
                        Weight = 264,
                        WeightUnitCode = "L",
                        Quantity = 1
                    }
                }
            }
        });

        expected.Totals = new L3_TotalWeightAndCharges();
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
        expected.SetPurpose = new B2A_SetPurpose() { TransactionSetPurposeCode = "00" };

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

        expected.Entities.Add(new Entity
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "Cabinetworks CO TRAX", EntityIdentifierCode = "RM" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "Cabinetworks group co trax technologies po box 42903" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "Indianapolis", StateOrProvinceCode = "IN", PostalCode = "46242" }
        });

        expected.Entities.Add(new Entity
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "Cabinetworks MACA", EntityIdentifierCode = "QD" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "Cabinetworks group co trax technologies po box 42903" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "INDIANAPOLIS", StateOrProvinceCode = "IN", PostalCode = "46242", CountryCode = "US" }
        });

        //TODO: Contacts
        //        expected.Entities[0].Contacts.Add(new Contact { CommunicationNumber = "NA", CommunicationNumberQualifier = "TE", ContactFunctionCode = "AP", ContactInquiryReference = null, Name = "NA" });
        //      expected.Entities[1].Contacts.Add(new Contact { CommunicationNumber = "NA", CommunicationNumberQualifier = "TE", ContactFunctionCode = "RP", ContactInquiryReference = null, Name = "NA" });

        //g61
        //n7

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[0].Detail = new S5_StopOffDetails()
        {
            StopSequenceNumber = 1,
            StopReasonCode = "LD",
            Weight = 2,
            WeightUnitCode = "L",
            NumberOfUnitsShipped = 2,
            UnitOrBasisForMeasurementCode = "PL",
        };
        expected.Stops[0].Notes.Add(new NTE_Note() { NoteReferenceCode = "ALT", Description = "NA" });
        expected.Stops[0].Entity = new Entity()
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "Cabinetworks Middlefield, Plant 2", EntityIdentifierCode = "SF", IdentificationCodeQualifier = "93", IdentificationCode = "103043" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "15535 South State Avenue" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "Middlefield", StateOrProvinceCode = "OH", PostalCode = "44062", CountryCode = "US" }
        };

        //TODO: contacts
        //expected.Stops[0].Entity.Contacts.Add(new Contact { CommunicationNumber = "NA", CommunicationNumberQualifier = "TE", ContactFunctionCode = "SH", ContactInquiryReference = null, Name = "NA" });

        expected.Stops[0].Details.Add(new OrderInformationDetail2());
        expected.Stops[0].Details[0].Detail = new OID_OrderInformationDetail
        {
            PackagingFormCode = "PL",
            ReferenceIdentification = "S14083098",
            Weight = 1,
            WeightUnitCode = "L",
            Quantity = 0
        };
        expected.Stops[0].Details.Add(new OrderInformationDetail2());
        expected.Stops[0].Details[0].Detail = new OID_OrderInformationDetail
        {
            PackagingFormCode = "PL",
            ReferenceIdentification = "S14083099",
            Weight = 1,
            WeightUnitCode = "L",
            Quantity = 1
        };

        expected.Stops[0].Dates.Add(new G62_DateTime() { DateQualifier = "10", Date = "20230306", Time = "030000", TimeCode = "ET", TimeQualifier = "I" });
        expected.Stops[0].Dates.Add(new G62_DateTime() { DateQualifier = "10", Date = "20230306", Time = "031000", TimeCode = "ET", TimeQualifier = "K" });

        expected.Stops.Add(new StopOffDetails() {
            Detail = new S5_StopOffDetails()
            {
                StopSequenceNumber = 2,
                StopReasonCode = "UL",
                Weight = 1,
                WeightUnitCode = "L",
                NumberOfUnitsShipped = 1,
                UnitOrBasisForMeasurementCode = "PL",
            }
        });
        expected.Stops[1].Notes.Add(new NTE_Note { NoteReferenceCode = "ALT", Description = "NA" });
        expected.Stops[1].Entity = new Entity();

        expected.Stops[1].Entity = new Entity
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "Cabinetworks Sayre 100 Lamoka", EntityIdentifierCode = "ST" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "100 Lamoka Road" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "Sayre", StateOrProvinceCode = "PA", PostalCode = "18840", CountryCode = "US"}
        };


        expected.Stops[1].Details.Add(new OrderInformationDetail2());
        expected.Stops[1].Details[0].Detail = new OID_OrderInformationDetail
        {
            PackagingFormCode = "PL",
            ReferenceIdentification = "S14083098",
            Weight = 1,
            WeightUnitCode = "L",
            Quantity = 1
        };

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[2].Detail = new S5_StopOffDetails()
        {
            StopSequenceNumber = 3,
            StopReasonCode = "UL",
            Weight = 1,
            WeightUnitCode = "L",
            NumberOfUnitsShipped = 1,
            UnitOrBasisForMeasurementCode = "PL",
        };

        expected.Stops[2].Notes.Add(new NTE_Note() { NoteReferenceCode = "ALT", Description = "NA" });
        expected.Stops[2].Entity = new Entity
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "Cabinetworks Orwell, Plant 3", EntityIdentifierCode = "ST" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "150 Grand Valley Avenue" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "Orwell", StateOrProvinceCode = "OH", PostalCode = "44076", CountryCode = "US" }
        };

        expected.Stops[2].Details.Add(new OrderInformationDetail2());
        expected.Stops[2].Details[0].Detail = new OID_OrderInformationDetail
        {
            PackagingFormCode = "PL",
            ReferenceIdentification = "S14083099",
            Weight = 1,
            WeightUnitCode = "L",
            Quantity = 1
        };

        expected.Totals = new L3_TotalWeightAndCharges();
        expected.Totals.Weight = 2;
        expected.Totals.WeightQualifier = "G";
        expected.Totals.LadingQuantity = "2";
        expected.Totals.AmountCharged = "122825";
        expected.Totals.WeightUnitCode = "L";

        return expected;
    }
}
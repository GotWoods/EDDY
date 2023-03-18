using System.Collections;
using EdiParser.x12.DomainModels;
using EdiParser.x12.DomainModels._210;

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
        expected.CarrierStandardCarrierAlphaCode = "PNII";
        expected.ShipmentIdentificationNumber = "340186303";
        expected.ShipmentMethodOfPaymentCode = "TP";
        expected.Purpose = "00";

        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("VD", "T5227893"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("SI", "1032301-FW62-FW62-LTL-20201117"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("SI", "1032301-FW64-FW64-LTL-20201117"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("CR", "-60860-INBOUND"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("CR", "-60864-INBOUND"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("OW", "TMC29316100"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("RB", "USD"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("TH", "TMC APTIV"));

        expected.Notes.Add(new Note { ReferenceCode = "ZZZ", Description = "1387" });


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
            StopSequenceNumber = 1,
            StopReasonCode = "LD",
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
            ReferenceNumbers = new List<KeyValuePair<string, string>> { new("PU", "1032301") },
            Notes = new List<Note>
            {
                new() { ReferenceCode = "OTH", Description = "No Touch" },
                new() { ReferenceCode = "SPH", Description = "D120550 - 19 CTNS; D120127 - 33 CTNS 1 SKID W/ 17 CTNS 1 SKID W/ 16 CTNS" },
                new() { ReferenceCode = "PKG", Description = "Dimensions H(in)40 W(in)42 L(ft)04 L(in)04" }
            },
            Details = new List<StopDetails>
            {
                new()
                {
                    PackagingFormCode = "PL",
                    ReferenceIdentification = "FW62",
                    Weight = 343,
                    WeightUnitCode = "L",
                    Quantity = 1
                },
                new()
                {
                    PackagingFormCode = "PL",
                    ReferenceIdentification = "FW64",
                    Weight = 214,
                    WeightUnitCode = "L",
                    Quantity = 1
                },
                new()
                {
                    PackagingFormCode = "PL",
                    ReferenceIdentification = "FW64",
                    Weight = 264,
                    WeightUnitCode = "L",
                    Quantity = 1
                }
            }
        });


        expected.Stops.Add(new StopOffDetails
        {
            StopSequenceNumber = 2,
            StopReasonCode = "UL",
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
            Notes = new List<Note>
            {
                new() { ReferenceCode = "OTH", Description = "No Touch" },
                new() { ReferenceCode = "PKG", Description = "Dimensions H(in)40 W(in)42 L(ft)04 L(in)04" }
            },
            Details = new List<StopDetails>
            {
                new()
                {
                    PackagingFormCode = "PL",
                    ReferenceIdentification = "FW62",
                    Weight = 343,
                    WeightUnitCode = "L",
                    Quantity = 1
                },
                new()
                {
                    PackagingFormCode = "PL",
                    ReferenceIdentification = "FW64",
                    Weight = 214,
                    WeightUnitCode = "L",
                    Quantity = 1
                },
                new()
                {
                    PackagingFormCode = "PL",
                    ReferenceIdentification = "FW64",
                    Weight = 264,
                    WeightUnitCode = "L",
                    Quantity = 1
                }
            }
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
        expected.CarrierStandardCarrierAlphaCode = "CCNI";
        expected.ShipmentIdentificationNumber = "L11005765";
        expected.ShipmentMethodOfPaymentCode = "TP";
        expected.Purpose = "00";

        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("BN", "30722781"));
        expected.ReferenceNumbers.Add(new KeyValuePair<string, string>("RU", "MID508v1"));

        expected.Notes.Add(new Note());
        expected.Notes[0].Description = "Stop Dep; Interval -None;";
        expected.Notes[0].ReferenceCode = "OTH";

        expected.Notes.Add(new Note());
        expected.Notes[1].Description = "Solo";
        expected.Notes[1].ReferenceCode = "CAJ";

        expected.Notes.Add(new Note());
        expected.Notes[2].Description = "NA";
        expected.Notes[2].ReferenceCode = "ALT";

        expected.Notes.Add(new Note());
        expected.Notes[3].Description = "1228.25";
        expected.Notes[3].ReferenceCode = "CBH";

        expected.Notes.Add(new Note());
        expected.Notes[4].Description = "(USD) Base Rate Only";
        expected.Notes[4].ReferenceCode = "ECM";

        expected.Entities.Add(new Entity());
        expected.Entities[0].Name = "Cabinetworks CO TRAX";
        expected.Entities[0].Address1 = "Cabinetworks group co trax technologies po box 42903";
        expected.Entities[0].City = "Indianapolis";
        expected.Entities[0].ProvinceState = "IN";
        expected.Entities[0].PostalZip = "46242";
        expected.Entities[0].Country = "US";
        expected.Entities[0].EntityIdentifierCode = "RM";

        expected.Entities.Add(new Entity());
        expected.Entities[1].Name = "Cabinetworks MACA";
        expected.Entities[1].Address1 = "Cabinetworks group co trax technologies po box 42903";
        expected.Entities[1].City = "Indianapolis";
        expected.Entities[1].ProvinceState = "IN";
        expected.Entities[1].PostalZip = "46242";
        expected.Entities[1].Country = "US";
        expected.Entities[1].EntityIdentifierCode = "QD";

        //g61
        //n7

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[0].StopSequenceNumber = 1;
        expected.Stops[0].StopReasonCode = "LD";
        expected.Stops[0].Weight = 2;
        expected.Stops[0].WeightUnitCode = "L";
        expected.Stops[0].NumberOfUnitsShipped = 2;
        expected.Stops[0].UnitOrBasisForMeasurementCode = "PL";
        expected.Stops[0].Notes.Add(new Note { ReferenceCode = "ALT", Description = "NA" });
        expected.Stops[0].Entity = new Entity();
        expected.Stops[0].Entity.EntityIdentifierCode = "SF";
        expected.Stops[0].Entity.Name = "Cabinetworks Middlefield, Plant 2";
        expected.Stops[0].Entity.Address1 = "15535 South State Avenue";
        expected.Stops[0].Entity.City = "Middlefield";
        expected.Stops[0].Entity.ProvinceState = "OH";
        expected.Stops[0].Entity.Country = "US";
        expected.Stops[0].Entity.PostalZip = "44062";
        expected.Stops[0].Details.Add(new StopDetails());
        expected.Stops[0].Details[0].PackagingFormCode = "PL";
        expected.Stops[0].Details[0].ReferenceIdentification = "S14083098";
        expected.Stops[0].Details[0].Weight = 1;
        expected.Stops[0].Details[0].WeightUnitCode = "L";
        expected.Stops[0].Details[0].Quantity = 1;
        expected.Stops[0].Details.Add(new StopDetails());
        expected.Stops[0].Details[1].PackagingFormCode = "PL";
        expected.Stops[0].Details[1].ReferenceIdentification = "S14083099";
        expected.Stops[0].Details[1].Weight = 1;
        expected.Stops[0].Details[1].WeightUnitCode = "L";
        expected.Stops[0].Details[1].Quantity = 1;

        expected.Stops.Add(new StopOffDetails());
        expected.Stops[1].StopSequenceNumber = 2;
        expected.Stops[1].StopReasonCode = "UL";
        expected.Stops[1].Weight = 1;
        expected.Stops[1].WeightUnitCode = "L";
        expected.Stops[1].NumberOfUnitsShipped = 1;
        expected.Stops[1].UnitOrBasisForMeasurementCode = "PL";
        expected.Stops[1].Notes.Add(new Note { ReferenceCode = "ALT", Description = "NA" });
        expected.Stops[1].Entity = new Entity();
        expected.Stops[1].Entity.EntityIdentifierCode = "ST";
        expected.Stops[1].Entity.Name = "Cabinetworks Sayre 100 Lamoka";
        expected.Stops[1].Entity.Address1 = "100 Lamoka Road";
        expected.Stops[1].Entity.City = "Sayre";
        expected.Stops[1].Entity.ProvinceState = "PA";
        expected.Stops[1].Entity.Country = "US";
        expected.Stops[1].Entity.PostalZip = "18840";
        expected.Stops[1].Details.Add(new StopDetails());
        expected.Stops[1].Details[0].PackagingFormCode = "PL";
        expected.Stops[1].Details[0].ReferenceIdentification = "S14083098";
        expected.Stops[1].Details[0].Weight = 1;
        expected.Stops[1].Details[0].WeightUnitCode = "L";
        expected.Stops[1].Details[0].Quantity = 1;


        expected.Stops.Add(new StopOffDetails());
        expected.Stops[2].StopSequenceNumber = 3;
        expected.Stops[2].StopReasonCode = "UL";
        expected.Stops[2].Weight = 1;
        expected.Stops[2].WeightUnitCode = "L";
        expected.Stops[2].NumberOfUnitsShipped = 1;
        expected.Stops[2].UnitOrBasisForMeasurementCode = "PL";
        expected.Stops[2].Notes.Add(new Note { ReferenceCode = "ALT", Description = "NA" });
        expected.Stops[2].Entity = new Entity();
        expected.Stops[2].Entity.EntityIdentifierCode = "ST";
        expected.Stops[2].Entity.Name = "Cabinetworks Orwell, Plant 3";
        expected.Stops[2].Entity.Address1 = "150 Grand Valley Avenue";
        expected.Stops[2].Entity.City = "Orwell";
        expected.Stops[2].Entity.ProvinceState = "OH";
        expected.Stops[2].Entity.Country = "US";
        expected.Stops[2].Entity.PostalZip = "44076";
        expected.Stops[2].Details.Add(new StopDetails());
        expected.Stops[2].Details[0].PackagingFormCode = "PL";
        expected.Stops[2].Details[0].ReferenceIdentification = "S14083099";
        expected.Stops[2].Details[0].Weight = 1;
        expected.Stops[2].Details[0].WeightUnitCode = "L";
        expected.Stops[2].Details[0].Quantity = 1;

        expected.Totals.Weight = 2;
        expected.Totals.WeightQualifier = "G";
        expected.Totals.LadingQuantity = "2";
        expected.Totals.AmountCharged = "122825";
        expected.Totals.WeightUnitCode = "L";

        return expected;
    }
}
using Eddy.x12;
using Eddy.x12.DomainModels.Transportation.v8020;
using Eddy.x12.DomainModels.Transportation.v8020._204;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Xunit.Abstractions;
using Eddy.x12.Models.v8020;
using Edi204_MotorCarrierLoadTender = Eddy.x12.DomainModels.Transportation.v8020.Edi204_MotorCarrierLoadTender;

namespace Eddy.Tests.x12.DomainTests;

public class Edi204MotorCarrierLoadTenderTests
{
    private readonly ITestOutputHelper _output;

    public Edi204MotorCarrierLoadTenderTests(ITestOutputHelper output)
    {
        _output = output;
        //Logging.LoggerFactory = new XUnitLoggingFactory(output);
    }

    [Fact]
    public void ToDocumentSection()
    {
        var sourceModel = new Edi204_MotorCarrierLoadTender();
        sourceModel.ShipmentInformation = new B2_BeginningSegmentForShipmentInformationTransaction
        {
            StandardCarrierAlphaCode = "XXXX",
            ShipmentIdentificationNumber = "32523432",
            ShipmentMethodOfPaymentCode = "PP"
        };
        sourceModel.SetPurpose = new B2A_SetPurpose { TransactionSetPurposeCode = "04" };
        sourceModel.Entities.Add(new Entity
        {
            PartyIdentification = new N1_PartyIdentification() { Name = "123 Company", EntityIdentifierCode = "5334532" },
            PartyLocation = new List<N3_PartyLocation>() { new N3_PartyLocation() { AddressInformation = "123 street" } },
            GeographicLocation = new N4_GeographicLocation() { CityName = "City", StateOrProvinceCode = "PS", PostalCode = "H0H0H0"}
        });
        sourceModel.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "OTH", ReferenceIdentification = "1st type" });
        sourceModel.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentificationQualifier = "ZZZ", ReferenceIdentification = "2nd type" });
        sourceModel.Notes.Add(new NTE_NoteSpecialInstruction() { NoteReferenceCode = "ABC", Description = "Note1" });
        sourceModel.Notes.Add(new NTE_NoteSpecialInstruction() { NoteReferenceCode = "123", Description = "Note2" });
        sourceModel.Stops.Add(new StopOffDetails()
        {
            Detail = new S5_StopOffDetails()
            {
                StopSequenceNumber = 1,
                StopReasonCode = "AB"
            }
        });


        var expected = new Section();
        expected.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = sourceModel.ShipmentInformation.StandardCarrierAlphaCode, ShipmentIdentificationNumber = sourceModel.ShipmentInformation.ShipmentIdentificationNumber, ShipmentMethodOfPaymentCode = sourceModel.ShipmentInformation.ShipmentMethodOfPaymentCode });
        expected.Segments.Add(new B2A_SetPurpose { TransactionSetPurposeCode = sourceModel.SetPurpose.TransactionSetPurposeCode });
        expected.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = sourceModel.ReferenceNumbers[0].ReferenceIdentification, ReferenceIdentificationQualifier = sourceModel.ReferenceNumbers[0].ReferenceIdentificationQualifier });
        expected.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = sourceModel.ReferenceNumbers[1].ReferenceIdentification, ReferenceIdentificationQualifier = sourceModel.ReferenceNumbers[1].ReferenceIdentificationQualifier });
        expected.Segments.Add(new NTE_NoteSpecialInstruction { Description = sourceModel.Notes[0].Description, NoteReferenceCode = sourceModel.Notes[0].NoteReferenceCode });
        expected.Segments.Add(new NTE_NoteSpecialInstruction { Description = sourceModel.Notes[1].Description, NoteReferenceCode = sourceModel.Notes[1].NoteReferenceCode });
        expected.Segments.Add(new N1_PartyIdentification
        {
            EntityIdentifierCode = sourceModel.Entities[0].PartyIdentification.EntityIdentifierCode,
            Name = sourceModel.Entities[0].PartyIdentification.Name
        });

        expected.Segments.Add(new N3_PartyLocation
        {
            AddressInformation = sourceModel.Entities[0].PartyLocation[0].AddressInformation
        });

        expected.Segments.Add(new N4_GeographicLocation
        {
            CityName = sourceModel.Entities[0].GeographicLocation.CityName,
            StateOrProvinceCode = sourceModel.Entities[0].GeographicLocation.StateOrProvinceCode,
            PostalCode = sourceModel.Entities[0].GeographicLocation.PostalCode
        });

        expected.Segments.Add(new S5_StopOffDetails
        {
            StopSequenceNumber = sourceModel.Stops[0].Detail.StopSequenceNumber,
            StopReasonCode = sourceModel.Stops[0].Detail.StopReasonCode
        });

        var actual = sourceModel.ToDocumentSection("0001");
        for (var i = 0; i < Math.Max(actual.Segments.Count, expected.Segments.Count); i++) Assert.Equivalent(expected.Segments[i], actual.Segments[i], true);
    }

    [Fact]
    public void LoadDocument()
    {
        var data = @"ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*000003438*0*P*>~
	                    GS*SM*4405197800*999999999*20111219*1747*2100*X*004010~
	                    ST*204*0001~
	                    B2**XXXX**9999955559**PP~
	                    B2A*04~
	                    L11*NONPRIMARY*OK~
	                    MS3*XXXX*B**M~
	                    NTE**FROZEN GOODS SET TO -10d F~
	                    N1*PF*XYZ CORP*9*9995555500000~
	                    N3*31875 SOLON RD~
	                    N4*SOLON*OH*44139~
	                    N7**NONE*********FF****5300~
	                    S5*1*CL*27800*L*2444*CA*1016*E~
	                    L11*9999001947*DO~
	                    L11*9999670098*CR~
	                    L11*9999001866*DO~
	                    L11*9999669887*CR~";

        var document = x12Document.Parse(data);

        // var edi204 = new Edi204_MotorCarrierLoadTender();
        // edi204.LoadFrom(document.Sections[0]);
        var mapper = new DomainMapper(document.Sections[0].Segments);
        var edi204 = mapper.Map<Edi204_MotorCarrierLoadTender>();

        var expected = new Edi204_MotorCarrierLoadTender();
        expected.ShipmentInformation.StandardCarrierAlphaCode = "XXXX";
        expected.ShipmentInformation.ShipmentIdentificationNumber = "9999955559";
        expected.ShipmentInformation.ShipmentMethodOfPaymentCode = "PP";
        expected.SetPurpose = new B2A_SetPurpose { TransactionSetPurposeCode = "04" };
        expected.InterlineInformation = new MS3_InterlineInformation { StandardCarrierAlphaCode = "XXXX", TransportationMethodTypeCode = "M", RoutingSequenceCode = "B" };
        // expected.Receiver = "123456789012345";
        // expected.Sender = "ABCDEFGHIJKLMNO";
        //MS3 should be SCAC XXXX
        //Any Mode
        //Transit Method M
        //expected.Notes.Add("FROZEN GOODS SET TO -10d F")


        expected.Stops.Add(new StopOffDetails());
        expected.Stops[0].Detail = new S5_StopOffDetails
        {
            StopSequenceNumber = 1,
            StopReasonCode = "CL",
            Weight = 27800,
            WeightUnitCode = "L",
            NumberOfUnitsShipped = 2444,
            UnitOrBasisForMeasurementCode = "CA",
            Volume = 1016,
            VolumeUnitQualifier = "E"
        };
        expected.Stops[0].ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber() {ReferenceIdentificationQualifier = "DO", ReferenceIdentification = "9999001947" });
        expected.Stops[0].ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "CR", ReferenceIdentification = "9999670098" });
        expected.Stops[0].ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "DO", ReferenceIdentification = "9999001866" });
        expected.Stops[0].ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentificationQualifier = "CR", ReferenceIdentification = "9999669887" });


        //checking the stop first gives easier to read failures then when a collection compare fails
        Assert.Equivalent(expected.Stops[0], edi204.Stops[0]);
        Assert.Equivalent(expected, edi204);
    }
}
using EdiFact.Mapping;
using EdiParser.x12;
using EdiParser.x12.DomainModels;
using EdiParser.x12.DomainModels._204;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;
using Xunit.Abstractions;

namespace EdiParser.Tests.x12.Beta;

public class DomainMapperTests
{
    private readonly ITestOutputHelper _output;

    public DomainMapperTests(ITestOutputHelper output)
    {
        _output = output;
        Logging.LoggerFactory = new XUnitLoggingFactory(output);
    }

    [Fact]
    public void MapBasicObject()
    {
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { ShipmentQualifier = "123" });
        input.Segments.Add(new B2A_SetPurpose { TransactionSetPurposeCode = "A" });

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);
        Assert.Equivalent(input.Segments[1], result.SetPurpose);
    }

    [Fact]
    public void MapObjectThatImplementsISegmentConverter()
    {
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { ShipmentQualifier = "123" });
        input.Segments.Add(new G62_DateTime() { Date="20230101"});

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);
        Assert.Equivalent(new DateTime(2023,01,01) , result.OrderDate.GetDateTime());
    }

    [Fact]
    public void MapList()
    {
        var input = new Section();
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = "123" });
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = "456" });

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(2, result.ReferenceNumbers.Count);
        Assert.Equivalent(input.Segments[0], result.ReferenceNumbers[0]);
        Assert.Equivalent(input.Segments[1], result.ReferenceNumbers[1]);
    }

    [Fact]
    public void MapFirstLevelOfModel()
    {
        //minimal 204 sample
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = "XXXX" });
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = "123" });
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber { ReferenceIdentification = "456" });
        //OrderDate
        input.Segments.Add(new MS3_InterlineInformation { StandardCarrierAlphaCode = "XXXX" });
        input.Segments.Add(new NTE_Note { NoteReferenceCode = "A" });
        input.Segments.Add(new NTE_Note { NoteReferenceCode = "B" });
        //entities special map
        input.Segments.Add(new L3_TotalWeightAndCharges { Weight = 80 });

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);

        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);
        Assert.Equivalent(2, result.ReferenceNumbers.Count);
        Assert.Equivalent(input.Segments[1], result.ReferenceNumbers[0]);
        Assert.Equivalent(input.Segments[2], result.ReferenceNumbers[1]);
        Assert.Equivalent(input.Segments[3], result.InterlineInformation);
        Assert.Equivalent(input.Segments[4], result.Notes[0]);
        Assert.Equivalent(input.Segments[5], result.Notes[1]);
        Assert.Equivalent(input.Segments[6], result.Totals);
    }


    [Fact]
    public void MapChild()
    {
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = "XXXX" });
        // AT5,RTT,C3
        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialServicesCode = "AB" });
        input.Segments.Add(new RTT_FreightRateInformation() { RateValueQualifier = "AB" });
        input.Segments.Add(new C3_CurrencyIdentifier() { CurrencyCode = "USD" });

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);
        Assert.Equivalent(1, result.BillOfLadingHandlingInfo.Count);
        Assert.Equivalent(input.Segments[1], result.BillOfLadingHandlingInfo[0].HandlingRequirements);
        Assert.Equivalent(input.Segments[2], result.BillOfLadingHandlingInfo[0].FreightRateInformation);
        Assert.Equivalent(input.Segments[3], result.BillOfLadingHandlingInfo[0].Currency);

    }

    [Fact]
    public void MapMultipleChildren()
    {
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = "XXXX" });
        // AT5,RTT,C3
        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialServicesCode = "AB" });
        input.Segments.Add(new RTT_FreightRateInformation() { RateValueQualifier = "AB" });
        input.Segments.Add(new C3_CurrencyIdentifier() { CurrencyCode = "USD" });

        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialServicesCode = "AB" });
        input.Segments.Add(new RTT_FreightRateInformation() { RateValueQualifier = "AB" });
        input.Segments.Add(new C3_CurrencyIdentifier() { CurrencyCode = "USD" });

        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialServicesCode = "AB" });
        input.Segments.Add(new RTT_FreightRateInformation() { RateValueQualifier = "AB" });
        input.Segments.Add(new C3_CurrencyIdentifier() { CurrencyCode = "USD" });

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);
        Assert.Equivalent(3, result.BillOfLadingHandlingInfo.Count);
        Assert.Equivalent(input.Segments[1], result.BillOfLadingHandlingInfo[0].HandlingRequirements);
        Assert.Equivalent(input.Segments[2], result.BillOfLadingHandlingInfo[0].FreightRateInformation);
        Assert.Equivalent(input.Segments[3], result.BillOfLadingHandlingInfo[0].Currency);

        Assert.Equivalent(input.Segments[4], result.BillOfLadingHandlingInfo[1].HandlingRequirements);
        Assert.Equivalent(input.Segments[5], result.BillOfLadingHandlingInfo[1].FreightRateInformation);
        Assert.Equivalent(input.Segments[6], result.BillOfLadingHandlingInfo[1].Currency);


        Assert.Equivalent(input.Segments[7], result.BillOfLadingHandlingInfo[1].HandlingRequirements);
        Assert.Equivalent(input.Segments[8], result.BillOfLadingHandlingInfo[1].FreightRateInformation);
        Assert.Equivalent(input.Segments[9], result.BillOfLadingHandlingInfo[1].Currency);

    }

    [Fact]
    public void ChildrenOfChildren()
    {
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = "XXXX" });
        
        input.Segments.Add(new S5_StopOffDetails() { StopSequenceNumber = 1}); //index 1
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = "Stop1 - ID1"});
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = "Stop1 - ID2" });
        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialHandlingDescription = "Stop1 - Description1" });
        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialHandlingDescription = "Stop1 - Description2" });
        
        input.Segments.Add(new S5_StopOffDetails() { StopSequenceNumber = 2 }); //index 6
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = "Stop2 - ID1" });
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = "Stop2 - ID2" });
        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialHandlingDescription = "Stop2 - Description1" });
        input.Segments.Add(new AT5_BillOfLadingHandlingRequirements() { SpecialHandlingDescription = "Stop2 - Description2" });

        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);
        
        Assert.Equivalent(2, result.Stops.Count);
        Assert.Equivalent(2, result.Stops[0].ReferenceNumbers.Count);
        Assert.Equivalent(2, result.Stops[0].BillOfLadingHandlingRequirements.Count);
        Assert.Equivalent(2, result.Stops[1].ReferenceNumbers.Count);
        Assert.Equivalent(2, result.Stops[1].BillOfLadingHandlingRequirements.Count);

        //stop1
        Assert.Equivalent(input.Segments[1], result.Stops[0].Detail);
        Assert.Equivalent(input.Segments[2], result.Stops[0].ReferenceNumbers[0]);
        Assert.Equivalent(input.Segments[3], result.Stops[0].ReferenceNumbers[1]);
        Assert.Equivalent(input.Segments[4], result.Stops[0].BillOfLadingHandlingRequirements[0].HandlingRequirements);
        Assert.Equivalent(input.Segments[5], result.Stops[0].BillOfLadingHandlingRequirements[1].HandlingRequirements);
        
        //stop2
        Assert.Equivalent(input.Segments[6], result.Stops[1].Detail);
        Assert.Equivalent(input.Segments[7], result.Stops[1].ReferenceNumbers[0]);
        Assert.Equivalent(input.Segments[8], result.Stops[1].ReferenceNumbers[1]);
        Assert.Equivalent(input.Segments[9], result.Stops[1].BillOfLadingHandlingRequirements[0].HandlingRequirements);
        Assert.Equivalent(input.Segments[10], result.Stops[1].BillOfLadingHandlingRequirements[1].HandlingRequirements);


    }

    [Fact]
    public void SimpleChildrenOfChildren()
    {
        var input = new Section();
        input.Segments.Add(new B2_BeginningSegmentForShipmentInformationTransaction { StandardCarrierAlphaCode = "XXXX" });

        input.Segments.Add(new S5_StopOffDetails() { StopSequenceNumber = 1 });
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = "Stop1 - ID1" });
        
        input.Segments.Add(new S5_StopOffDetails() { StopSequenceNumber = 2 });
        input.Segments.Add(new L11_BusinessInstructionsAndReferenceNumber() { ReferenceIdentification = "Stop2 - ID1" });
        
        var subject = new DomainMapper(input.Segments);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();

        Assert.NotNull(result);
        Assert.Equivalent(input.Segments[0], result.ShipmentInformation);

        Assert.Equivalent(2, result.Stops.Count);
        Assert.Equivalent(1, result.Stops[0].ReferenceNumbers.Count);
        Assert.Equivalent(1, result.Stops[1].ReferenceNumbers.Count);
        
        //stop1
        Assert.Equivalent(input.Segments[1], result.Stops[0].Detail);
        Assert.Equivalent(input.Segments[2], result.Stops[0].ReferenceNumbers[0]);
        
        //stop2
        Assert.Equivalent(input.Segments[3], result.Stops[1].Detail);
        Assert.Equivalent(input.Segments[4], result.Stops[1].ReferenceNumbers[0]);
    }

    [Fact]
    public void MapComplexChild()
    {
        var input = new List<EdiX12Segment>();
        input.Add(new S5_StopOffDetails());
        input.Add(new N1_PartyIdentification());
        input.Add(new N3_PartyLocation());
        input.Add(new N4_GeographicLocation());
        
        var subject = new DomainMapper(input);
        var result = subject.Map<StopOffDetails>();


        Assert.NotNull(result);
        Assert.NotNull(result.Entity);
    }

    [Fact]
    public void MapBrokenFile()
    {
        var input = new List<EdiX12Segment>();
        input.Add(new B2_BeginningSegmentForShipmentInformationTransaction());
        input.Add(new B2A_SetPurpose());
        input.Add(new L11_BusinessInstructionsAndReferenceNumber());
        input.Add(new G62_DateTime());
        input.Add(new NTE_Note());
        input.Add(new N1_PartyIdentification());
        input.Add(new N3_PartyLocation());
        input.Add(new N4_GeographicLocation());
        input.Add(new N1_PartyIdentification());
        input.Add(new G61_Contact());
        input.Add(new G61_Contact());
        input.Add(new N7_EquipmentDetails());
        
        input.Add(new S5_StopOffDetails());
        input.Add(new L11_BusinessInstructionsAndReferenceNumber());
        input.Add(new G62_DateTime());
        input.Add(new G62_DateTime());
        input.Add(new NTE_Note());
        input.Add(new NTE_Note());
        input.Add(new N1_PartyIdentification());
        input.Add(new N3_PartyLocation());
        input.Add(new N4_GeographicLocation());
        input.Add(new G61_Contact());
        input.Add(new G61_Contact());

        var subject = new DomainMapper(input);
        var result = subject.Map<Edi204_MotorCarrierLoadTender>();


        Assert.NotNull(result);
        Assert.Equivalent(2, result.Entities.Count);
        Assert.Equivalent(1, result.EquipmentDetails.Count);
        Assert.Equivalent(1, result.Stops.Count);


        // OID* FV38*121549266 * *PL * 1 * L * 173
        // LAD******* LG*04.00 * W1 * 48 * HI * 48
        // L5 * 1 * Auto Parts****** N*70
        // S5 * 2 * UL
        // G62 * 68 * 20201120 * 5 * 0000
        // G62 * 54 * 20201120 * 5 * 0000
        // NTE* OTH*No Touch
        // NTE* PKG*Dimensions H(in)48 W(in)48 L(ft)04 L(in)00
        // N1* ST*APTIV - El Paso X-Dock(8062021) * ZZ * W12109350
        // N3 * 48 Walter Jones Blvd Spur Dr
        // N4* El Paso* TX*79906 * US
        // G61* CN*AV * TE * 8888888888
        // G61* CN*AV * EM * Arturo.villanueva@delphi.com
        // OID* FV38*121549266 * *PL * 1 * L * 173
        // LAD******* LG*04.00 * W1 * 48 * HI * 48
        // L5 * 1 * Auto Parts****** N*70
        // L3 * 173 * G * 92.5 * FR * 9944 * 694 * ****1
        // SE * 48 * 95009
        // ST * 204 * 95010
        // B2** PNII**340186386 * *TP
        // B2A * 04
        // L11* T5227893*VD
        // L11 * 1022519 - FV38 - FV38 - LTL - 20201117 * SI
        // L11 * -60838 - INBOUND * CR
        // L11* TMC29316343*OW
        // L11* USD*RB
        // L11* TMC APTIV* TH
        // G62 * 64 * 20201117 * 1 * 1407
        // NTE* ZZZ*0
        // N1* BT*Protrans * 93 * 39638
        // N3* PO Box 42069
        // N4* INDIANAPOLIS*IN * 46242
        // N1* VI*CH ROBINSON CONTACT
        // G61* CN*GERARDO MARTINEZ* TE*8181335600
        // G61* IC*GERARDO MARTINEZ* EM*MARTGERA@CHROBINSON.COM
        // G61* ZZ*TMC APTIV
        // N7** ZZZZ*173 * G * ******TV * ***0100 * ****0 * 0
        // S5 * 1 * LD
        // L11 * 1022519 * PU
        // G62 * 10 * 20201117 * 4 * 0800
        // G62 * 38 * 20201117 * 4 * 1600
        // NTE* OTH*No Touch
        // NTE* PKG*Dimensions H(in)48 W(in)48 L(ft)04 L(in)00
        // N1* SF*Hellermanntyton Corp(8036075) * ZZ * 1022519
        // N3 * 1485 Normantown Rd
        // N4* ROMEOVILLE*IL * 60446 * US
        // G61* CN*Mathew Z Binden*TE * (815) 372 - 4280
        // G61* CN*Mathew Z Binden*EM * MZbinden@htamericas.com
        // OID* FV38*121549266 * *PL * 1 * L * 173
        // LAD******* LG*04.00 * W1 * 48 * HI * 48
        // L5 * 1 * Auto Parts****** N*70
        // S5 * 2 * UL
        // G62 * 68 * 20201120 * 5 * 0000
        // G62 * 54 * 20201120 * 5 * 0000
        // NTE* OTH*No Touch
        // NTE* PKG*Dimensions H(in)48 W(in)48 L(ft)04 L(in)00
        // N1* ST*APTIV - El Paso X-Dock(8062021) * ZZ * W12109350
        // N3 * 48 Walter Jones Blvd Spur Dr
        // N4* El Paso* TX*79906 * US
        // G61* CN*AV * TE * 8888888888
        // G61* CN*AV * EM * Arturo.villanueva@delphi.com
        // OID* FV38*121549266 * *PL * 1 * L * 173
        // LAD******* LG*04.00 * W1 * 48 * HI * 48
        // L5 * 1 * Auto Parts****** N*70
        // L3 * 173 * G * 92.5 * FR * 9944 * 694 * ****1
    }
}
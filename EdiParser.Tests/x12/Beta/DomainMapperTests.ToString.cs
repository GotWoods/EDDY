using EdiParser.x12.DomainModels;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;

namespace EdiParser.Tests.x12.Beta;

public partial class DomainMapperTests
{
    [Fact]
    public void MapToString()
    {
        var doc = new Edi204_MotorCarrierLoadTender();
        doc.ShipmentInformation = new B2_BeginningSegmentForShipmentInformationTransaction();
        doc.SetPurpose = new B2A_SetPurpose();

        var subject = new DomainMapper();
        var result = subject.MapToSegments(doc);

        var expected = new List<EdiX12Segment>();
        expected.Add(new B2_BeginningSegmentForShipmentInformationTransaction());
        expected.Add(new B2A_SetPurpose());
        VerifyLines(expected, result);
    }

    [Fact]
    public void MapListToString()
    {
        var doc = new Edi204_MotorCarrierLoadTender();
        doc.ShipmentInformation = new B2_BeginningSegmentForShipmentInformationTransaction();
        doc.SetPurpose = new B2A_SetPurpose();
        doc.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber());
        doc.ReferenceNumbers.Add(new L11_BusinessInstructionsAndReferenceNumber());


        var subject = new DomainMapper();
        var result = subject.MapToSegments(doc);

        var expected = new List<EdiX12Segment>();
        expected.Add(new B2_BeginningSegmentForShipmentInformationTransaction());
        expected.Add(new B2A_SetPurpose());
        expected.Add(new L11_BusinessInstructionsAndReferenceNumber());
        expected.Add(new L11_BusinessInstructionsAndReferenceNumber());
        VerifyLines(expected, result);
    }

    [Fact]
    public void MapComplexListToString()
    {
        var doc = new Edi204_MotorCarrierLoadTender();
        doc.ShipmentInformation = new B2_BeginningSegmentForShipmentInformationTransaction();
        doc.SetPurpose = new B2A_SetPurpose();
        doc.Entities.Add(new Entity()
        {
            PartyIdentification = new N1_PartyIdentification(),
            GeographicLocation = new N4_GeographicLocation(),
            
        }) ;

        doc.Entities.Add(new Entity()
        {
            PartyIdentification = new N1_PartyIdentification(),
            GeographicLocation = new N4_GeographicLocation(),

        });


        var subject = new DomainMapper();
        var result = subject.MapToSegments(doc);

        var expected = new List<EdiX12Segment>();
        expected.Add(new B2_BeginningSegmentForShipmentInformationTransaction());
        expected.Add(new B2A_SetPurpose());
        expected.Add(new N1_PartyIdentification());
        expected.Add(new N4_GeographicLocation());
        expected.Add(new N1_PartyIdentification());
        expected.Add(new N4_GeographicLocation());
        VerifyLines(expected, result);
    }



    private void VerifyLines(List<EdiX12Segment> expected, List<EdiX12Segment> actual)
    {
        Assert.NotNull(actual);

        for (var index = 0; index < actual.Count; index++)
        {
            Assert.Equivalent(expected[index], actual[index]);
        }

    }
}
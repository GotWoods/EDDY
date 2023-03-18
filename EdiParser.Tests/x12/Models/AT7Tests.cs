using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AT7Tests
{
    [Fact]
    public void ShouldParse()
    {
        var expected = new AT7_ShipmentStatusDetails();
        expected.ShipmentStatusIndicatorCode = "11";
        expected.ShipmentStatusOrAppointmentReasonCode = "22";
        //expected.ShipmentAppointmentStatusCode = "AA";
        //expected.ShipmentStatusOrAppointmentReasonCode2 = "";
        expected.Date = "20080903";
        expected.Time = "16000000";
        expected.TimeCode = "ET";

        var actual = Map.MapObject<AT7_ShipmentStatusDetails>("AT7*11*22***20080903*16000000*ET", MapOptionsForTesting.x12DefaultEndsWithNewline);

        Assert.True(actual.ValidationResult.IsValid, actual.ValidationResult.ToString());
        Assert.Equivalent(expected, actual);
    }


    [Theory]
    [InlineData("11", null, true)] //just A set
    [InlineData(null, "12", true)] //just B set
    [InlineData("11", "12", false)] //both A and B set
    public void Validation_ShipmentStatusIndicatorCodeExclusiveOfShipmentAppointmentStatusCode(string shipmentStatusIndicatorCode, string shipmentAppoiuntmentStatusCode, bool isValidExpected)
    {
        var subject = new AT7_ShipmentStatusDetails();

        subject.ShipmentStatusIndicatorCode = shipmentStatusIndicatorCode;
        subject.ShipmentAppointmentStatusCode = shipmentAppoiuntmentStatusCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

    [Theory]
    [InlineData("AB", true)]
    [InlineData(null, false)]
    public void Validation_ShipmentStatusOrAppointmentReasonCode_Requires_ShipmentStatusIndicatorCode(string shipmentStatusIndicatorCode, bool isValidExpected)
    {
        var subject = new AT7_ShipmentStatusDetails();
        subject.ShipmentStatusOrAppointmentReasonCode = "11";
        subject.ShipmentStatusIndicatorCode = shipmentStatusIndicatorCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("12", true)]
    public void Validation_ShipmentStatusOrAppointmentReasonCode2_Requires_ShipmentAppointmentStatusCode(string shipmentAppointmentStatusCode, bool isValidExpected)
    {
        var subject = new AT7_ShipmentStatusDetails();
        subject.ShipmentStatusOrAppointmentReasonCode2 = "11";
        subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(null, null, false)]
    [InlineData("2300", null, false)]
    [InlineData("2300", "20230130", true)]
    public void Validation_TimeCode_Requires_Time(string time, string date, bool isValidExpected)
    {
        var subject = new AT7_ShipmentStatusDetails();
        subject.TimeCode = "AB";
        subject.Time = time;
        subject.Date = date;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}
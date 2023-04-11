using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B1Tests
{
    [Fact]
    public void ConvertToString()
    {
        var input = new B1_BeginningSegmentForBookingOrPickupDelivery()

        {
            StandardCarrierAlphaCode = "47",
            ShipmentIdentificationNumber = "7",
            Date = "dsfY6abA",
            ReservationActionCode = "y",
            YesNoConditionOrResponseCode = "O",
            ShipmentOrWorkAssignmentDeclineReasonCode = "tW9",
            ShipmentMethodOfPaymentCode = "wz",
        };

        string expected = "B1*47*7*dsfY6abA*y*O*tW9*wz";
        var actual = Map.SegmentToString(input, MapOptionsForTesting.x12DefaultEndsWithNewline).Trim();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "B1*47*7*dsfY6abA*y*O*tW9*wz";

        var expected = new B1_BeginningSegmentForBookingOrPickupDelivery()

        {
            StandardCarrierAlphaCode = "47",
            ShipmentIdentificationNumber = "7",
            Date = "dsfY6abA",
            ReservationActionCode = "y",
            YesNoConditionOrResponseCode = "O",
            ShipmentOrWorkAssignmentDeclineReasonCode = "tW9",
            ShipmentMethodOfPaymentCode = "wz",
        };

        var actual = Map.MapObject<B1_BeginningSegmentForBookingOrPickupDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
    {
        var subject = new B1_BeginningSegmentForBookingOrPickupDelivery();
        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}
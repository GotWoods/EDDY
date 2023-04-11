using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ATATests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ATA*Uu*w*G2Uk7b44";

        var expected = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest
        {
            StandardCarrierAlphaCode = "Uu",
            ReferenceIdentification = "w",
            Date = "G2Uk7b44"
        };

        var actual = Map.MapObject<ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Uu", true)]
    public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
    {
        var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
        subject.ReferenceIdentification = "w";
        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("w", true)]
    public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
    {
        var subject = new ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest();
        subject.StandardCarrierAlphaCode = "Uu";
        subject.ReferenceIdentification = referenceIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}
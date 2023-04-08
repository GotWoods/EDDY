using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ARSTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ARS*N*N*p5*9*R";

        var expected = new ARS_ApplicantResidenceSpecifics
        {
            TypeOfResidenceCode = "N",
            PropertyOwnershipRightsCode = "N",
            RateValueQualifier = "p5",
            MonetaryAmount = 9,
            ReferenceIdentification = "R"
        };

        var actual = Map.MapObject<ARS_ApplicantResidenceSpecifics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("N", true)]
    public void Validatation_RequiredTypeOfResidenceCode(string typeOfResidenceCode, bool isValidExpected)
    {
        var subject = new ARS_ApplicantResidenceSpecifics();
        subject.PropertyOwnershipRightsCode = "N";
        subject.TypeOfResidenceCode = typeOfResidenceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("N", true)]
    public void Validatation_RequiredPropertyOwnershipRightsCode(string propertyOwnershipRightsCode, bool isValidExpected)
    {
        var subject = new ARS_ApplicantResidenceSpecifics();
        subject.TypeOfResidenceCode = "N";
        subject.PropertyOwnershipRightsCode = propertyOwnershipRightsCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}
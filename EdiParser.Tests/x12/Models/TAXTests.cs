using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class TAXTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "TAX*S*n*u*y*3*w*I*j*L*v*m*t*4";

        var expected = new TAX_TaxReference()
        {
            TaxIdentificationNumber = "S",
            LocationQualifier = "n",
            LocationIdentifier = "u",
            LocationQualifier2 = "y",
            LocationIdentifier2 = "3",
            LocationQualifier3 = "w",
            LocationIdentifier3 = "I",
            LocationQualifier4 = "j",
            LocationIdentifier4 = "L",
            LocationQualifier5 = "v",
            LocationIdentifier5 = "m",
            TaxExemptCode = "t",
            CustomsEntryTypeGroupCode = "4",
        };

        var actual = Map.MapObject<TAX_TaxReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneTaxIdentificationNumber(string taxIdentificationNumber, string locationIdentifier, bool isValidExpected)
    {
        var subject = new TAX_TaxReference();
        subject.TaxIdentificationNumber = taxIdentificationNumber;
        subject.LocationIdentifier = locationIdentifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
    {
        var subject = new TAX_TaxReference();
        subject.LocationQualifier = locationQualifier;
        subject.LocationIdentifier = locationIdentifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredLocationQualifier2(string locationQualifier2, string locationIdentifier2, bool isValidExpected)
    {
        var subject = new TAX_TaxReference();
        subject.LocationQualifier2 = locationQualifier2;
        subject.LocationIdentifier2 = locationIdentifier2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredLocationQualifier3(string locationQualifier3, string locationIdentifier3, bool isValidExpected)
    {
        var subject = new TAX_TaxReference();
        subject.LocationQualifier3 = locationQualifier3;
        subject.LocationIdentifier3 = locationIdentifier3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredLocationQualifier4(string locationQualifier4, string locationIdentifier4, bool isValidExpected)
    {
        var subject = new TAX_TaxReference();
        subject.LocationQualifier4 = locationQualifier4;
        subject.LocationIdentifier4 = locationIdentifier4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredLocationQualifier5(string locationQualifier5, string locationIdentifier5, bool isValidExpected)
    {
        var subject = new TAX_TaxReference();
        subject.LocationQualifier5 = locationQualifier5;
        subject.LocationIdentifier5 = locationIdentifier5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}
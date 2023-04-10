using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C022Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "y*o*hx*J*4*8*N*I**7";

        var expected = new C022_HealthCareCodeInformation()
        {
            CodeListQualifierCode = "y",
            IndustryCode = "o",
            DateTimePeriodFormatQualifier = "hx",
            DateTimePeriod = "J",
            MonetaryAmount = 4,
            Quantity = 8,
            VersionIdentifier = "N",
            IndustryCode2 = "I",
         //   IndustryCode3 = "U",
            IndustryCode4 = "7",
        };

        var actual = Map.MapObject<C022_HealthCareCodeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("y", true)]
    public void Validatation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
    {
        var subject = new C022_HealthCareCodeInformation();
        subject.IndustryCode = "o";
        subject.CodeListQualifierCode = codeListQualifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o", true)]
    public void Validatation_RequiredIndustryCode(string industryCode, bool isValidExpected)
    {
        var subject = new C022_HealthCareCodeInformation();
        subject.CodeListQualifierCode = "y";
        subject.IndustryCode = industryCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("hx", "J", true)]
    [InlineData("", "J", false)]
    [InlineData("hx", "", false)]
    public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
    {
        var subject = new C022_HealthCareCodeInformation();
        subject.CodeListQualifierCode = "y";
        subject.IndustryCode = "o";
        subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
        subject.DateTimePeriod = dateTimePeriod;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("I", "U", false)]
    [InlineData("", "U", true)]
    [InlineData("I", "", true)]
    public void Validation_OnlyOneOfIndustryCode2(string industryCode2, string industryCode3, bool isValidExpected)
    {
        var subject = new C022_HealthCareCodeInformation();
        subject.CodeListQualifierCode = "y";
        subject.IndustryCode = "o";
        subject.IndustryCode2 = industryCode2;
        subject.IndustryCode3 = industryCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

}
using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PWKTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "PWK*ML*U*4*ql*c*vr*H**8*x*m";

        var expected = new PWK_Paperwork()
        {
            ReportTypeCode = "ML",
            ReportTransmissionCode = "U",
            ReportCopiesNeeded = 4,
            EntityIdentifierCode = "ql",
            IdentificationCodeQualifier = "c",
            IdentificationCode = "vr",
            Description = "H",
            //ActionsIndicated = "",
            RequestCategoryCode = "8",
            CodeListQualifierCode = "x",
            IndustryCode = "m",
        };

        var actual = Map.MapObject<PWK_Paperwork>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("ML", true)]
    public void Validation_RequiredReportTypeCode(string reportTypeCode, bool isValidExpected)
    {
        var subject = new PWK_Paperwork();
        subject.ReportTypeCode = reportTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
    {
        var subject = new PWK_Paperwork();
        subject.ReportTypeCode = "ML";
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        subject.IdentificationCode = identificationCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
    {
        var subject = new PWK_Paperwork();
        subject.ReportTypeCode = "ML";
        subject.CodeListQualifierCode = codeListQualifierCode;
        subject.IndustryCode = industryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}
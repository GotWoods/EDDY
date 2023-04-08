using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class APITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "API*jT*4*4NU*dfP*D*D*L*b";

        var expected = new API_ActivityOrProcessInformation
        {
            CodeCategory = "jT",
            ActionCode = "4",
            MaintenanceTypeCode = "4NU",
            StatusReasonCode = "dfP",
            AffectedAreaOrSectionCode = "D",
            InsuranceTypeCode = "D",
            LoanTypeCode = "L",
            InformationStatusCode = "b"
        };

        var actual = Map.MapObject<API_ActivityOrProcessInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("jT", true)]
    public void Validatation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
    {
        var subject = new API_ActivityOrProcessInformation();
        subject.CodeCategory = codeCategory;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}
using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C002Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N*M*L*C*H";

        var expected = new C002_ActionsIndicated()
        {
            PaperworkReportActionCode = "N",
            PaperworkReportActionCode2 = "M",
            PaperworkReportActionCode3 = "L",
            PaperworkReportActionCode4 = "C",
            PaperworkReportActionCode5 = "H",
        };

        var actual = Map.MapObject<C002_ActionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("N", true)]
    public void Validation_RequiredPaperworkReportActionCode(string paperworkReportActionCode, bool isValidExpected)
    {
        var subject = new C002_ActionsIndicated();
        subject.PaperworkReportActionCode = paperworkReportActionCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}
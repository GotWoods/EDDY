using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ASITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ASI*L*4mI*u2U";

        var expected = new ASI_ActionOrStatusIndicator
        {
            ActionCode = "L",
            MaintenanceTypeCode = "4mI",
            StatusReasonCode = "u2U"
        };

        var actual = Map.MapObject<ASI_ActionOrStatusIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("L", true)]
    public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
    {
        var subject = new ASI_ActionOrStatusIndicator();
        subject.MaintenanceTypeCode = "4mI";
        subject.ActionCode = actionCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("4mI", true)]
    public void Validation_RequiredMaintenanceTypeCode(string maintenanceTypeCode, bool isValidExpected)
    {
        var subject = new ASI_ActionOrStatusIndicator();
        subject.ActionCode = "L";
        subject.MaintenanceTypeCode = maintenanceTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}
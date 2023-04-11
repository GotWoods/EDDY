using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G62Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "G62*12*20230130";

        var expected = new G62_DateTime
        {
            DateQualifier = "12",
            Date = "20230130"
        };

        var actual = Map.MapObject<G62_DateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);

        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("12", "20230130", "13", "0645", true)]
    [InlineData("12", "20230130", null, null, true)]
    [InlineData(null, null, "13", "0645", true)]
    [InlineData(null, null, null, null, false)]
    // [InlineData(null, "20230130", "13", "0645", false)]
    // [InlineData("12", null, "13", "0645", false)]
    //
    public void Validation_RequiredFields(string dateQualifier, string date, string timeQualifier, string time, bool isValidExpected)
    {
        var subject = new G62_DateTime();
        subject.DateQualifier = dateQualifier;
        subject.Date = date;

        subject.TimeQualifier = timeQualifier;
        subject.Time = time;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AorBRequired);
    }
}
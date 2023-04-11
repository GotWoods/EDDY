using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MANTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "MAN*5X*AfC8SIKhfE9mbPo1vRDwRuIt5iI7i29Hwzk7yFJqNZVs3YSY*7W5cvHqHKQBum7erq6KypNjLO9zeQahEY2aTQhQbx3El9YUY*cr*3d8Evu3cgz9VQ2GfBz7zlQt3eWZhjFrXi3TCravsy5MeWf4x*OvzOGQ2nNjiyjTVjsckJ9gDPv6XdPEl8BvJaCRNuP3kMhzYN";

        var expected = new MAN_MarksAndNumbersInformation
        {
            MarksAndNumbersQualifier = "5X",
            MarksAndNumbers = "AfC8SIKhfE9mbPo1vRDwRuIt5iI7i29Hwzk7yFJqNZVs3YSY",
            MarksAndNumbers2 = "7W5cvHqHKQBum7erq6KypNjLO9zeQahEY2aTQhQbx3El9YUY",
            MarksAndNumbersQualifier2 = "cr",
            MarksAndNumbers3 = "3d8Evu3cgz9VQ2GfBz7zlQt3eWZhjFrXi3TCravsy5MeWf4x",
            MarksAndNumbers4 = "OvzOGQ2nNjiyjTVjsckJ9gDPv6XdPEl8BvJaCRNuP3kMhzYN"
        };

        var actual = Map.MapObject<MAN_MarksAndNumbersInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("5X", true)]
    public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
    {
        var subject = new MAN_MarksAndNumbersInformation();
        subject.MarksAndNumbers = "AfC8SIKhfE9mbPo1vRDwRuIt5iI7i29Hwzk7yFJqNZVs3YSY";
        subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("AfC8SIKhfE9mbPo1vRDwRuIt5iI7i29Hwzk7yFJqNZVs3YSY", true)]
    public void Validation_RequiredMarksAndNumbers(string marksAndNumbers, bool isValidExpected)
    {
        var subject = new MAN_MarksAndNumbersInformation();
        subject.MarksAndNumbersQualifier = "5X";
        subject.MarksAndNumbers = marksAndNumbers;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredMarksAndNumbersQualifier2(string marksAndNumbersQualifier2, string marksAndNumbers3, bool isValidExpected)
    {
        var subject = new MAN_MarksAndNumbersInformation();
        subject.MarksAndNumbersQualifier = "5X";
        subject.MarksAndNumbers = "AfC8SIKhfE9mbPo1vRDwRuIt5iI7i29Hwzk7yFJqNZVs3YSY";
        subject.MarksAndNumbersQualifier2 = marksAndNumbersQualifier2;
        subject.MarksAndNumbers3 = marksAndNumbers3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBMarksAndNumbers4(string marksAndNumbers4, string marksAndNumbers3, bool isValidExpected)
    {
        var subject = new MAN_MarksAndNumbersInformation();
        subject.MarksAndNumbersQualifier = "5X";
        subject.MarksAndNumbers = "AfC8SIKhfE9mbPo1vRDwRuIt5iI7i29Hwzk7yFJqNZVs3YSY";
        subject.MarksAndNumbers4 = marksAndNumbers4;
        subject.MarksAndNumbers3 = marksAndNumbers3;

        if (marksAndNumbers3 != "") //very strange that setting #3 requires #2 but verified against standard
            subject.MarksAndNumbersQualifier2 = "v2";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}
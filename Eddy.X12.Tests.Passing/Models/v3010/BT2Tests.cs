using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BT2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT2*v*98*r*13";

		var expected = new BT2_EndOfFiscalTimePeriod()
		{
			TimePeriodQualifier = "v",
			TimePeriodCompleted = 98,
			TimePeriodQualifier2 = "r",
			TimePeriodCompleted2 = 13,
		};

		var actual = Map.MapObject<BT2_EndOfFiscalTimePeriod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new BT2_EndOfFiscalTimePeriod();
		subject.TimePeriodCompleted = 98;
		subject.TimePeriodQualifier = timePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(98, true)]
	public void Validation_RequiredTimePeriodCompleted(int timePeriodCompleted, bool isValidExpected)
	{
		var subject = new BT2_EndOfFiscalTimePeriod();
		subject.TimePeriodQualifier = "v";
		if (timePeriodCompleted > 0)
			subject.TimePeriodCompleted = timePeriodCompleted;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

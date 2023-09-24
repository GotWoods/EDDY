using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BT2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BT2*7*72*l*99";

		var expected = new BT2_EndOfFiscalTimePeriod()
		{
			TimePeriodQualifier = "7",
			TimePeriodCompleted = 72,
			TimePeriodQualifier2 = "l",
			TimePeriodCompleted2 = 99,
		};

		var actual = Map.MapObject<BT2_EndOfFiscalTimePeriod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredTimePeriodQualifier(string timePeriodQualifier, bool isValidExpected)
	{
		var subject = new BT2_EndOfFiscalTimePeriod();
		subject.TimePeriodCompleted = 72;
		subject.TimePeriodQualifier = timePeriodQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimePeriodQualifier2) || !string.IsNullOrEmpty(subject.TimePeriodQualifier2) || subject.TimePeriodCompleted2 > 0)
		{
			subject.TimePeriodQualifier2 = "l";
			subject.TimePeriodCompleted2 = 99;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(72, true)]
	public void Validation_RequiredTimePeriodCompleted(int timePeriodCompleted, bool isValidExpected)
	{
		var subject = new BT2_EndOfFiscalTimePeriod();
		subject.TimePeriodQualifier = "7";
		if (timePeriodCompleted > 0)
			subject.TimePeriodCompleted = timePeriodCompleted;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TimePeriodQualifier2) || !string.IsNullOrEmpty(subject.TimePeriodQualifier2) || subject.TimePeriodCompleted2 > 0)
		{
			subject.TimePeriodQualifier2 = "l";
			subject.TimePeriodCompleted2 = 99;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("l", 99, true)]
	[InlineData("l", 0, false)]
	[InlineData("", 99, false)]
	public void Validation_AllAreRequiredTimePeriodQualifier2(string timePeriodQualifier2, int timePeriodCompleted2, bool isValidExpected)
	{
		var subject = new BT2_EndOfFiscalTimePeriod();
		subject.TimePeriodQualifier = "7";
		subject.TimePeriodCompleted = 72;
		subject.TimePeriodQualifier2 = timePeriodQualifier2;
		if (timePeriodCompleted2 > 0)
			subject.TimePeriodCompleted2 = timePeriodCompleted2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

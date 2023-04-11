using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LID*iK*i*v*5*K*h*V*d*y";

		var expected = new LID_LossInformationDescription()
		{
			DateTimePeriodFormatQualifier = "iK",
			DateTimePeriod = "i",
			IndustryCode = "v",
			IndustryCode2 = "5",
			Description = "K",
			YesNoConditionOrResponseCode = "h",
			YesNoConditionOrResponseCode2 = "V",
			Description2 = "d",
			YesNoConditionOrResponseCode3 = "y",
		};

		var actual = Map.MapObject<LID_LossInformationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iK", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		subject.DateTimePeriod = "i";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		subject.DateTimePeriodFormatQualifier = "iK";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

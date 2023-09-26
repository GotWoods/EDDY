using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LID*PW*d*a*S*d*G*s*Q*J";

		var expected = new LID_LossInformationDescription()
		{
			DateTimePeriodFormatQualifier = "PW",
			DateTimePeriod = "d",
			IndustryCode = "a",
			IndustryCode2 = "S",
			Description = "d",
			YesNoConditionOrResponseCode = "G",
			YesNoConditionOrResponseCode2 = "s",
			Description2 = "Q",
			YesNoConditionOrResponseCode3 = "J",
		};

		var actual = Map.MapObject<LID_LossInformationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PW", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriod = "d";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "PW";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

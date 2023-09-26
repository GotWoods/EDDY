using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LID*VJ*D*X*5*Y*o*X*X";

		var expected = new LID_LossInformationDescription()
		{
			DateTimePeriodFormatQualifier = "VJ",
			DateTimePeriod = "D",
			IndustryCode = "X",
			IndustryCode2 = "5",
			Description = "Y",
			YesNoConditionOrResponseCode = "o",
			YesNoConditionOrResponseCode2 = "X",
			Description2 = "X",
		};

		var actual = Map.MapObject<LID_LossInformationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VJ", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "VJ";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

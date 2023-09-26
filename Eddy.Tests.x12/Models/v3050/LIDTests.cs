using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LID*ls*B*7*X*1*S*U*H*t";

		var expected = new LID_LossInformationDescription()
		{
			DateTimePeriodFormatQualifier = "ls",
			DateTimePeriod = "B",
			IndustryCode = "7",
			IndustryCode2 = "X",
			Description = "1",
			YesNoConditionOrResponseCode = "S",
			YesNoConditionOrResponseCode2 = "U",
			Description2 = "H",
			IndustryCode3 = "t",
		};

		var actual = Map.MapObject<LID_LossInformationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ls", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriod = "B";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "ls";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

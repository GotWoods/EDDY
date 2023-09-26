using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LID*Ft*3*U*2*e*4*T*u";

		var expected = new LID_LossInformationDescription()
		{
			DateTimePeriodFormatQualifier = "Ft",
			DateTimePeriod = "3",
			IndustryCode = "U",
			IndustryCode2 = "2",
			Description = "e",
			YesNoConditionOrResponseCode = "4",
			YesNoConditionOrResponseCode2 = "T",
			Description2 = "u",
		};

		var actual = Map.MapObject<LID_LossInformationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ft", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriod = "3";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new LID_LossInformationDescription();
		//Required fields
		subject.DateTimePeriodFormatQualifier = "Ft";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

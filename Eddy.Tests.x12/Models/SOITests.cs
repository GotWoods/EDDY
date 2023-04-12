using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SOITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SOI*oL*3w*t*3*S";

		var expected = new SOI_SourceOfIncome()
		{
			TypeOfIncomeCode = "oL",
			DateTimePeriodFormatQualifier = "3w",
			DateTimePeriod = "t",
			Number = 3,
			YesNoConditionOrResponseCode = "S",
		};

		var actual = Map.MapObject<SOI_SourceOfIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oL", true)]
	public void Validation_RequiredTypeOfIncomeCode(string typeOfIncomeCode, bool isValidExpected)
	{
		var subject = new SOI_SourceOfIncome();
		subject.TypeOfIncomeCode = typeOfIncomeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3w", "t", true)]
	[InlineData("", "t", false)]
	[InlineData("3w", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SOI_SourceOfIncome();
		subject.TypeOfIncomeCode = "oL";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

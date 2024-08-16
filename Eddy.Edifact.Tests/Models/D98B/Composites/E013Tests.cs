using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class E013Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Q:S:R:O";

		var expected = new E013_DateAndTimeInformation()
		{
			DateTimePeriodQualifier = "Q",
			DateTimePeriod = "S",
			DateTimePeriodFormatQualifier = "R",
			FreeText = "O",
		};

		var actual = Map.MapComposite<E013_DateAndTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredDateTimePeriodQualifier(string dateTimePeriodQualifier, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateTimePeriod = "S";
		//Test Parameters
		subject.DateTimePeriodQualifier = dateTimePeriodQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateTimePeriodQualifier = "Q";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

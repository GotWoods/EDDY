using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E013Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:l:a:u";

		var expected = new E013_DateAndTimeInformation()
		{
			DateOrTimeOrPeriodFunctionCodeQualifier = "i",
			DateOrTimeOrPeriodValue = "l",
			DateOrTimeOrPeriodFormatCode = "a",
			FreeTextValue = "u",
		};

		var actual = Map.MapComposite<E013_DateAndTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDateOrTimeOrPeriodFunctionCodeQualifier(string dateOrTimeOrPeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateOrTimeOrPeriodValue = "l";
		//Test Parameters
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = dateOrTimeOrPeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredDateOrTimeOrPeriodValue(string dateOrTimeOrPeriodValue, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = "i";
		//Test Parameters
		subject.DateOrTimeOrPeriodValue = dateOrTimeOrPeriodValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

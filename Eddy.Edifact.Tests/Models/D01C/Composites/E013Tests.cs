using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E013Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:D:U:O";

		var expected = new E013_DateAndTimeInformation()
		{
			DateOrTimeOrPeriodFunctionCodeQualifier = "5",
			DateOrTimeOrPeriodValue = "D",
			DateOrTimeOrPeriodFormatCode = "U",
			FreeText = "O",
		};

		var actual = Map.MapComposite<E013_DateAndTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDateOrTimeOrPeriodFunctionCodeQualifier(string dateOrTimeOrPeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateOrTimeOrPeriodValue = "D";
		//Test Parameters
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = dateOrTimeOrPeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateOrTimeOrPeriodValue(string dateOrTimeOrPeriodValue, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = "5";
		//Test Parameters
		subject.DateOrTimeOrPeriodValue = dateOrTimeOrPeriodValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

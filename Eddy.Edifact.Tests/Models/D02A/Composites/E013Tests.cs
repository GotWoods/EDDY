using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class E013Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0:z:W:g";

		var expected = new E013_DateAndTimeInformation()
		{
			DateOrTimeOrPeriodFunctionCodeQualifier = "0",
			DateOrTimeOrPeriodText = "z",
			DateOrTimeOrPeriodFormatCode = "W",
			FreeText = "g",
		};

		var actual = Map.MapComposite<E013_DateAndTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredDateOrTimeOrPeriodFunctionCodeQualifier(string dateOrTimeOrPeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateOrTimeOrPeriodText = "z";
		//Test Parameters
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = dateOrTimeOrPeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDateOrTimeOrPeriodText(string dateOrTimeOrPeriodText, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = "0";
		//Test Parameters
		subject.DateOrTimeOrPeriodText = dateOrTimeOrPeriodText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

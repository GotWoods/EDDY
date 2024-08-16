using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E013Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:V:L:S";

		var expected = new E013_DateAndTimeInformation()
		{
			DateTimePeriodFunctionCodeQualifier = "U",
			DateTimePeriodValue = "V",
			DateTimePeriodFormatCode = "L",
			FreeTextValue = "S",
		};

		var actual = Map.MapComposite<E013_DateAndTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredDateTimePeriodFunctionCodeQualifier(string dateTimePeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateTimePeriodValue = "V";
		//Test Parameters
		subject.DateTimePeriodFunctionCodeQualifier = dateTimePeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredDateTimePeriodValue(string dateTimePeriodValue, bool isValidExpected)
	{
		var subject = new E013_DateAndTimeInformation();
		//Required fields
		subject.DateTimePeriodFunctionCodeQualifier = "U";
		//Test Parameters
		subject.DateTimePeriodValue = dateTimePeriodValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

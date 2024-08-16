using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class E507Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:8:h";

		var expected = new E507_DateTimePeriod()
		{
			DateOrTimeOrPeriodFunctionCodeQualifier = "A",
			DateOrTimeOrPeriodText = "8",
			DateOrTimeOrPeriodFormatCode = "h",
		};

		var actual = Map.MapComposite<E507_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateOrTimeOrPeriodFunctionCodeQualifier(string dateOrTimeOrPeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E507_DateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = dateOrTimeOrPeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

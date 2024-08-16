using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E507Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:F:c";

		var expected = new E507_DateTimePeriod()
		{
			DateOrTimeOrPeriodFunctionCodeQualifier = "S",
			DateOrTimeOrPeriodValue = "F",
			DateOrTimeOrPeriodFormatCode = "c",
		};

		var actual = Map.MapComposite<E507_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredDateOrTimeOrPeriodFunctionCodeQualifier(string dateOrTimeOrPeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E507_DateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = dateOrTimeOrPeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

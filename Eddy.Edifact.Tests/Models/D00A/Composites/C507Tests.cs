using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C507Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:R:n";

		var expected = new C507_DateTimePeriod()
		{
			DateOrTimeOrPeriodFunctionCodeQualifier = "A",
			DateOrTimeOrPeriodValue = "R",
			DateOrTimeOrPeriodFormatCode = "n",
		};

		var actual = Map.MapComposite<C507_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateOrTimeOrPeriodFunctionCodeQualifier(string dateOrTimeOrPeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new C507_DateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateOrTimeOrPeriodFunctionCodeQualifier = dateOrTimeOrPeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

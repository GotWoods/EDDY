using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E507Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:H:b";

		var expected = new E507_DateTimePeriod()
		{
			DateTimePeriodFunctionCodeQualifier = "t",
			DateTimePeriodValue = "H",
			DateTimePeriodFormatCode = "b",
		};

		var actual = Map.MapComposite<E507_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredDateTimePeriodFunctionCodeQualifier(string dateTimePeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E507_DateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFunctionCodeQualifier = dateTimePeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

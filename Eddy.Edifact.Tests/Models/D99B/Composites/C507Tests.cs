using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C507Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:Y:6";

		var expected = new C507_DateTimePeriod()
		{
			DateTimePeriodFunctionCodeQualifier = "G",
			DateTimePeriodValue = "Y",
			DateTimePeriodFormatCode = "6",
		};

		var actual = Map.MapComposite<C507_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredDateTimePeriodFunctionCodeQualifier(string dateTimePeriodFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new C507_DateTimePeriod();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFunctionCodeQualifier = dateTimePeriodFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

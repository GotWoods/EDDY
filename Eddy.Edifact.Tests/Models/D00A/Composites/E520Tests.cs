using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E520Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:p:S:g";

		var expected = new E520_Frequency()
		{
			FrequencyValue = "f",
			MeasurementUnitCode = "p",
			DateOrTimeOrPeriodValue = "S",
			DateOrTimeOrPeriodFormatCode = "g",
		};

		var actual = Map.MapComposite<E520_Frequency>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredFrequencyValue(string frequencyValue, bool isValidExpected)
	{
		var subject = new E520_Frequency();
		//Required fields
		//Test Parameters
		subject.FrequencyValue = frequencyValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

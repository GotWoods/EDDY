using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E520Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:G:f:H";

		var expected = new E520_Frequency()
		{
			FrequencyRate = "Y",
			MeasurementUnitCode = "G",
			DateOrTimeOrPeriodValue = "f",
			DateOrTimeOrPeriodFormatCode = "H",
		};

		var actual = Map.MapComposite<E520_Frequency>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredFrequencyRate(string frequencyRate, bool isValidExpected)
	{
		var subject = new E520_Frequency();
		//Required fields
		//Test Parameters
		subject.FrequencyRate = frequencyRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

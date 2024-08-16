using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E520Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:m:b:d";

		var expected = new E520_Frequency()
		{
			FrequencyRate = "E",
			MeasurementUnitCode = "m",
			DateOrTimeOrPeriodText = "b",
			DateOrTimeOrPeriodFormatCode = "d",
		};

		var actual = Map.MapComposite<E520_Frequency>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredFrequencyRate(string frequencyRate, bool isValidExpected)
	{
		var subject = new E520_Frequency();
		//Required fields
		//Test Parameters
		subject.FrequencyRate = frequencyRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class E520Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "u:l:n:X";

		var expected = new E520_Frequency()
		{
			FrequencyRate = "u",
			MeasurementUnitCode = "l",
			DateOrTimeOrPeriodText = "n",
			DateOrTimeOrPeriodFormatCode = "X",
		};

		var actual = Map.MapComposite<E520_Frequency>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredFrequencyRate(string frequencyRate, bool isValidExpected)
	{
		var subject = new E520_Frequency();
		//Required fields
		//Test Parameters
		subject.FrequencyRate = frequencyRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PMP*0Y*8e*7*M";

		var expected = new PMP_PerformanceMeasures()
		{
			FrequencyPatternCode = "0Y",
			OutOfStockDeterminationMethodCode = "8e",
			MeasurementQualifier = "7",
			FrequencyCode = "M",
		};

		var actual = Map.MapObject<PMP_PerformanceMeasures>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0Y", true)]
	public void Validation_RequiredFrequencyPatternCode(string frequencyPatternCode, bool isValidExpected)
	{
		var subject = new PMP_PerformanceMeasures();
		subject.FrequencyPatternCode = frequencyPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

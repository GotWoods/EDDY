using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class PMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PMP*Tj*fs*y*a";

		var expected = new PMP_PerformanceMeasures()
		{
			FrequencyPatternCode = "Tj",
			OutOfStockDeterminationMethodCode = "fs",
			MeasurementQualifier = "y",
			FrequencyCode = "a",
		};

		var actual = Map.MapObject<PMP_PerformanceMeasures>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tj", true)]
	public void Validation_RequiredFrequencyPatternCode(string frequencyPatternCode, bool isValidExpected)
	{
		var subject = new PMP_PerformanceMeasures();
		//Required fields
		//Test Parameters
		subject.FrequencyPatternCode = frequencyPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

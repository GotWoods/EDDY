using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "d:0:o:e";

		var expected = new E211_Dimensions()
		{
			MeasurementUnitCode = "d",
			LengthDimensionValue = "0",
			WidthDimensionValue = "o",
			HeightDimensionValue = "e",
		};

		var actual = Map.MapComposite<E211_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new E211_Dimensions();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

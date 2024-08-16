using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "0:C:K:1";

		var expected = new C211_Dimensions()
		{
			MeasurementUnitCode = "0",
			LengthDimensionValue = "C",
			WidthDimensionValue = "K",
			HeightDimensionValue = "1",
		};

		var actual = Map.MapComposite<C211_Dimensions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new C211_Dimensions();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

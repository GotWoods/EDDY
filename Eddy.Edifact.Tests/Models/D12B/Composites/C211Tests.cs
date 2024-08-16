using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D12B;
using Eddy.Edifact.Models.D12B.Composites;

namespace Eddy.Edifact.Tests.Models.D12B.Composites;

public class C211Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "0:Q:X:y:m";

		var expected = new C211_Dimensions()
		{
			MeasurementUnitCode = "0",
			LengthMeasure = "Q",
			WidthMeasure = "X",
			HeightMeasure = "y",
			DiameterMeasure = "m",
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

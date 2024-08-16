using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C174Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "R:q:E:7:I";

		var expected = new C174_ValueRange()
		{
			MeasurementUnitCode = "R",
			Measure = "q",
			RangeMinimumQuantity = "E",
			RangeMaximumQuantity = "7",
			SignificantDigitsQuantity = "I",
		};

		var actual = Map.MapComposite<C174_ValueRange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new C174_ValueRange();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C280Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:U:m";

		var expected = new C280_Range()
		{
			MeasurementUnitCode = "m",
			RangeMinimumQuantity = "U",
			RangeMaximumQuantity = "m",
		};

		var actual = Map.MapComposite<C280_Range>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new C280_Range();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

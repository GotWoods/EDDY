using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C280Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:9:n";

		var expected = new C280_Range()
		{
			MeasurementUnitCode = "8",
			RangeMinimumQuantity = "9",
			RangeMaximumQuantity = "n",
		};

		var actual = Map.MapComposite<C280_Range>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new C280_Range();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

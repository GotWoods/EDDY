using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C280Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:M:V";

		var expected = new C280_Range()
		{
			MeasurementUnitCode = "b",
			RangeMinimum = "M",
			RangeMaximum = "V",
		};

		var actual = Map.MapComposite<C280_Range>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new C280_Range();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

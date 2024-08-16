using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C280Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:k:7";

		var expected = new C280_Range()
		{
			MeasurementUnitCode = "V",
			RangeMinimumValue = "k",
			RangeMaximumValue = "7",
		};

		var actual = Map.MapComposite<C280_Range>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredMeasurementUnitCode(string measurementUnitCode, bool isValidExpected)
	{
		var subject = new C280_Range();
		//Required fields
		//Test Parameters
		subject.MeasurementUnitCode = measurementUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

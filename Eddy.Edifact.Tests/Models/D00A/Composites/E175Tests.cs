using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E175Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:s:S:N";

		var expected = new E175_MeasurementValueAndDetails()
		{
			MeasurementValue = "n",
			MeasurementUnitCode = "s",
			MeasuredAttributeCode = "S",
			MeasurementSignificanceCode = "N",
		};

		var actual = Map.MapComposite<E175_MeasurementValueAndDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMeasurementValue(string measurementValue, bool isValidExpected)
	{
		var subject = new E175_MeasurementValueAndDetails();
		//Required fields
		//Test Parameters
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

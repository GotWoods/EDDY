using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E175Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "V:k:I:d";

		var expected = new E175_MeasurementValueAndDetails()
		{
			Measure = "V",
			MeasurementUnitCode = "k",
			MeasuredAttributeCode = "I",
			MeasurementSignificanceCode = "d",
		};

		var actual = Map.MapComposite<E175_MeasurementValueAndDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredMeasure(string measure, bool isValidExpected)
	{
		var subject = new E175_MeasurementValueAndDetails();
		//Required fields
		//Test Parameters
		subject.Measure = measure;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

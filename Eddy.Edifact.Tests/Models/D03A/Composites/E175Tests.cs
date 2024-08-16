using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E175Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:H:B:c";

		var expected = new E175_MeasurementValueAndDetails()
		{
			Measure = "n",
			MeasurementUnitCode = "H",
			MeasuredAttributeCode = "B",
			MeasurementSignificanceCode = "c",
		};

		var actual = Map.MapComposite<E175_MeasurementValueAndDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMeasure(string measure, bool isValidExpected)
	{
		var subject = new E175_MeasurementValueAndDetails();
		//Required fields
		//Test Parameters
		subject.Measure = measure;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

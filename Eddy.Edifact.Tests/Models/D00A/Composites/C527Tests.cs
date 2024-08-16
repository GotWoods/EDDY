using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C527Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:v:g:x";

		var expected = new C527_StatisticalDetails()
		{
			MeasurementValue = "7",
			MeasurementUnitCode = "v",
			MeasuredAttributeCode = "g",
			MeasurementSignificanceCode = "x",
		};

		var actual = Map.MapComposite<C527_StatisticalDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

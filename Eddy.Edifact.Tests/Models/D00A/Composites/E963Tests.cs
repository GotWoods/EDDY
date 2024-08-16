using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E963Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:a:04JE";

		var expected = new E963_DistanceOrTimeDetails()
		{
			MeasurementValue = "s",
			MeasurementUnitCode = "a",
			TimeValue = "04JE",
		};

		var actual = Map.MapComposite<E963_DistanceOrTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

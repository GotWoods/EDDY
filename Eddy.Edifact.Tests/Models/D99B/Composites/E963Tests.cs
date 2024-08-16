using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E963Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:B:pviV";

		var expected = new E963_DistanceOrTimeDetails()
		{
			MeasurementValue = "X",
			MeasurementUnitCode = "B",
			Time = "pviV",
		};

		var actual = Map.MapComposite<E963_DistanceOrTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

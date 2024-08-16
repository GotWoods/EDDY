using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class E963Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:u:31Z2";

		var expected = new E963_DistanceOrTimeDetails()
		{
			Measure = "y",
			MeasurementUnitCode = "u",
			Time = "31Z2",
		};

		var actual = Map.MapComposite<E963_DistanceOrTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

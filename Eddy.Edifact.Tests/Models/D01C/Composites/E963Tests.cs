using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E963Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:f:ZFFp";

		var expected = new E963_DistanceOrTimeDetails()
		{
			Measure = "w",
			MeasurementUnitCode = "f",
			Time = "ZFFp",
		};

		var actual = Map.MapComposite<E963_DistanceOrTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C239Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:m";

		var expected = new C239_TemperatureSetting()
		{
			TemperatureDegree = "f",
			MeasurementUnitCode = "m",
		};

		var actual = Map.MapComposite<C239_TemperatureSetting>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

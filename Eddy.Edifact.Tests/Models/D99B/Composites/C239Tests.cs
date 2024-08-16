using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C239Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7Ap:h";

		var expected = new C239_TemperatureSetting()
		{
			TemperatureSetting = "7Ap",
			MeasurementUnitCode = "h",
		};

		var actual = Map.MapComposite<C239_TemperatureSetting>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

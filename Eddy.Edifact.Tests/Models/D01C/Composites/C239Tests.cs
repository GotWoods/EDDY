using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C239Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:n";

		var expected = new C239_TemperatureSetting()
		{
			TemperatureDegree = "O",
			MeasurementUnitCode = "n",
		};

		var actual = Map.MapComposite<C239_TemperatureSetting>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

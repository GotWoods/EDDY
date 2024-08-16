using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C239Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "RTt:4";

		var expected = new C239_TemperatureSetting()
		{
			TemperatureSetting = "RTt",
			MeasureUnitQualifier = "4",
		};

		var actual = Map.MapComposite<C239_TemperatureSetting>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

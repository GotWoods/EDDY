using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D16A;
using Eddy.Edifact.Models.D16A.Composites;

namespace Eddy.Edifact.Tests.Models.D16A.Composites;

public class C174Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:R:7:J:L";

		var expected = new C174_ValueRange()
		{
			MeasurementUnitCode = "n",
			Measure = "R",
			RangeMinimumQuantity = "7",
			RangeMaximumQuantity = "J",
			SignificantDigitsQuantity = "L",
		};

		var actual = Map.MapComposite<C174_ValueRange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

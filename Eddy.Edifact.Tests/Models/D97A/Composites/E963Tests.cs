using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E963Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:C:kRM8";

		var expected = new E963_DistanceOrTimeDetails()
		{
			MeasurementValue = "M",
			MeasureUnitQualifier = "C",
			Time = "kRM8",
		};

		var actual = Map.MapComposite<E963_DistanceOrTimeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

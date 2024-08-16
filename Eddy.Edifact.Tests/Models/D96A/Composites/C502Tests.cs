using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C502Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:X:L:g";

		var expected = new C502_MeasurementDetails()
		{
			MeasurementDimensionCoded = "t",
			MeasurementSignificanceCoded = "X",
			MeasurementAttributeCoded = "L",
			MeasurementAttribute = "g",
		};

		var actual = Map.MapComposite<C502_MeasurementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

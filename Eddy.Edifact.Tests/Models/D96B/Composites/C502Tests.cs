using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C502Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:w:f:V";

		var expected = new C502_MeasurementDetails()
		{
			MeasurementDimensionCoded = "D",
			MeasurementSignificanceCoded = "w",
			MeasurementAttributeIdentification = "f",
			MeasurementAttribute = "V",
		};

		var actual = Map.MapComposite<C502_MeasurementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

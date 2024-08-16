using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class C502Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:o:H:p";

		var expected = new C502_MeasurementDetails()
		{
			PropertyMeasuredCoded = "P",
			MeasurementSignificanceCoded = "o",
			MeasurementAttributeIdentification = "H",
			MeasurementAttribute = "p",
		};

		var actual = Map.MapComposite<C502_MeasurementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

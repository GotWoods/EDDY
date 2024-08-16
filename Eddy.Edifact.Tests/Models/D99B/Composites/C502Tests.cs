using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C502Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:j:5:f";

		var expected = new C502_MeasurementDetails()
		{
			MeasuredAttributeCode = "4",
			MeasurementSignificanceCoded = "j",
			NonDiscreteMeasurementNameCode = "5",
			NonDiscreteMeasurementName = "f",
		};

		var actual = Map.MapComposite<C502_MeasurementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

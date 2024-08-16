using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C831Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:i:T:y:Y:T";

		var expected = new C831_ResultDetails()
		{
			MeasurementValue = "r",
			MeasurementSignificanceCoded = "i",
			NonDiscreteMeasurementNameCode = "T",
			CodeListIdentificationCode = "y",
			CodeListResponsibleAgencyCode = "Y",
			NonDiscreteMeasurementName = "T",
		};

		var actual = Map.MapComposite<C831_ResultDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

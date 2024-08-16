using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C831Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:j:0:9:M:f";

		var expected = new C831_ResultDetails()
		{
			Measure = "F",
			MeasurementSignificanceCode = "j",
			NonDiscreteMeasurementNameCode = "0",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "M",
			NonDiscreteMeasurementName = "f",
		};

		var actual = Map.MapComposite<C831_ResultDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

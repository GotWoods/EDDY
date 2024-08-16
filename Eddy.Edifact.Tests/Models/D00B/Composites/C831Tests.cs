using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C831Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:9:n:j:3:g";

		var expected = new C831_ResultDetails()
		{
			MeasurementValue = "D",
			MeasurementSignificanceCode = "9",
			NonDiscreteMeasurementNameCode = "n",
			CodeListIdentificationCode = "j",
			CodeListResponsibleAgencyCode = "3",
			NonDiscreteMeasurementName = "g",
		};

		var actual = Map.MapComposite<C831_ResultDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C831Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:C:Y:q:f:e";

		var expected = new C831_ResultDetails()
		{
			MeasurementValue = "9",
			MeasurementSignificanceCode = "C",
			NonDiscreteMeasurementNameCode = "Y",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "f",
			NonDiscreteMeasurementName = "e",
		};

		var actual = Map.MapComposite<C831_ResultDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

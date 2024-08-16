using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C502Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:D:m:i";

		var expected = new C502_MeasurementDetails()
		{
			MeasuredAttributeCode = "l",
			MeasurementSignificanceCode = "D",
			NonDiscreteMeasurementNameCode = "m",
			NonDiscreteMeasurementName = "i",
		};

		var actual = Map.MapComposite<C502_MeasurementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C848Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:L:x:y";

		var expected = new C848_MeasurementUnitDetails()
		{
			MeasurementUnitNameCode = "6",
			CodeListIdentificationCode = "L",
			CodeListResponsibleAgencyCode = "x",
			MeasurementUnitName = "y",
		};

		var actual = Map.MapComposite<C848_MeasurementUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

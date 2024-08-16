using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C848Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:v:S:3";

		var expected = new C848_MeasurementUnitDetails()
		{
			MeasurementUnitNameCode = "t",
			CodeListIdentificationCode = "v",
			CodeListResponsibleAgencyCode = "S",
			MeasurementUnitName = "3",
		};

		var actual = Map.MapComposite<C848_MeasurementUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

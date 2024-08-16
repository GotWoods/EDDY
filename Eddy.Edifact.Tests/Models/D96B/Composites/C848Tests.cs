using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C848Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:M:U:6";

		var expected = new C848_MeasurementUnitDetails()
		{
			MeasurementUnitIdentification = "e",
			CodeListQualifier = "M",
			CodeListResponsibleAgencyCoded = "U",
			MeasurementUnit = "6",
		};

		var actual = Map.MapComposite<C848_MeasurementUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

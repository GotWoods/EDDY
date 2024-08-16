using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C848Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Q:P:5:m";

		var expected = new C848_MeasurementUnitDetails()
		{
			MeasurementUnitIdentification = "Q",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "5",
			MeasurementUnit = "m",
		};

		var actual = Map.MapComposite<C848_MeasurementUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

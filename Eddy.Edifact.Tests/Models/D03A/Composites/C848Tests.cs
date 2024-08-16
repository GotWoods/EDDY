using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A.Composites;

public class C848Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "V:l:K:f";

		var expected = new C848_MeasurementUnitDetails()
		{
			MeasurementUnitCode = "V",
			CodeListIdentificationCode = "l",
			CodeListResponsibleAgencyCode = "K",
			MeasurementUnitName = "f",
		};

		var actual = Map.MapComposite<C848_MeasurementUnitDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

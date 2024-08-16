using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C852Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:6:3:g";

		var expected = new C852_RiskObjectSubType()
		{
			RiskObjectSubTypeIdentification = "R",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "3",
			RiskObjectSubType = "g",
		};

		var actual = Map.MapComposite<C852_RiskObjectSubType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

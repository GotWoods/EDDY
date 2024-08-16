using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C851Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:Q:f";

		var expected = new C851_RiskObjectType()
		{
			RiskObjectTypeIdentification = "2",
			CodeListIdentificationCode = "Q",
			CodeListResponsibleAgencyCode = "f",
		};

		var actual = Map.MapComposite<C851_RiskObjectType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

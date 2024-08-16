using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C851Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "T:n:c";

		var expected = new C851_RiskObjectType()
		{
			RiskObjectTypeIdentifier = "T",
			CodeListIdentificationCode = "n",
			CodeListResponsibleAgencyCode = "c",
		};

		var actual = Map.MapComposite<C851_RiskObjectType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

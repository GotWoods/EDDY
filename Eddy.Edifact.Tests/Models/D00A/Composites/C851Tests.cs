using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C851Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:9:a";

		var expected = new C851_RiskObjectType()
		{
			RiskObjectTypeIdentifier = "n",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "a",
		};

		var actual = Map.MapComposite<C851_RiskObjectType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

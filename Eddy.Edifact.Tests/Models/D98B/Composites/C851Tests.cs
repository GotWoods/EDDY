using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C851Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "T:O:g";

		var expected = new C851_RiskObjectType()
		{
			RiskObjectTypeIdentification = "T",
			CodeListQualifier = "O",
			CodeListResponsibleAgencyCoded = "g",
		};

		var actual = Map.MapComposite<C851_RiskObjectType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

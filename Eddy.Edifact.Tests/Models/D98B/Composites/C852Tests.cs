using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C852Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "g:a:s:2";

		var expected = new C852_RiskObjectSubType()
		{
			RiskObjectSubTypeIdentification = "g",
			CodeListQualifier = "a",
			CodeListResponsibleAgencyCoded = "s",
			RiskObjectSubType = "2",
		};

		var actual = Map.MapComposite<C852_RiskObjectSubType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C088Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:f:L:Q:4:r:Q:h";

		var expected = new C088_InstitutionIdentification()
		{
			InstitutionNameIdentification = "l",
			CodeListQualifier = "f",
			CodeListResponsibleAgencyCoded = "L",
			InstitutionBranchNumber = "Q",
			CodeListQualifier2 = "4",
			CodeListResponsibleAgencyCoded2 = "r",
			InstitutionName = "Q",
			InstitutionBranchPlace = "h",
		};

		var actual = Map.MapComposite<C088_InstitutionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

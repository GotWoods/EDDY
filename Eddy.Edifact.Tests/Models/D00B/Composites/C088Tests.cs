using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C088Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:k:y:h:c:G:G:H";

		var expected = new C088_InstitutionIdentification()
		{
			InstitutionNameCode = "g",
			CodeListIdentificationCode = "k",
			CodeListResponsibleAgencyCode = "y",
			InstitutionBranchIdentifier = "h",
			CodeListIdentificationCode2 = "c",
			CodeListResponsibleAgencyCode2 = "G",
			InstitutionName = "G",
			InstitutionBranchLocationName = "H",
		};

		var actual = Map.MapComposite<C088_InstitutionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

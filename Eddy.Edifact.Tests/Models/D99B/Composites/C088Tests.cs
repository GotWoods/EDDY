using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C088Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "N:F:v:O:k:f:i:D";

		var expected = new C088_InstitutionIdentification()
		{
			InstitutionNameIdentification = "N",
			CodeListIdentificationCode = "F",
			CodeListResponsibleAgencyCode = "v",
			InstitutionBranchNumber = "O",
			CodeListIdentificationCode2 = "k",
			CodeListResponsibleAgencyCode2 = "f",
			InstitutionName = "i",
			InstitutionBranchPlace = "D",
		};

		var actual = Map.MapComposite<C088_InstitutionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C088Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "J:F:B:Y:F:V:P:t";

		var expected = new C088_InstitutionIdentification()
		{
			InstitutionNameCode = "J",
			CodeListIdentificationCode = "F",
			CodeListResponsibleAgencyCode = "B",
			InstitutionBranchIdentifier = "Y",
			CodeListIdentificationCode2 = "F",
			CodeListResponsibleAgencyCode2 = "V",
			InstitutionName = "P",
			InstitutionBranchLocationName = "t",
		};

		var actual = Map.MapComposite<C088_InstitutionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D09B;
using Eddy.Edifact.Models.D09B.Composites;

namespace Eddy.Edifact.Tests.Models.D09B.Composites;

public class C289Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:o:O";

		var expected = new C289_TunnelRestriction()
		{
			TunnelRestrictionCode = "t",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "O",
		};

		var actual = Map.MapComposite<C289_TunnelRestriction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

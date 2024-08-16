using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C215Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "q:8:S:O";

		var expected = new C215_SealIssuer()
		{
			SealingPartyNameCode = "q",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "S",
			SealingPartyName = "O",
		};

		var actual = Map.MapComposite<C215_SealIssuer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

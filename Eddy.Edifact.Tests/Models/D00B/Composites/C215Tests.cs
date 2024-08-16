using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C215Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:z:Z:A";

		var expected = new C215_SealIssuer()
		{
			SealingPartyNameCode = "X",
			CodeListIdentificationCode = "z",
			CodeListResponsibleAgencyCode = "Z",
			SealingPartyName = "A",
		};

		var actual = Map.MapComposite<C215_SealIssuer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C215Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:o:v:x";

		var expected = new C215_SealIssuer()
		{
			SealingPartyCoded = "I",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "v",
			SealingParty = "x",
		};

		var actual = Map.MapComposite<C215_SealIssuer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

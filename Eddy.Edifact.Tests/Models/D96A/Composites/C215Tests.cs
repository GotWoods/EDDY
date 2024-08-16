using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C215Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "R:q:E:b";

		var expected = new C215_SealIssuer()
		{
			SealingPartyCoded = "R",
			CodeListQualifier = "q",
			CodeListResponsibleAgencyCoded = "E",
			SealingParty = "b",
		};

		var actual = Map.MapComposite<C215_SealIssuer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

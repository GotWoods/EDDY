using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C970Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:S:D:2";

		var expected = new C970_ClauseName()
		{
			ClauseNameCode = "k",
			CodeListIdentificationCode = "S",
			CodeListResponsibleAgencyCode = "D",
			ClauseName = "2",
		};

		var actual = Map.MapComposite<C970_ClauseName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

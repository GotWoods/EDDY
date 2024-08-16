using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C970Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:c:F:W";

		var expected = new C970_ClauseName()
		{
			ClauseNameCode = "A",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "F",
			ClauseName = "W",
		};

		var actual = Map.MapComposite<C970_ClauseName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C002Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:z:O:R";

		var expected = new C002_DocumentMessageName()
		{
			DocumentMessageNameCoded = "9",
			CodeListQualifier = "z",
			CodeListResponsibleAgencyCoded = "O",
			DocumentMessageName = "R",
		};

		var actual = Map.MapComposite<C002_DocumentMessageName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

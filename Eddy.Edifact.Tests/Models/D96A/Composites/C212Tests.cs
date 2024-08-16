using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:K:Q:Q";

		var expected = new C212_ItemNumberIdentification()
		{
			ItemNumber = "7",
			ItemNumberTypeCoded = "K",
			CodeListQualifier = "Q",
			CodeListResponsibleAgencyCoded = "Q",
		};

		var actual = Map.MapComposite<C212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

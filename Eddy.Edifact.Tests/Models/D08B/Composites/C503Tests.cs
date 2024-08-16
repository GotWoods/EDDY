using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class C503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:A:D:R:b:Q";

		var expected = new C503_DocumentMessageDetails()
		{
			DocumentIdentifier = "i",
			DocumentStatusCode = "A",
			DocumentSourceDescription = "D",
			LanguageNameCode = "R",
			VersionIdentifier = "b",
			RevisionIdentifier = "Q",
		};

		var actual = Map.MapComposite<C503_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

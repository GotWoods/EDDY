using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "n:o:C:q:B:H";

		var expected = new C503_DocumentMessageDetails()
		{
			DocumentIdentifier = "n",
			DocumentStatusCode = "o",
			DocumentSourceDescription = "C",
			LanguageNameCode = "q",
			VersionIdentifier = "B",
			RevisionIdentifier = "H",
		};

		var actual = Map.MapComposite<C503_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

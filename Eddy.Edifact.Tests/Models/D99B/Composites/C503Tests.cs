using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:C:T:o:e:O";

		var expected = new C503_DocumentMessageDetails()
		{
			DocumentMessageNumber = "4",
			DocumentStatusCode = "C",
			DocumentMessageSource = "T",
			LanguageNameCode = "o",
			Version = "e",
			RevisionNumber = "O",
		};

		var actual = Map.MapComposite<C503_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

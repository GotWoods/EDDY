using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class C106Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:B:g";

		var expected = new C106_DocumentMessageIdentification()
		{
			DocumentIdentifier = "P",
			VersionIdentifier = "B",
			RevisionIdentifier = "g",
		};

		var actual = Map.MapComposite<C106_DocumentMessageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

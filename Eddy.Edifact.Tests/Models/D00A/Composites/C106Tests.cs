using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C106Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:H:k";

		var expected = new C106_DocumentMessageIdentification()
		{
			DocumentIdentifier = "F",
			VersionIdentifier = "H",
			RevisionIdentifier = "k",
		};

		var actual = Map.MapComposite<C106_DocumentMessageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

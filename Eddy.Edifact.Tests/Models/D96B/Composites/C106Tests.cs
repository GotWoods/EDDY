using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C106Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "z:Q:m";

		var expected = new C106_DocumentMessageIdentification()
		{
			DocumentMessageNumber = "z",
			Version = "Q",
			RevisionNumber = "m",
		};

		var actual = Map.MapComposite<C106_DocumentMessageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

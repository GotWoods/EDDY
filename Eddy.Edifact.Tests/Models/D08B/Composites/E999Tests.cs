using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:d:bp2X:3b7z:W:j:C:G";

		var expected = new E999_ConnectionDetails()
		{
			LocationIdentifier = "R",
			PartyName = "d",
			Time = "bp2X",
			Time2 = "3b7z",
			LocationName = "W",
			LocationFunctionCodeQualifier = "j",
			CountryIdentifier = "C",
			SequencePositionIdentifier = "G",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

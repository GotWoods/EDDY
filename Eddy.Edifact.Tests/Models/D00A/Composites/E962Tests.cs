using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E962Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:I:q";

		var expected = new E962_TerminalInformation()
		{
			GateIdentifier = "e",
			FirstRelatedLocationNameCode = "I",
			FirstRelatedLocationNameCode2 = "q",
		};

		var actual = Map.MapComposite<E962_TerminalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

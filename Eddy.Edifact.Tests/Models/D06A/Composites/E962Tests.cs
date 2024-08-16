using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E962Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:x:l";

		var expected = new E962_TerminalInformation()
		{
			GateIdentifier = "M",
			FirstRelatedLocationIdentifier = "x",
			FirstRelatedLocationIdentifier2 = "l",
		};

		var actual = Map.MapComposite<E962_TerminalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

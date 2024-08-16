using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E032Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:P";

		var expected = new E032_PartyIdentification()
		{
			PartyIdentifier = "r",
			PartyFunctionCodeQualifier = "P",
		};

		var actual = Map.MapComposite<E032_PartyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E974Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:m:o:a";

		var expected = new E974_OriginatorIdentificationDetails()
		{
			AgentIdentifier = "w",
			InHouseIdentifier = "m",
			AgentIdentifier2 = "o",
			PartyName = "a",
		};

		var actual = Map.MapComposite<E974_OriginatorIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

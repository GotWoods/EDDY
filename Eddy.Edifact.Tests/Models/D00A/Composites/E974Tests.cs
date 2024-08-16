using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E974Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:s:J:W";

		var expected = new E974_OriginatorIdentificationDetails()
		{
			AgentIdentifier = "2",
			InHouseIdentifier = "s",
			AgentIdentifier2 = "J",
			PartyName = "W",
		};

		var actual = Map.MapComposite<E974_OriginatorIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

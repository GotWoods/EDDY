using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E974Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:T:X:f";

		var expected = new E974_OriginatorIdentificationDetails()
		{
			AgentIdentification = "5",
			InHouseIdentification = "T",
			AgentIdentification2 = "X",
			PartyName = "f",
		};

		var actual = Map.MapComposite<E974_OriginatorIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

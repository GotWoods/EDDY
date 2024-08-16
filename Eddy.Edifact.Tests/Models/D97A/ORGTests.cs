using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class ORGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ORG++++r+G++M";

		var expected = new ORG_OriginatorOfRequestDetails()
		{
			DeliveringSystemDetails = null,
			OriginatorIdentificationDetails = null,
			Location = null,
			PartyName = "r",
			OriginatorTypeCoded = "G",
			OriginatorDetails = null,
			OriginatorsAuthorityIdentification = "M",
		};

		var actual = Map.MapObject<ORG_OriginatorOfRequestDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

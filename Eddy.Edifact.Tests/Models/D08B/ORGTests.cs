using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B;

public class ORGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ORG++++5+K++i";

		var expected = new ORG_OriginatorOfRequestDetails()
		{
			DeliveringSystemDetails = null,
			OriginatorIdentificationDetails = null,
			Location = null,
			PartyName = "5",
			OriginatorTypeCode = "K",
			OriginatorDetails = null,
			AccessAuthorisationIdentifier = "i",
		};

		var actual = Map.MapObject<ORG_OriginatorOfRequestDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

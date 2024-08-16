using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ORGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ORG++++X+r++t";

		var expected = new ORG_OriginatorOfRequestDetails()
		{
			DeliveringSystemDetails = null,
			OriginatorIdentificationDetails = null,
			Location = null,
			PartyName = "X",
			OriginatorTypeCode = "r",
			OriginatorDetails = null,
			AccessAuthorisationIdentifier = "t",
		};

		var actual = Map.MapObject<ORG_OriginatorOfRequestDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

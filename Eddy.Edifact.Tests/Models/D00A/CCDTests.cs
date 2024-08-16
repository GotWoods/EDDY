using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCD+r+O+F";

		var expected = new CCD_CreditCoverDetails()
		{
			CreditCoverRequestTypeCode = "r",
			CreditCoverResponseTypeCode = "O",
			CreditCoverResponseReasonCode = "F",
		};

		var actual = Map.MapObject<CCD_CreditCoverDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

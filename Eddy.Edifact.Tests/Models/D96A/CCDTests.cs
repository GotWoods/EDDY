using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCD+m+8+5";

		var expected = new CCD_CreditCoverDetails()
		{
			CreditCoverRequestCoded = "m",
			CreditCoverResponseCoded = "8",
			CreditCoverReasonCoded = "5",
		};

		var actual = Map.MapObject<CCD_CreditCoverDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

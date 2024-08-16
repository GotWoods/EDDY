using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class CTATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CTA+s+";

		var expected = new CTA_ContactInformation()
		{
			ContactFunctionCode = "s",
			ContactDetails = null,
		};

		var actual = Map.MapObject<CTA_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

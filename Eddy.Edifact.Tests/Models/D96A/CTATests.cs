using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CTATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CTA+U+";

		var expected = new CTA_ContactInformation()
		{
			ContactFunctionCoded = "U",
			DepartmentOrEmployeeDetails = null,
		};

		var actual = Map.MapObject<CTA_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

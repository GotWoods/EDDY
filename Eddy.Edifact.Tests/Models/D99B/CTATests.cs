using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CTATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CTA+M+";

		var expected = new CTA_ContactInformation()
		{
			ContactFunctionCode = "M",
			DepartmentOrEmployeeDetails = null,
		};

		var actual = Map.MapObject<CTA_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

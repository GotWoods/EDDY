using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C532Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:9";

		var expected = new C532_ReturnablePackageDetails()
		{
			ReturnablePackageFreightPaymentResponsibilityCode = "X",
			ReturnablePackageLoadContentsCode = "9",
		};

		var actual = Map.MapComposite<C532_ReturnablePackageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

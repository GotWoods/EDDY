using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C532Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:O";

		var expected = new C532_ReturnablePackageDetails()
		{
			ReturnablePackageFreightPaymentResponsibilityCoded = "U",
			ReturnablePackageLoadContentsCoded = "O",
		};

		var actual = Map.MapComposite<C532_ReturnablePackageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

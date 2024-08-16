using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C532Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:l";

		var expected = new C532_ReturnablePackageDetails()
		{
			ReturnablePackageFreightPaymentResponsibilityCoded = "z",
			ReturnablePackageLoadContentsCoded = "l",
		};

		var actual = Map.MapComposite<C532_ReturnablePackageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

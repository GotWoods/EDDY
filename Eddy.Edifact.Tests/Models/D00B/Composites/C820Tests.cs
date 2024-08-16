using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C820Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:m:l";

		var expected = new C820_PremiumCalculationComponent()
		{
			PremiumCalculationComponentIdentifier = "v",
			CodeListIdentificationCode = "m",
			CodeListResponsibleAgencyCode = "l",
		};

		var actual = Map.MapComposite<C820_PremiumCalculationComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C820Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "B:P:x";

		var expected = new C820_PremiumCalculationComponent()
		{
			PremiumCalculationComponentIdentification = "B",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "x",
		};

		var actual = Map.MapComposite<C820_PremiumCalculationComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

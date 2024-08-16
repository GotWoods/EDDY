using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C820Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:2:I";

		var expected = new C820_PremiumCalculationComponent()
		{
			PremiumCalculationComponentIdentifier = "o",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "I",
		};

		var actual = Map.MapComposite<C820_PremiumCalculationComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

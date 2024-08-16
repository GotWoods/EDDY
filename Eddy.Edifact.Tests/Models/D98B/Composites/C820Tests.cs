using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C820Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:T:6";

		var expected = new C820_PremiumCalculationComponent()
		{
			PremiumCalculationComponentIdentification = "o",
			CodeListQualifier = "T",
			CodeListResponsibleAgencyCoded = "6",
		};

		var actual = Map.MapComposite<C820_PremiumCalculationComponent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCC++X";

		var expected = new PCC_PremiumCalculationComponentDetails()
		{
			PremiumCalculationComponent = null,
			PremiumCalculationComponentValueCategoryIdentifier = "X",
		};

		var actual = Map.MapObject<PCC_PremiumCalculationComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

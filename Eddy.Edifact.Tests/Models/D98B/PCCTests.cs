using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class PCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCC++1";

		var expected = new PCC_PremiumCalculationComponentDetails()
		{
			PremiumCalculationComponent = null,
			PremiumCalculationComponentValueCategory = "1",
		};

		var actual = Map.MapObject<PCC_PremiumCalculationComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

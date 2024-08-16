using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class TFFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TFF+++";

		var expected = new TFF_TariffInformation()
		{
			TariffInformation = null,
			RateInformation = null,
			AssociatedChargesInformation = null,
		};

		var actual = Map.MapObject<TFF_TariffInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

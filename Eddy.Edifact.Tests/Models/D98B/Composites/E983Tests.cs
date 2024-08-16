using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class E983Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:Q:a:S:p";

		var expected = new E983_RateInformation()
		{
			RateTariffClassIdentification = "D",
			RangeMinimum = "Q",
			RangeMaximum = "a",
			ProcessingIndicatorCoded = "S",
			CurrencyCoded = "p",
		};

		var actual = Map.MapComposite<E983_RateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

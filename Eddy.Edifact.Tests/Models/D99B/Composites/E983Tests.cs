using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E983Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:z:2:o:P";

		var expected = new E983_RateInformation()
		{
			RateTariffClassIdentification = "w",
			RangeMinimum = "z",
			RangeMaximum = "2",
			ProcessingIndicatorDescriptionCode = "o",
			CurrencyIdentificationCode = "P",
		};

		var actual = Map.MapComposite<E983_RateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

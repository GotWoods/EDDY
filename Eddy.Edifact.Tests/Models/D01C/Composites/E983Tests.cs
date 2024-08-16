using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E983Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:B:q:w:W";

		var expected = new E983_RateInformation()
		{
			RateOrTariffClassDescriptionCode = "6",
			RangeMinimumQuantity = "B",
			RangeMaximumQuantity = "q",
			ProcessingIndicatorDescriptionCode = "w",
			CurrencyIdentificationCode = "W",
		};

		var actual = Map.MapComposite<E983_RateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

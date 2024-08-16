using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E983Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:9:N:M:x";

		var expected = new E983_RateInformation()
		{
			RateOrTariffClassDescriptionCode = "Y",
			RangeMinimumValue = "9",
			RangeMaximumValue = "N",
			ProcessingIndicatorDescriptionCode = "M",
			CurrencyIdentificationCode = "x",
		};

		var actual = Map.MapComposite<E983_RateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

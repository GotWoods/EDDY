using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E017Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:U:x:P:X";

		var expected = new E017_MonetaryAmount()
		{
			MonetaryAmountTypeCodeQualifier = "r",
			MonetaryAmountValue = "U",
			CurrencyIdentificationCode = "x",
			CurrencyQualifier = "P",
			StatusDescriptionCode = "X",
		};

		var actual = Map.MapComposite<E017_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

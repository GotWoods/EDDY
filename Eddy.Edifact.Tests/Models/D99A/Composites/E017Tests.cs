using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E017Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:5:3:3:V";

		var expected = new E017_MonetaryAmount()
		{
			MonetaryAmountTypeQualifier = "S",
			MonetaryAmount = "5",
			CurrencyCoded = "3",
			CurrencyQualifier = "3",
			StatusCoded = "V",
		};

		var actual = Map.MapComposite<E017_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

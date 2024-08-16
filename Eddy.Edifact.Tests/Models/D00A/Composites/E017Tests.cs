using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E017Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:y:X:2:W";

		var expected = new E017_MonetaryAmount()
		{
			MonetaryAmountTypeCodeQualifier = "k",
			MonetaryAmount = "y",
			CurrencyIdentificationCode = "X",
			CurrencyTypeCodeQualifier = "2",
			StatusDescriptionCode = "W",
		};

		var actual = Map.MapComposite<E017_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

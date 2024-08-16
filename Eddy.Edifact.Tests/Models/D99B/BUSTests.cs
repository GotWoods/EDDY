using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class BUSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BUS++u+r++J";

		var expected = new BUS_BusinessFunction()
		{
			BusinessFunction = null,
			GeographicAreaCode = "u",
			TypeOfFinancialTransactionCoded = "r",
			BankOperation = null,
			IntraCompanyPaymentCoded = "J",
		};

		var actual = Map.MapObject<BUS_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

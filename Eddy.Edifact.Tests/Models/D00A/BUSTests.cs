using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class BUSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BUS++e+j++N";

		var expected = new BUS_BusinessFunction()
		{
			BusinessFunction = null,
			GeographicAreaCode = "e",
			FinancialTransactionTypeCode = "j",
			BankOperation = null,
			IntraCompanyPaymentIndicatorCode = "N",
		};

		var actual = Map.MapObject<BUS_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

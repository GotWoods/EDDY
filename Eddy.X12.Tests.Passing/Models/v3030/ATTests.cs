using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ATTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT*Ja*qKVUxCs*g*Xgv*y*pFuc*QWH*q4GBjHbg*3";

		var expected = new AT_FinancialAccounting()
		{
			FundCode = "Ja",
			TreasurySymbolNumber = "qKVUxCs",
			BudgetActivityNumber = "g",
			ObjectClassNumber = "Xgv",
			ReimbursableSourceNumber = "y",
			TransactionReferenceNumber = "pFuc",
			AccountableStationNumber = "QWH",
			PayingStationNumber = "q4GBjHbg",
			Description = "3",
		};

		var actual = Map.MapObject<AT_FinancialAccounting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

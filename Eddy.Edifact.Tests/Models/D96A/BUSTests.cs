using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class BUSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "BUS++S+X++d";

		var expected = new BUS_BusinessFunction()
		{
			BusinessFunction = null,
			GeographicEnvironmentCoded = "S",
			TypeOfFinancialTransactionCoded = "X",
			BankOperation = null,
			IntraCompanyPaymentCoded = "d",
		};

		var actual = Map.MapObject<BUS_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

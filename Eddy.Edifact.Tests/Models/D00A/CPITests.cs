using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPI+++n";

		var expected = new CPI_ChargePaymentInstructions()
		{
			ChargeCategory = null,
			MethodOfPayment = null,
			PaymentArrangementCode = "n",
		};

		var actual = Map.MapObject<CPI_ChargePaymentInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

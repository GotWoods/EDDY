using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPI+++k";

		var expected = new CPI_ChargePaymentInstructions()
		{
			ChargeCategory = null,
			MethodOfPayment = null,
			PrepaidCollectIndicatorCoded = "k",
		};

		var actual = Map.MapObject<CPI_ChargePaymentInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLD*Ul*8*x";

		var expected = new RLD_DownPaymentData()
		{
			TypeOfDownpaymentCode = "Ul",
			MonetaryAmount = 8,
			Description = "x",
		};

		var actual = Map.MapObject<RLD_DownPaymentData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

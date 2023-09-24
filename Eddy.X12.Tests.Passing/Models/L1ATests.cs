using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L1ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L1A*K*nG";

		var expected = new L1A_BillingIdentification()
		{
			Amount = "K",
			StandardCarrierAlphaCode = "nG",
		};

		var actual = Map.MapObject<L1A_BillingIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

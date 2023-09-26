using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*OU*k*X*r*S*X*d";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "OU",
			ReferenceNumber = "k",
			ReferenceNumber2 = "X",
			ReferenceNumber3 = "r",
			ReferenceNumber4 = "S",
			ReferenceNumber5 = "X",
			ReferenceNumber6 = "d",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

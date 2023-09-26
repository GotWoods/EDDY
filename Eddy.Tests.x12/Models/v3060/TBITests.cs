using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*3S*T*m*B*T*A*K";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "3S",
			ReferenceIdentification = "T",
			ReferenceIdentification2 = "m",
			ReferenceIdentification3 = "B",
			ReferenceIdentification4 = "T",
			ReferenceIdentification5 = "A",
			ReferenceIdentification6 = "K",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

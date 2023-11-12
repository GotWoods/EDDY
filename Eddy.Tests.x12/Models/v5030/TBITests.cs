using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*Rp*h*2*5*t*8*d*d";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "Rp",
			ReferenceIdentification = "h",
			ReferenceIdentification2 = "2",
			ReferenceIdentification3 = "5",
			ReferenceIdentification4 = "t",
			ReferenceIdentification5 = "8",
			ReferenceIdentification6 = "d",
			ReferenceIdentification7 = "d",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

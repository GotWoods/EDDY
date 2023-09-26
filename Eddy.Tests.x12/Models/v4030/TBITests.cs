using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*5C*y*n*W*E*V*2*O";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "5C",
			ReferenceIdentification = "y",
			ReferenceIdentification2 = "n",
			ReferenceIdentification3 = "W",
			ReferenceIdentification4 = "E",
			ReferenceIdentification5 = "V",
			ReferenceIdentification6 = "2",
			ReferenceIdentification7 = "O",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

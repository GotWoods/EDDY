using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*2H*Y*u*I*i*w*D*u";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "2H",
			ReferenceIdentification = "Y",
			ReferenceIdentification2 = "u",
			ReferenceIdentification3 = "I",
			ReferenceIdentification4 = "i",
			ReferenceIdentification5 = "w",
			ReferenceIdentification6 = "D",
			ReferenceIdentification7 = "u",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

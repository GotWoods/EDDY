using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*xS*x*v*M*d*n*u*p";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "xS",
			ReferenceIdentification = "x",
			ReferenceIdentification2 = "v",
			ReferenceIdentification3 = "M",
			ReferenceIdentification4 = "d",
			ReferenceIdentification5 = "n",
			ReferenceIdentification6 = "u",
			ReferenceIdentification7 = "p",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

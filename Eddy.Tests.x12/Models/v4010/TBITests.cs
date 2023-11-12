using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TBITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TBI*0M*G*T*8*j*X*T*8";

		var expected = new TBI_TradeLineBureauIdentifier()
		{
			IdentificationCode = "0M",
			ReferenceIdentification = "G",
			ReferenceIdentification2 = "T",
			ReferenceIdentification3 = "8",
			ReferenceIdentification4 = "j",
			ReferenceIdentification5 = "X",
			ReferenceIdentification6 = "T",
			ReferenceIdentification7 = "8",
		};

		var actual = Map.MapObject<TBI_TradeLineBureauIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

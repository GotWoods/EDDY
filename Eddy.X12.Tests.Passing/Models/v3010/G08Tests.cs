using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G08*6*1*3*QB";

		var expected = new G08_PalletInformation()
		{
			QuantityOfPalletsReceived = 6,
			QuantityOfPalletsReturned = 1,
			QuantityContested = 3,
			ReceivingConditionCode = "QB",
		};

		var actual = Map.MapObject<G08_PalletInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

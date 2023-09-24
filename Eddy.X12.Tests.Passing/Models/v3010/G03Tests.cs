using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G03*Z8*6*x*lS*X3*2*7";

		var expected = new G03_AdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "Z8",
			QuantityOfPalletsShipped = 6,
			PalletExchangeCode = "x",
			SealNumber = "lS",
			SealNumber2 = "X3",
			Temperature = 2,
			Temperature2 = 7,
		};

		var actual = Map.MapObject<G03_AdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

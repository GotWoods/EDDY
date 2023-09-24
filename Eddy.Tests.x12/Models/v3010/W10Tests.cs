using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W10*Ax*4*c*45*t5*4*B4*3*kt";

		var expected = new W10_WarehouseAdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "Ax",
			QuantityOfPalletsShipped = 4,
			PalletExchangeCode = "c",
			SealNumber = "45",
			SealNumber2 = "t5",
			Temperature = 4,
			UnitOfMeasurementCode = "B4",
			Temperature2 = 3,
			UnitOfMeasurementCode2 = "kt",
		};

		var actual = Map.MapObject<W10_WarehouseAdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

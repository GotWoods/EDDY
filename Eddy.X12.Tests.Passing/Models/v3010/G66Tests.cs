using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G66*V4*O*K*tL*z*Us*k";

		var expected = new G66_TransportationInstructions()
		{
			ShipmentMethodOfPayment = "V4",
			TransportationMethodTypeCode = "O",
			PalletExchangeCode = "K",
			UnitLoadOptionCode = "tL",
			Routing = "z",
			FOBPointCode = "Us",
			FOBPoint = "k",
		};

		var actual = Map.MapObject<G66_TransportationInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

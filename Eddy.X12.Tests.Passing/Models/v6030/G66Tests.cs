using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class G66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G66*tk*a*Q*5X*N*e5*n";

		var expected = new G66_TransportationInstructions()
		{
			ShipmentMethodOfPaymentCode = "tk",
			TransportationMethodTypeCode = "a",
			PalletExchangeCode = "Q",
			UnitLoadOptionCode = "5X",
			Routing = "N",
			FOBPointCode = "e5",
			FOBPoint = "n",
		};

		var actual = Map.MapObject<G66_TransportationInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

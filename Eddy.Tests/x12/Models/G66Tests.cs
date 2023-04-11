using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G66Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G66*v5*X*c*nr*2*YW*1";

		var expected = new G66_TransportationInstructions()
		{
			ShipmentMethodOfPaymentCode = "v5",
			TransportationMethodTypeCode = "X",
			PalletExchangeCode = "c",
			UnitLoadOptionCode = "nr",
			Routing = "2",
			FOBPointCode = "YW",
			FOBPoint = "1",
		};

		var actual = Map.MapObject<G66_TransportationInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

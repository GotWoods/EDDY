using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BNXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNX*P*a*k*79231";

		var expected = new BNX_RailShipmentInformation()
		{
			ShipmentWeightCode = "P",
			ReferencedPatternIdentifier = "a",
			BillingCode = "k",
			RepetitivePatternNumber = 79231,
		};

		var actual = Map.MapObject<BNX_RailShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

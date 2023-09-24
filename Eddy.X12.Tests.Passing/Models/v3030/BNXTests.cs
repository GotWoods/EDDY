using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BNXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BNX*z*9*o*46869";

		var expected = new BNX_RailShipmentInformation()
		{
			ShipmentWeightCode = "z",
			ReferencedPatternIdentifier = "9",
			BillingCode = "o",
			RepetitivePatternNumber = 46869,
		};

		var actual = Map.MapObject<BNX_RailShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

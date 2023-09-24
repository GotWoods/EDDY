using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G07*W*N*1*d*cE*6";

		var expected = new G07_CarrierInformation()
		{
			EquipmentInitial = "W",
			EquipmentNumber = "N",
			SealNumber = "1",
			SealNumber2 = "d",
			SealStatusCode = "cE",
			Temperature = 6,
		};

		var actual = Map.MapObject<G07_CarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

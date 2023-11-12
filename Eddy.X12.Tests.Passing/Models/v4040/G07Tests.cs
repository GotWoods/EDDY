using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class G07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G07*f*v*B7*8i*ms*1";

		var expected = new G07_CarrierInformation()
		{
			EquipmentInitial = "f",
			EquipmentNumber = "v",
			SealNumber = "B7",
			SealNumber2 = "8i",
			SealStatusCode = "ms",
			Temperature = 1,
		};

		var actual = Map.MapObject<G07_CarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

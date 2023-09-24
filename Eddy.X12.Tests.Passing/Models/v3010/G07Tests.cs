using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G07*C*N*ac*oW*de*9";

		var expected = new G07_CarrierInformation()
		{
			EquipmentInitial = "C",
			EquipmentNumber = "N",
			SealNumber = "ac",
			SealNumber2 = "oW",
			SealStatusCode = "de",
			Temperature = 9,
		};

		var actual = Map.MapObject<G07_CarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

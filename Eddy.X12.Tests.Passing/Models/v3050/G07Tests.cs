using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G07*g*V*Wx*88*5V*5";

		var expected = new G07_CarrierInformation()
		{
			EquipmentInitial = "g",
			EquipmentNumber = "V",
			SealNumber = "Wx",
			SealNumber2 = "88",
			SealStatusCode = "5V",
			Temperature = 5,
		};

		var actual = Map.MapObject<G07_CarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

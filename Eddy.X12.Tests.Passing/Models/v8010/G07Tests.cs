using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class G07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G07*1*q*d*t*km*8";

		var expected = new G07_CarrierInformation()
		{
			EquipmentInitial = "1",
			EquipmentNumber = "q",
			SealNumber = "d",
			SealNumber2 = "t",
			SealStatusCode = "km",
			Temperature = 8,
		};

		var actual = Map.MapObject<G07_CarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

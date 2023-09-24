using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LP*WoS7*Q*4*v*p*5*9";

		var expected = new LP_LoadPlanning()
		{
			EquipmentTypeCode = "WoS7",
			ShipmentIdentificationNumber = "Q",
			ShipmentIdentificationNumber2 = "4",
			VentInstructionCode = "v",
			EquipmentNumber = "p",
			Number = 5,
			Number2 = 9,
		};

		var actual = Map.MapObject<LP_LoadPlanning>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LP*de9t*z*S*j*U*7*5";

		var expected = new LP_LoadPlanning()
		{
			EquipmentTypeCode = "de9t",
			ShipmentIdentificationNumber = "z",
			ShipmentIdentificationNumber2 = "S",
			VentInstructionCode = "j",
			EquipmentNumber = "U",
			Number = 7,
			Number2 = 5,
		};

		var actual = Map.MapObject<LP_LoadPlanning>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

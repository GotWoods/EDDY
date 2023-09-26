using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class LPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LP*Do6K*Z*9*O*g*6*5";

		var expected = new LP_LoadPlanning()
		{
			EquipmentType = "Do6K",
			ShipmentIdentificationNumber = "Z",
			ShipmentIdentificationNumber2 = "9",
			VentInstructionCode = "O",
			EquipmentNumber = "g",
			Number = 6,
			Number2 = 5,
		};

		var actual = Map.MapObject<LP_LoadPlanning>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

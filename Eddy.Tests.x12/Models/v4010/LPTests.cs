using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LP*ykkB*m*X*b*J*4*4";

		var expected = new LP_LoadPlanning()
		{
			EquipmentType = "ykkB",
			ShipmentIdentificationNumber = "m",
			ShipmentIdentificationNumber2 = "X",
			VentInstructionCode = "b",
			EquipmentNumber = "J",
			Number = 4,
			Number2 = 4,
		};

		var actual = Map.MapObject<LP_LoadPlanning>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

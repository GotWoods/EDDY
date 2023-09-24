using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CR5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR5*o*4*3*3*e*4*5*1*j*5*7*T*h*s*S*5*w*J";

		var expected = new CR5_OxygenTherapyCertification()
		{
			CertificationTypeCode = "o",
			Quantity = 4,
			OxygenEquipmentTypeCode = "3",
			OxygenEquipmentTypeCode2 = "3",
			Description = "e",
			Quantity2 = 4,
			Quantity3 = 5,
			Quantity4 = 1,
			Description2 = "j",
			Quantity5 = 5,
			Quantity6 = 7,
			OxygenTestConditionCode = "T",
			OxygenTestFindingsCode = "h",
			OxygenTestFindingsCode2 = "s",
			OxygenTestFindingsCode3 = "S",
			Quantity7 = 5,
			OxygenDeliverySystemCode = "w",
			OxygenEquipmentTypeCode3 = "J",
		};

		var actual = Map.MapObject<CR5_OxygenTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
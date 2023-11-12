using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CR5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR5*t*1*4*9*o*3*6*8*I*4*8*g*l*E*p*6*y";

		var expected = new CR5_OxygenTherapyCertification()
		{
			CertificationTypeCode = "t",
			Quantity = 1,
			OxygenEquipmentTypeCode = "4",
			OxygenEquipmentTypeCode2 = "9",
			Description = "o",
			Quantity2 = 3,
			Quantity3 = 6,
			Quantity4 = 8,
			Description2 = "I",
			Quantity5 = 4,
			Quantity6 = 8,
			OxygenTestConditionCode = "g",
			OxygenTestFindingsCode = "l",
			OxygenTestFindingsCode2 = "E",
			OxygenTestFindingsCode3 = "p",
			Quantity7 = 6,
			OxygenDeliverySystemCode = "y",
		};

		var actual = Map.MapObject<CR5_OxygenTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

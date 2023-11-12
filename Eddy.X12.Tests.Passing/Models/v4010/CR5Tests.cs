using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CR5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR5*f*9*Z*B*n*4*5*2*x*2*6*U*0*m*J*9*8*Z";

		var expected = new CR5_OxygenTherapyCertification()
		{
			CertificationTypeCode = "f",
			Quantity = 9,
			OxygenEquipmentTypeCode = "Z",
			OxygenEquipmentTypeCode2 = "B",
			Description = "n",
			Quantity2 = 4,
			Quantity3 = 5,
			Quantity4 = 2,
			Description2 = "x",
			Quantity5 = 2,
			Quantity6 = 6,
			OxygenTestConditionCode = "U",
			OxygenTestFindingsCode = "0",
			OxygenTestFindingsCode2 = "m",
			OxygenTestFindingsCode3 = "J",
			Quantity7 = 9,
			OxygenDeliverySystemCode = "8",
			OxygenEquipmentTypeCode3 = "Z",
		};

		var actual = Map.MapObject<CR5_OxygenTherapyCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}

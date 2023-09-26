using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCO*9*8*T*B*r3*rF*7175*3*7*22*31*l*3*j*6*4*B*0";

		var expected = new SCO_ShippersCarOrdered()
		{
			Quantity = 9,
			CommodityCodeQualifier = "8",
			CommodityCode = "T",
			CarTypeCode = "B",
			EquipmentDescriptionCode = "r3",
			UnitOrBasisForMeasurementCode = "rF",
			EquipmentLength = 7175,
			Height = 3,
			Width = 7,
			WeightCapacity = 22,
			CubicCapacity = 31,
			ProtectiveServiceCode = "l",
			Temperature = 3,
			FloorTypeCode = "j",
			Height2 = 6,
			Width2 = 4,
			DoorTypeCode = "B",
			RatingSummaryValueCode = "0",
		};

		var actual = Map.MapObject<SCO_ShippersCarOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.CommodityCodeQualifier = "8";
		subject.CommodityCode = "T";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 9;
		subject.CommodityCode = "T";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 9;
		subject.CommodityCodeQualifier = "8";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

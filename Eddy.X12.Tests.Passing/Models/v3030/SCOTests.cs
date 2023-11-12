using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCO*7*w*N*ZD5v*x1*P7*1892*4*1*89*79*H*2*d*8*7*N*d";

		var expected = new SCO_ShippersCarOrdered()
		{
			Quantity = 7,
			CommodityCodeQualifier = "w",
			CommodityCode = "N",
			CarTypeCode = "ZD5v",
			EquipmentDescriptionCode = "x1",
			UnitOrBasisForMeasurementCode = "P7",
			EquipmentLength = 1892,
			Height = 4,
			Width = 1,
			WeightCapacity = 89,
			CubicCapacity = 79,
			ProtectiveServiceCode = "H",
			Temperature = 2,
			FloorTypeCode = "d",
			Height2 = 8,
			Width2 = 7,
			DoorTypeCode = "N",
			RatingSummaryValueCode = "d",
		};

		var actual = Map.MapObject<SCO_ShippersCarOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.CommodityCodeQualifier = "w";
		subject.CommodityCode = "N";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 7;
		subject.CommodityCode = "N";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 7;
		subject.CommodityCodeQualifier = "w";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCO*7*1*q*D*D1*ZE*3916*2*7*65*24*r*4*1*3*1*S*6";

		var expected = new SCO_ShippersCarOrdered()
		{
			Quantity = 7,
			CommodityCodeQualifier = "1",
			CommodityCode = "q",
			CarTypeCode = "D",
			EquipmentDescriptionCode = "D1",
			UnitOrBasisForMeasurementCode = "ZE",
			EquipmentLength = 3916,
			Height = 2,
			Width = 7,
			WeightCapacity = 65,
			CubicCapacity = 24,
			ProtectiveServiceCode = "r",
			Temperature = 4,
			FloorTypeCode = "1",
			Height2 = 3,
			Width2 = 1,
			DoorTypeCode = "S",
			RatingSummaryValueCode = "6",
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
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "q";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 7;
		subject.CommodityCode = "q";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 7;
		subject.CommodityCodeQualifier = "1";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

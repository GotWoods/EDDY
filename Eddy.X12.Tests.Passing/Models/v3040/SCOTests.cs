using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCO*2*7*k*CNlZ*iz*VK*5936*7*7*65*97*Z*3*h*2*8*d*5";

		var expected = new SCO_ShippersCarOrdered()
		{
			Quantity = 2,
			CommodityCodeQualifier = "7",
			CommodityCode = "k",
			CarTypeCode = "CNlZ",
			EquipmentDescriptionCode = "iz",
			UnitOrBasisForMeasurementCode = "VK",
			EquipmentLength = 5936,
			Height = 7,
			Width = 7,
			WeightCapacity = 65,
			CubicCapacity = 97,
			ProtectiveServiceCode = "Z",
			Temperature = 3,
			FloorTypeCode = "h",
			Height2 = 2,
			Width2 = 8,
			DoorTypeCode = "d",
			RatingSummaryValueCode = "5",
		};

		var actual = Map.MapObject<SCO_ShippersCarOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.CommodityCodeQualifier = "7";
		subject.CommodityCode = "k";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 2;
		subject.CommodityCode = "k";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 2;
		subject.CommodityCodeQualifier = "7";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

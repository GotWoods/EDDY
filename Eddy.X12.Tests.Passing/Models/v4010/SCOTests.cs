using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SCOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCO*9*9*j*t*ag*aj*2858*1*5*43*72*H*8*Y*2*6*y*X";

		var expected = new SCO_ShippersCarOrdered()
		{
			Quantity = 9,
			CommodityCodeQualifier = "9",
			CommodityCode = "j",
			CarTypeCode = "t",
			EquipmentDescriptionCode = "ag",
			UnitOrBasisForMeasurementCode = "aj",
			EquipmentLength = 2858,
			Height = 1,
			Width = 5,
			WeightCapacity = 43,
			CubicCapacity = 72,
			ProtectiveServiceCode = "H",
			Temperature = 8,
			FloorTypeCode = "Y",
			Height2 = 2,
			Width2 = 6,
			DoorTypeCode = "y",
			CarTypeCode2 = "X",
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
		subject.CommodityCodeQualifier = "9";
		subject.CommodityCode = "j";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 9;
		subject.CommodityCode = "j";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 9;
		subject.CommodityCodeQualifier = "9";
		//Test Parameters
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "t", true)]
	[InlineData("X", "", false)]
	[InlineData("", "t", true)]
	public void Validation_ARequiresBCarTypeCode2(string carTypeCode2, string carTypeCode, bool isValidExpected)
	{
		var subject = new SCO_ShippersCarOrdered();
		//Required fields
		subject.Quantity = 9;
		subject.CommodityCodeQualifier = "9";
		subject.CommodityCode = "j";
		//Test Parameters
		subject.CarTypeCode2 = carTypeCode2;
		subject.CarTypeCode = carTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

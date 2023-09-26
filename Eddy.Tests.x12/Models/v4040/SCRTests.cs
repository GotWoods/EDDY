using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class SCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCR*2*t*g*9812*8*9*58*89*zvs*3*0*8*1*X*1*2*l5*I*QTjSyAj*r*rg*u*E*o";

		var expected = new SCR_ShippersCarOrderedRail()
		{
			Quantity = 2,
			CommodityCode = "t",
			CarTypeCode = "g",
			EquipmentLength = 9812,
			Height = 8,
			Width = 9,
			WeightCapacity = 58,
			CubicCapacity = 89,
			ProtectiveServiceRuleCode = "zvs",
			Temperature = 3,
			FloorTypeCode = "0",
			Height2 = 8,
			Width2 = 1,
			DoorTypeCode = "X",
			RatingSummaryValueCode = "1",
			YesNoConditionOrResponseCode = "2",
			StandardCarrierAlphaCode = "l5",
			CarTypeCode2 = "I",
			AssociationOfAmericanRailroadsAARPoolCode = "QTjSyAj",
			YesNoConditionOrResponseCode2 = "r",
			StandardCarrierAlphaCode2 = "rg",
			EquipmentInitial = "u",
			EquipmentNumber = "E",
			EquipmentNumber2 = "o",
		};

		var actual = Map.MapObject<SCR_ShippersCarOrderedRail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.CommodityCode = "t";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.CarTypeCode = "g";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.Quantity = 2;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//At Least one
		subject.CarTypeCode = "g";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("g", "QTjSyAj", true)]
	[InlineData("g", "", true)]
	[InlineData("", "QTjSyAj", true)]
	public void Validation_AtLeastOneCarTypeCode(string carTypeCode, string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.Quantity = 2;
		subject.CommodityCode = "t";
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "g", true)]
	[InlineData("I", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBCarTypeCode2(string carTypeCode2, string carTypeCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.Quantity = 2;
		subject.CommodityCode = "t";
		//Test Parameters
		subject.CarTypeCode2 = carTypeCode2;
		subject.CarTypeCode = carTypeCode;
		//At Least one
		subject.AssociationOfAmericanRailroadsAARPoolCode = "QTjSyAj";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

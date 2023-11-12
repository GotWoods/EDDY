using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCR*3*M*9*5654*3*8*24*24*eJ9*9*D*2*8*6*z*P*yQ*5*Df38yDM*X*Ty*R*r*2";

		var expected = new SCR_ShippersCarOrderedRail()
		{
			Quantity = 3,
			CommodityCode = "M",
			CarTypeCode = "9",
			EquipmentLength = 5654,
			Height = 3,
			Width = 8,
			WeightCapacity = 24,
			CubicCapacity = 24,
			ProtectiveServiceRuleCode = "eJ9",
			Temperature = 9,
			FloorTypeCode = "D",
			Height2 = 2,
			Width2 = 8,
			DoorTypeCode = "6",
			RatingSummaryValueCode = "z",
			YesNoConditionOrResponseCode = "P",
			StandardCarrierAlphaCode = "yQ",
			CarTypeCode2 = "5",
			AssociationOfAmericanRailroadsAARPoolCode = "Df38yDM",
			YesNoConditionOrResponseCode2 = "X",
			StandardCarrierAlphaCode2 = "Ty",
			EquipmentInitial = "R",
			EquipmentNumber = "r",
			EquipmentNumber2 = "2",
		};

		var actual = Map.MapObject<SCR_ShippersCarOrderedRail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.CommodityCode = "M";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.CarTypeCode = "9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.Quantity = 3;
		//Test Parameters
		subject.CommodityCode = commodityCode;
		//At Least one
		subject.CarTypeCode = "9";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9", "Df38yDM", true)]
	[InlineData("9", "", true)]
	[InlineData("", "Df38yDM", true)]
	public void Validation_AtLeastOneCarTypeCode(string carTypeCode, string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.Quantity = 3;
		subject.CommodityCode = "M";
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "9", true)]
	[InlineData("5", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBCarTypeCode2(string carTypeCode2, string carTypeCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		subject.Quantity = 3;
		subject.CommodityCode = "M";
		//Test Parameters
		subject.CarTypeCode2 = carTypeCode2;
		subject.CarTypeCode = carTypeCode;
		//At Least one
		subject.AssociationOfAmericanRailroadsAARPoolCode = "Df38yDM";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

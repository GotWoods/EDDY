using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCR*5*R*w*9396*8*1*57*94*mzO*2*Y*3*6*O*h*7*Sd*6*sEkcjn2*Z*so*P*U*2*E";

		var expected = new SCR_ShippersCarOrderedRail()
		{
			Quantity = 5,
			CommodityCode = "R",
			CarTypeCode = "w",
			EquipmentLength = 9396,
			Height = 8,
			Width = 1,
			WeightCapacity = 57,
			CubicCapacity = 94,
			ProtectiveServiceRuleCode = "mzO",
			Temperature = 2,
			FloorTypeCode = "Y",
			Height2 = 3,
			Width2 = 6,
			DoorTypeCode = "O",
			RatingSummaryValueCode = "h",
			YesNoConditionOrResponseCode = "7",
			StandardCarrierAlphaCode = "Sd",
			CarTypeCode2 = "6",
			AssociationOfAmericanRailroadsAARPoolCode = "sEkcjn2",
			YesNoConditionOrResponseCode2 = "Z",
			StandardCarrierAlphaCode2 = "so",
			EquipmentInitial = "P",
			EquipmentNumber = "U",
			EquipmentNumber2 = "2",
			MetricQualifier = "E",
		};

		var actual = Map.MapObject<SCR_ShippersCarOrderedRail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("w","sEkcjn2", true)]
	[InlineData("", "sEkcjn2", true)]
	[InlineData("w", "", true)]
	public void Validation_AtLeastOneCarTypeCode(string carTypeCode, string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		subject.CarTypeCode = carTypeCode;
		subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "w", true)]
	[InlineData("6", "", false)]
	public void Validation_ARequiresBCarTypeCode2(string carTypeCode2, string carTypeCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		subject.CarTypeCode2 = carTypeCode2;
		subject.CarTypeCode = carTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("E", 57, true)]
	[InlineData("",57, true)]
	[InlineData("E", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MetricQualifier(string metricQualifier, int weightCapacity, int cubicCapacity, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		subject.MetricQualifier = metricQualifier;
		if (weightCapacity > 0)
		subject.WeightCapacity = weightCapacity;
		if (cubicCapacity > 0)
		subject.CubicCapacity = cubicCapacity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

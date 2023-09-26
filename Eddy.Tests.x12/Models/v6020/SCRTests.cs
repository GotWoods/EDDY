using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class SCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCR*1*8*k*9813*2*7*42*77*VHo*6*N*4*2*Z*u*n*GK*t*qgcgpZq*u*rM*k*T*5*h";

		var expected = new SCR_ShippersCarOrderedRail()
		{
			Quantity = 1,
			CommodityCode = "8",
			CarTypeCode = "k",
			EquipmentLength = 9813,
			Height = 2,
			Width = 7,
			WeightCapacity = 42,
			CubicCapacity = 77,
			ProtectiveServiceRuleCode = "VHo",
			Temperature = 6,
			FloorTypeCode = "N",
			Height2 = 4,
			Width2 = 2,
			DoorTypeCode = "Z",
			RatingSummaryValueCode = "u",
			YesNoConditionOrResponseCode = "n",
			StandardCarrierAlphaCode = "GK",
			CarTypeCode2 = "t",
			AssociationOfAmericanRailroadsAARPoolCode = "qgcgpZq",
			YesNoConditionOrResponseCode2 = "u",
			StandardCarrierAlphaCode2 = "rM",
			EquipmentInitial = "k",
			EquipmentNumber = "T",
			EquipmentNumber2 = "5",
			MetricQualifier = "h",
		};

		var actual = Map.MapObject<SCR_ShippersCarOrderedRail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("k", "qgcgpZq", true)]
	[InlineData("k", "", true)]
	[InlineData("", "qgcgpZq", true)]
	public void Validation_AtLeastOneCarTypeCode(string carTypeCode, string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MetricQualifier) || !string.IsNullOrEmpty(subject.MetricQualifier) || subject.WeightCapacity > 0 || subject.CubicCapacity > 0)
		{
			subject.MetricQualifier = "h";
			subject.WeightCapacity = 42;
			subject.CubicCapacity = 77;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "k", true)]
	[InlineData("t", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBCarTypeCode2(string carTypeCode2, string carTypeCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		//Test Parameters
		subject.CarTypeCode2 = carTypeCode2;
		subject.CarTypeCode = carTypeCode;
		//At Least one
		subject.AssociationOfAmericanRailroadsAARPoolCode = "qgcgpZq";
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.MetricQualifier) || !string.IsNullOrEmpty(subject.MetricQualifier) || subject.WeightCapacity > 0 || subject.CubicCapacity > 0)
		{
			subject.MetricQualifier = "h";
			subject.WeightCapacity = 42;
			subject.CubicCapacity = 77;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("h", 42, 77, true)]
	[InlineData("h", 0, 0, false)]
	[InlineData("", 42, 77, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MetricQualifier(string metricQualifier, int weightCapacity, int cubicCapacity, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		//Test Parameters
		subject.MetricQualifier = metricQualifier;
		if (weightCapacity > 0) 
			subject.WeightCapacity = weightCapacity;
		if (cubicCapacity > 0) 
			subject.CubicCapacity = cubicCapacity;
		//At Least one
		subject.CarTypeCode = "k";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

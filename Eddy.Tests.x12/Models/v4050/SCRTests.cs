using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCR*8*Z*h*3557*2*9*46*19*IWn*3*Q*5*7*6*q*8*NW*a*gzU246E*O*hp*k*Q*y";

		var expected = new SCR_ShippersCarOrderedRail()
		{
			Quantity = 8,
			CommodityCode = "Z",
			CarTypeCode = "h",
			EquipmentLength = 3557,
			Height = 2,
			Width = 9,
			WeightCapacity = 46,
			CubicCapacity = 19,
			ProtectiveServiceRuleCode = "IWn",
			Temperature = 3,
			FloorTypeCode = "Q",
			Height2 = 5,
			Width2 = 7,
			DoorTypeCode = "6",
			RatingSummaryValueCode = "q",
			YesNoConditionOrResponseCode = "8",
			StandardCarrierAlphaCode = "NW",
			CarTypeCode2 = "a",
			AssociationOfAmericanRailroadsAARPoolCode = "gzU246E",
			YesNoConditionOrResponseCode2 = "O",
			StandardCarrierAlphaCode2 = "hp",
			EquipmentInitial = "k",
			EquipmentNumber = "Q",
			EquipmentNumber2 = "y",
		};

		var actual = Map.MapObject<SCR_ShippersCarOrderedRail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("h", "gzU246E", true)]
	[InlineData("h", "", true)]
	[InlineData("", "gzU246E", true)]
	public void Validation_AtLeastOneCarTypeCode(string carTypeCode, string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "h", true)]
	[InlineData("a", "", false)]
	[InlineData("", "h", true)]
	public void Validation_ARequiresBCarTypeCode2(string carTypeCode2, string carTypeCode, bool isValidExpected)
	{
		var subject = new SCR_ShippersCarOrderedRail();
		//Required fields
		//Test Parameters
		subject.CarTypeCode2 = carTypeCode2;
		subject.CarTypeCode = carTypeCode;
		//At Least one
		subject.AssociationOfAmericanRailroadsAARPoolCode = "gzU246E";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

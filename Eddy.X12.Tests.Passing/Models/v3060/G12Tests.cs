using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G12*1*4*ce*5*fY*CW*R6";

		var expected = new G12_CouponPhysicalCharacteristics()
		{
			Length = 1,
			Width = 4,
			UnitOrBasisForMeasurementCode = "ce",
			Quantity = 5,
			PromotionConditionCode = "fY",
			PositionCode = "CW",
			PositionCode2 = "R6",
		};

		var actual = Map.MapObject<G12_CouponPhysicalCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R6", "CW", true)]
	[InlineData("R6", "", false)]
	[InlineData("", "CW", true)]
	public void Validation_ARequiresBPositionCode2(string positionCode2, string positionCode, bool isValidExpected)
	{
		var subject = new G12_CouponPhysicalCharacteristics();
		subject.PositionCode2 = positionCode2;
		subject.PositionCode = positionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

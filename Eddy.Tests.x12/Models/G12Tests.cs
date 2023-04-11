using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G12*8*3*Bs*2*U6*aO*JW";

		var expected = new G12_CouponPhysicalCharacteristics()
		{
			Length = 8,
			Width = 3,
			UnitOrBasisForMeasurementCode = "Bs",
			Quantity = 2,
			PromotionConditionCode = "U6",
			PositionCode = "aO",
			PositionCode2 = "JW",
		};

		var actual = Map.MapObject<G12_CouponPhysicalCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "aO", true)]
	[InlineData("JW", "", false)]
	public void Validation_ARequiresBPositionCode2(string positionCode2, string positionCode, bool isValidExpected)
	{
		var subject = new G12_CouponPhysicalCharacteristics();
		subject.PositionCode2 = positionCode2;
		subject.PositionCode = positionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

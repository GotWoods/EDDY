using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IC*U*9*859*C*t6*2222*ie*r2*7";

		var expected = new IC_IntermodalChassisEquipment()
		{
			EquipmentInitial = "U",
			EquipmentNumber = "9",
			TareWeight = 859,
			TareQualifierCode = "C",
			StandardCarrierAlphaCode = "t6",
			EquipmentLength = 2222,
			StandardCarrierAlphaCode2 = "ie",
			ChassisTypeCode = "r2",
			EquipmentNumberCheckDigit = 7,
		};

		var actual = Map.MapObject<IC_IntermodalChassisEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentNumber = "9";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "U";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(859, "C", true)]
	[InlineData(0, "C", false)]
	[InlineData(859, "", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "U";
		subject.EquipmentNumber = "9";
		if (tareWeight > 0)
		subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

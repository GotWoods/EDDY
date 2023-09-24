using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class ICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IC*r*h*593*b*w6*7147*9N*xa*8";

		var expected = new IC_IntermodalChassisEquipment()
		{
			EquipmentInitial = "r",
			EquipmentNumber = "h",
			TareWeight = 593,
			TareQualifierCode = "b",
			StandardCarrierAlphaCode = "w6",
			EquipmentLength = 7147,
			StandardCarrierAlphaCode2 = "9N",
			ChassisType = "xa",
			EquipmentNumberCheckDigit = 8,
		};

		var actual = Map.MapObject<IC_IntermodalChassisEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentNumber = "h";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 593;
			subject.TareQualifierCode = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 593;
			subject.TareQualifierCode = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(593, "b", true)]
	[InlineData(593, "", false)]
	[InlineData(0, "b", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "h";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

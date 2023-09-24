using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IC*L*e*538*U*4*7846*o*wi";

		var expected = new IC_IntermodalChassisEquipment()
		{
			EquipmentInitial = "L",
			EquipmentNumber = "e",
			TareWeight = 538,
			TareQualifierCode = "U",
			EquipmentOwnerCode = "4",
			EquipmentLength = 7846,
			EquipmentOwnerCode2 = "o",
			ChassisType = "wi",
		};

		var actual = Map.MapObject<IC_IntermodalChassisEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentNumber = "e";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 538;
			subject.TareQualifierCode = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 538;
			subject.TareQualifierCode = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(538, "U", true)]
	[InlineData(538, "", false)]
	[InlineData(0, "U", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "e";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

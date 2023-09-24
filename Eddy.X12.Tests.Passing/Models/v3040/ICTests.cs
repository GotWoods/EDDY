using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IC*W*Y*741*0*Vh*2843*dI*ab";

		var expected = new IC_IntermodalChassisEquipment()
		{
			EquipmentInitial = "W",
			EquipmentNumber = "Y",
			TareWeight = 741,
			TareQualifierCode = "0",
			StandardCarrierAlphaCode = "Vh",
			EquipmentLength = 2843,
			StandardCarrierAlphaCode2 = "dI",
			ChassisType = "ab",
		};

		var actual = Map.MapObject<IC_IntermodalChassisEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentNumber = "Y";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 741;
			subject.TareQualifierCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 741;
			subject.TareQualifierCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(741, "0", true)]
	[InlineData(741, "", false)]
	[InlineData(0, "0", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = "Y";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IC*d*5*342*4*JH*1721*4T*Jq*2";

		var expected = new IC_IntermodalChassisEquipment()
		{
			EquipmentInitial = "d",
			EquipmentNumber = "5",
			TareWeight = 342,
			TareQualifierCode = "4",
			StandardCarrierAlphaCode = "JH",
			EquipmentLength = 1721,
			StandardCarrierAlphaCode2 = "4T",
			ChassisType = "Jq",
			EquipmentNumberCheckDigit = 2,
		};

		var actual = Map.MapObject<IC_IntermodalChassisEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentNumber = "5";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 342;
			subject.TareQualifierCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 342;
			subject.TareQualifierCode = "4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(342, "4", true)]
	[InlineData(342, "", false)]
	[InlineData(0, "4", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new IC_IntermodalChassisEquipment();
		subject.EquipmentInitial = "d";
		subject.EquipmentNumber = "5";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

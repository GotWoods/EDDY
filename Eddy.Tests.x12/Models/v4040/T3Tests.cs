using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class T3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T3*9*ye*0*Y2*7UfddL*o*g";

		var expected = new T3_TransitInboundRoute()
		{
			AssignedNumber = 9,
			StandardCarrierAlphaCode = "ye",
			RoutingSequenceCode = "0",
			CityName = "Y2",
			StandardPointLocationCode = "7UfddL",
			EquipmentInitial = "o",
			EquipmentNumber = "g",
		};

		var actual = Map.MapObject<T3_TransitInboundRoute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.StandardCarrierAlphaCode = "ye";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "o";
			subject.EquipmentNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ye", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 9;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "o";
			subject.EquipmentNumber = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "g", true)]
	[InlineData("o", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 9;
		subject.StandardCarrierAlphaCode = "ye";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

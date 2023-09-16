using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class T3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T3*1*hB*5*z4*Prymv6*o*J";

		var expected = new T3_TransitInboundRoute()
		{
			AssignedNumber = 1,
			StandardCarrierAlphaCode = "hB",
			RoutingSequenceCode = "5",
			CityName = "z4",
			StandardPointLocationCode = "Prymv6",
			EquipmentInitial = "o",
			EquipmentNumber = "J",
		};

		var actual = Map.MapObject<T3_TransitInboundRoute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.StandardCarrierAlphaCode = "hB";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "o";
			subject.EquipmentNumber = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hB", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 1;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentInitial) || !string.IsNullOrEmpty(subject.EquipmentNumber))
		{
			subject.EquipmentInitial = "o";
			subject.EquipmentNumber = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "J", true)]
	[InlineData("o", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 1;
		subject.StandardCarrierAlphaCode = "hB";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

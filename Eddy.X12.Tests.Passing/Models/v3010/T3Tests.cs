using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class T3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T3*6*T0*k*RR*14aUCI*V*6";

		var expected = new T3_TransitInboundRoute()
		{
			AssignedNumber = 6,
			StandardCarrierAlphaCode = "T0",
			RoutingSequenceCode = "k",
			CityName = "RR",
			StandardPointLocationCode = "14aUCI",
			EquipmentInitial = "V",
			EquipmentNumber = "6",
		};

		var actual = Map.MapObject<T3_TransitInboundRoute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.StandardCarrierAlphaCode = "T0";
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = "6";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T0", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 6;
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = "6";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 6;
		subject.StandardCarrierAlphaCode = "T0";
		subject.EquipmentNumber = "6";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 6;
		subject.StandardCarrierAlphaCode = "T0";
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class T3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T3*5*g9*f*rr*pEGfw9*X*W";

		var expected = new T3_TransitInboundRoute()
		{
			AssignedNumber = 5,
			StandardCarrierAlphaCode = "g9",
			RoutingSequenceCode = "f",
			CityName = "rr",
			StandardPointLocationCode = "pEGfw9",
			EquipmentInitial = "X",
			EquipmentNumber = "W",
		};

		var actual = Map.MapObject<T3_TransitInboundRoute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.StandardCarrierAlphaCode = "g9";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g9", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 5;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("X", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("X", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new T3_TransitInboundRoute();
		subject.AssignedNumber = 5;
		subject.StandardCarrierAlphaCode = "g9";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

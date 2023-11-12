using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class IS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS1*mt*9*s*a*ci*C*K*Ts";

		var expected = new IS1_EstimatedTimeOfArrivalAndCarScheduling()
		{
			TransactionSetPurposeCode = "mt",
			EquipmentInitial = "9",
			EquipmentNumber = "s",
			LoadEmptyStatusCode = "a",
			RetripReasonCode = "ci",
			CarTypeCode = "C",
			IndustryCode = "K",
			EquipmentDescriptionCode = "Ts",
		};

		var actual = Map.MapObject<IS1_EstimatedTimeOfArrivalAndCarScheduling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mt", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "s";
		subject.LoadEmptyStatusCode = "a";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "mt";
		subject.EquipmentNumber = "s";
		subject.LoadEmptyStatusCode = "a";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "mt";
		subject.EquipmentInitial = "9";
		subject.LoadEmptyStatusCode = "a";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "mt";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "s";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

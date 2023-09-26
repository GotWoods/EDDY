using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class IS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS1*Aa*q*Z*9*yo*9*C";

		var expected = new IS1_EstimatedTimeOfArrivalAndCarScheduling()
		{
			TransactionSetPurposeCode = "Aa",
			EquipmentInitial = "q",
			EquipmentNumber = "Z",
			LoadEmptyStatusCode = "9",
			RetripReasonCode = "yo",
			CarTypeCode = "9",
			IndustryCode = "C",
		};

		var actual = Map.MapObject<IS1_EstimatedTimeOfArrivalAndCarScheduling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Aa", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "Z";
		subject.LoadEmptyStatusCode = "9";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "Aa";
		subject.EquipmentNumber = "Z";
		subject.LoadEmptyStatusCode = "9";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "Aa";
		subject.EquipmentInitial = "q";
		subject.LoadEmptyStatusCode = "9";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "Aa";
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "Z";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

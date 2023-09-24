using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS1*nJ*M*B*J*m0*K*d*35";

		var expected = new IS1_EstimatedTimeOfArrivalAndCarScheduling()
		{
			TransactionSetPurposeCode = "nJ",
			EquipmentInitial = "M",
			EquipmentNumber = "B",
			LoadEmptyStatusCode = "J",
			RetripReasonCode = "m0",
			CarTypeCode = "K",
			IndustryCode = "d",
			EquipmentDescriptionCode = "35",
		};

		var actual = Map.MapObject<IS1_EstimatedTimeOfArrivalAndCarScheduling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nJ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "B";
		subject.LoadEmptyStatusCode = "J";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		subject.TransactionSetPurposeCode = "nJ";
		subject.EquipmentNumber = "B";
		subject.LoadEmptyStatusCode = "J";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		subject.TransactionSetPurposeCode = "nJ";
		subject.EquipmentInitial = "M";
		subject.LoadEmptyStatusCode = "J";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		subject.TransactionSetPurposeCode = "nJ";
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "B";
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

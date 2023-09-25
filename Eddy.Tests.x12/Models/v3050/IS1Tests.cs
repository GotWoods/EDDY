using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class IS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS1*vN*9*X*r*l6";

		var expected = new IS1_EstimatedTimeOfArrivalAndCarScheduling()
		{
			TransactionSetPurposeCode = "vN",
			EquipmentInitial = "9",
			EquipmentNumber = "X",
			LoadEmptyStatusCode = "r",
			RetripReasonCode = "l6",
		};

		var actual = Map.MapObject<IS1_EstimatedTimeOfArrivalAndCarScheduling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vN", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "X";
		subject.LoadEmptyStatusCode = "r";
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
		subject.TransactionSetPurposeCode = "vN";
		subject.EquipmentNumber = "X";
		subject.LoadEmptyStatusCode = "r";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "vN";
		subject.EquipmentInitial = "9";
		subject.LoadEmptyStatusCode = "r";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "vN";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "X";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

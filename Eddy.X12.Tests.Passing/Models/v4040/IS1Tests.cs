using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class IS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS1*7m*B*z*b*CJ*Z*k";

		var expected = new IS1_EstimatedTimeOfArrivalAndCarScheduling()
		{
			TransactionSetPurposeCode = "7m",
			EquipmentInitial = "B",
			EquipmentNumber = "z",
			LoadEmptyStatusCode = "b",
			RetripReasonCode = "CJ",
			CarTypeCode = "Z",
			IndustryCode = "k",
		};

		var actual = Map.MapObject<IS1_EstimatedTimeOfArrivalAndCarScheduling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7m", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "z";
		subject.LoadEmptyStatusCode = "b";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "7m";
		subject.EquipmentNumber = "z";
		subject.LoadEmptyStatusCode = "b";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "7m";
		subject.EquipmentInitial = "B";
		subject.LoadEmptyStatusCode = "b";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new IS1_EstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "7m";
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "z";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class IS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IS1*S0*s*a*C";

		var expected = new IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling()
		{
			TransactionSetPurposeCode = "S0",
			EquipmentInitial = "s",
			EquipmentNumber = "a",
			LoadEmptyStatusCode = "C",
		};

		var actual = Map.MapObject<IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S0", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "a";
		subject.LoadEmptyStatusCode = "C";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "S0";
		subject.EquipmentNumber = "a";
		subject.LoadEmptyStatusCode = "C";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "S0";
		subject.EquipmentInitial = "s";
		subject.LoadEmptyStatusCode = "C";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredLoadEmptyStatusCode(string loadEmptyStatusCode, bool isValidExpected)
	{
		var subject = new IS1_BeginningSegmentForEstimatedTimeOfArrivalAndCarScheduling();
		//Required fields
		subject.TransactionSetPurposeCode = "S0";
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "a";
		//Test Parameters
		subject.LoadEmptyStatusCode = loadEmptyStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

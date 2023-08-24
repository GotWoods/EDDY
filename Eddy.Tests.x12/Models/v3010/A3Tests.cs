using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class A3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A3*LgsD*J9YB*a*W*L*xV*e*2*s";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "LgsD",
			ReferenceDesignator = "J9YB",
			ErrorFieldData = "a",
			EquipmentInitial = "W",
			EquipmentNumber = "L",
			ReferenceNumberQualifier = "xV",
			ReferenceNumber = "e",
			ApplicationErrorConditionCode = "2",
			TransactionSetAcknowledgmentCode = "s",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LgsD", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "J9YB";
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = "xV";
		subject.TransactionSetAcknowledgmentCode = "s";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J9YB", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "LgsD";
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = "xV";
		subject.TransactionSetAcknowledgmentCode = "s";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "LgsD";
		subject.ReferenceDesignator = "J9YB";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = "xV";
		subject.TransactionSetAcknowledgmentCode = "s";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "LgsD";
		subject.ReferenceDesignator = "J9YB";
		subject.EquipmentInitial = "W";
		subject.ReferenceNumberQualifier = "xV";
		subject.TransactionSetAcknowledgmentCode = "s";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xV", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "LgsD";
		subject.ReferenceDesignator = "J9YB";
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = "L";
		subject.TransactionSetAcknowledgmentCode = "s";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "LgsD";
		subject.ReferenceDesignator = "J9YB";
		subject.EquipmentInitial = "W";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = "xV";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

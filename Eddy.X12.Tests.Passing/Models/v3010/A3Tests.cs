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
		string x12Line = "A3*Lt7N*CH7v*l*w*Y*9i*f*4*R";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "Lt7N",
			ReferenceDesignator = "CH7v",
			ErrorFieldData = "l",
			EquipmentInitial = "w",
			EquipmentNumber = "Y",
			ReferenceNumberQualifier = "9i",
			ReferenceNumber = "f",
			ApplicationErrorConditionCode = "4",
			TransactionSetAcknowledgmentCode = "R",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lt7N", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "Lt7N";
		subject.ReferenceDesignator = "CH7v";
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "Y";
		subject.ReferenceNumberQualifier = "9i";
		subject.TransactionSetAcknowledgmentCode = "R";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CH7v", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "Lt7N";
		subject.ReferenceDesignator = "CH7v";
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "Y";
		subject.ReferenceNumberQualifier = "9i";
		subject.TransactionSetAcknowledgmentCode = "R";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "Lt7N";
		subject.ReferenceDesignator = "CH7v";
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "Y";
		subject.ReferenceNumberQualifier = "9i";
		subject.TransactionSetAcknowledgmentCode = "R";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "Lt7N";
		subject.ReferenceDesignator = "CH7v";
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "Y";
		subject.ReferenceNumberQualifier = "9i";
		subject.TransactionSetAcknowledgmentCode = "R";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9i", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "Lt7N";
		subject.ReferenceDesignator = "CH7v";
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "Y";
		subject.ReferenceNumberQualifier = "9i";
		subject.TransactionSetAcknowledgmentCode = "R";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "Lt7N";
		subject.ReferenceDesignator = "CH7v";
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "Y";
		subject.ReferenceNumberQualifier = "9i";
		subject.TransactionSetAcknowledgmentCode = "R";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

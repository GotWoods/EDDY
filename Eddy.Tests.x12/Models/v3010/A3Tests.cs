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
		string x12Line = "A3*ZvYh*PGUz*o*h*9*12*N*x*k";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "ZvYh",
			ReferenceDesignator = "PGUz",
			ErrorFieldData = "o",
			EquipmentInitial = "h",
			EquipmentNumber = "9",
			ReferenceNumberQualifier = "12",
			ReferenceNumber = "N",
			ApplicationErrorConditionCode = "x",
			TransactionSetAcknowledgmentCode = "k",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZvYh", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "PGUz";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "9";
		subject.ReferenceNumberQualifier = "12";
		subject.TransactionSetAcknowledgmentCode = "k";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PGUz", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "ZvYh";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "9";
		subject.ReferenceNumberQualifier = "12";
		subject.TransactionSetAcknowledgmentCode = "k";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "ZvYh";
		subject.ReferenceDesignator = "PGUz";
		subject.EquipmentNumber = "9";
		subject.ReferenceNumberQualifier = "12";
		subject.TransactionSetAcknowledgmentCode = "k";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "ZvYh";
		subject.ReferenceDesignator = "PGUz";
		subject.EquipmentInitial = "h";
		subject.ReferenceNumberQualifier = "12";
		subject.TransactionSetAcknowledgmentCode = "k";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("12", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "ZvYh";
		subject.ReferenceDesignator = "PGUz";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "9";
		subject.TransactionSetAcknowledgmentCode = "k";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.TransactionSetControlNumber = "ZvYh";
		subject.ReferenceDesignator = "PGUz";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "9";
		subject.ReferenceNumberQualifier = "12";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

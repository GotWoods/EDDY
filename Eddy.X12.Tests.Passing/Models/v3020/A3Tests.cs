using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class A3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A3*Ki6k*J2IN*6*h*X*VP*Y*c*Y";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "Ki6k",
			ReferenceDesignator = "J2IN",
			ErrorFieldData = "6",
			EquipmentInitial = "h",
			EquipmentNumber = "X",
			ReferenceNumberQualifier = "VP",
			ReferenceNumber = "Y",
			ApplicationErrorConditionCode = "c",
			TransactionSetAcknowledgmentCode = "Y",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J2IN", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "J2IN";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "X";
		subject.TransactionSetAcknowledgmentCode = "Y";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "J2IN";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "X";
		subject.TransactionSetAcknowledgmentCode = "Y";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "J2IN";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "X";
		subject.TransactionSetAcknowledgmentCode = "Y";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VP", "Y", true)]
	[InlineData("VP", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "J2IN";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "X";
		subject.TransactionSetAcknowledgmentCode = "Y";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "J2IN";
		subject.EquipmentInitial = "h";
		subject.EquipmentNumber = "X";
		subject.TransactionSetAcknowledgmentCode = "Y";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

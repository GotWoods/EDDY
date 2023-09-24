using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class A3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A3*QDtv*sbKa*0*9*K*J9*i*I*a";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "QDtv",
			ReferenceDesignator = "sbKa",
			ErrorFieldData = "0",
			EquipmentInitial = "9",
			EquipmentNumber = "K",
			ReferenceIdentificationQualifier = "J9",
			ReferenceIdentification = "i",
			ApplicationErrorConditionCode = "I",
			TransactionSetAcknowledgmentCode = "a",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sbKa", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sbKa";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "K";
		subject.TransactionSetAcknowledgmentCode = "a";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sbKa";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "K";
		subject.TransactionSetAcknowledgmentCode = "a";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sbKa";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "K";
		subject.TransactionSetAcknowledgmentCode = "a";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J9", "i", true)]
	[InlineData("J9", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sbKa";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "K";
		subject.TransactionSetAcknowledgmentCode = "a";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sbKa";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "K";
		subject.TransactionSetAcknowledgmentCode = "a";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

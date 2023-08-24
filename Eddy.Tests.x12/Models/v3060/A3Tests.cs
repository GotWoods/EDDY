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
		string x12Line = "A3*6pDO*eIVP*D*x*c*19*G*P*E";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "6pDO",
			ReferenceDesignator = "eIVP",
			ErrorFieldData = "D",
			EquipmentInitial = "x",
			EquipmentNumber = "c",
			ReferenceIdentificationQualifier = "19",
			ReferenceIdentification = "G",
			ApplicationErrorConditionCode = "P",
			TransactionSetAcknowledgmentCode = "E",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eIVP", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.EquipmentInitial = "x";
		subject.EquipmentNumber = "c";
		subject.TransactionSetAcknowledgmentCode = "E";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "eIVP";
		subject.EquipmentNumber = "c";
		subject.TransactionSetAcknowledgmentCode = "E";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "eIVP";
		subject.EquipmentInitial = "x";
		subject.TransactionSetAcknowledgmentCode = "E";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("19", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("19", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "eIVP";
		subject.EquipmentInitial = "x";
		subject.EquipmentNumber = "c";
		subject.TransactionSetAcknowledgmentCode = "E";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "eIVP";
		subject.EquipmentInitial = "x";
		subject.EquipmentNumber = "c";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

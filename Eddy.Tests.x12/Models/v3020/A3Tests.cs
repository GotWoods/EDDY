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
		string x12Line = "A3*wdth*sLcn*p*M*r*3w*D*x*r";

		var expected = new A3_ApplicationRejection()
		{
			TransactionSetControlNumber = "wdth",
			ReferenceDesignator = "sLcn",
			ErrorFieldData = "p",
			EquipmentInitial = "M",
			EquipmentNumber = "r",
			ReferenceNumberQualifier = "3w",
			ReferenceNumber = "D",
			ApplicationErrorConditionCode = "x",
			TransactionSetAcknowledgmentCode = "r",
		};

		var actual = Map.MapObject<A3_ApplicationRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sLcn", true)]
	public void Validation_RequiredReferenceDesignator(string referenceDesignator, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "r";
		subject.TransactionSetAcknowledgmentCode = "r";
		subject.ReferenceDesignator = referenceDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sLcn";
		subject.EquipmentNumber = "r";
		subject.TransactionSetAcknowledgmentCode = "r";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sLcn";
		subject.EquipmentInitial = "M";
		subject.TransactionSetAcknowledgmentCode = "r";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3w", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("3w", "", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sLcn";
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "r";
		subject.TransactionSetAcknowledgmentCode = "r";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new A3_ApplicationRejection();
		subject.ReferenceDesignator = "sLcn";
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "r";
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

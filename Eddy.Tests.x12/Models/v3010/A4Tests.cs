using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class A4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A4*Nl0M*y*y*2K*9*5*0nqP2m*9";

		var expected = new A4_ApplicationAcceptance()
		{
			TransactionSetControlNumber = "Nl0M",
			EquipmentInitial = "y",
			EquipmentNumber = "y",
			ReferenceNumberQualifier = "2K",
			ReferenceNumber = "9",
			WaybillNumber = 5,
			WaybillDate = "0nqP2m",
			TotalEquipment = 9,
		};

		var actual = Map.MapObject<A4_ApplicationAcceptance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nl0M", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "y";
		subject.ReferenceNumberQualifier = "2K";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "Nl0M";
		subject.EquipmentNumber = "y";
		subject.ReferenceNumberQualifier = "2K";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "Nl0M";
		subject.EquipmentInitial = "y";
		subject.ReferenceNumberQualifier = "2K";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2K", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "Nl0M";
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "y";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

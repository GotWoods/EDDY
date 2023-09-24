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
		string x12Line = "A4*nycz*A*g*1i*K*7*gUr2yS*1";

		var expected = new A4_ApplicationAcceptance()
		{
			TransactionSetControlNumber = "nycz",
			EquipmentInitial = "A",
			EquipmentNumber = "g",
			ReferenceNumberQualifier = "1i",
			ReferenceNumber = "K",
			WaybillNumber = 7,
			WaybillDate = "gUr2yS",
			TotalEquipment = 1,
		};

		var actual = Map.MapObject<A4_ApplicationAcceptance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nycz", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "nycz";
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceNumberQualifier = "1i";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "nycz";
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceNumberQualifier = "1i";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "nycz";
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceNumberQualifier = "1i";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1i", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "nycz";
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceNumberQualifier = "1i";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

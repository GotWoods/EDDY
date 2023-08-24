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
		string x12Line = "A4*2acB*z*L*BC*l*2*BVP9eM*7";

		var expected = new A4_ApplicationAcceptance()
		{
			TransactionSetControlNumber = "2acB",
			EquipmentInitial = "z",
			EquipmentNumber = "L",
			ReferenceNumberQualifier = "BC",
			ReferenceNumber = "l",
			WaybillNumber = 2,
			WaybillDate = "BVP9eM",
			TotalEquipment = 7,
		};

		var actual = Map.MapObject<A4_ApplicationAcceptance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2acB", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = "BC";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "2acB";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = "BC";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "2acB";
		subject.EquipmentInitial = "z";
		subject.ReferenceNumberQualifier = "BC";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BC", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.TransactionSetControlNumber = "2acB";
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "L";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

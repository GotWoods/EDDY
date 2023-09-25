using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ZDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZD*b7T*S*D*U*d*oEziDT*Kl*cn";

		var expected = new ZD_TransactionSetDeletionIDReasonAndSource()
		{
			TransactionSetIdentifierCode = "b7T",
			ShipmentIdentificationNumber = "S",
			EquipmentInitial = "D",
			EquipmentNumber = "U",
			TransactionReferenceNumber = "d",
			TransactionReferenceDate = "oEziDT",
			CorrectionIndicator = "Kl",
			StandardCarrierAlphaCode = "cn",
		};

		var actual = Map.MapObject<ZD_TransactionSetDeletionIDReasonAndSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b7T", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.EquipmentInitial = "D";
		subject.EquipmentNumber = "U";
		subject.CorrectionIndicator = "Kl";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "b7T";
		subject.EquipmentNumber = "U";
		subject.CorrectionIndicator = "Kl";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "b7T";
		subject.EquipmentInitial = "D";
		subject.CorrectionIndicator = "Kl";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kl", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "b7T";
		subject.EquipmentInitial = "D";
		subject.EquipmentNumber = "U";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

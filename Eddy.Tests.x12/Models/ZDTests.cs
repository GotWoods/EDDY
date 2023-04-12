using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ZDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZD*d2q*t*J*v*x*urUOM7Qs*Y2*PE*8";

		var expected = new ZD_TransactionSetDeletionIDReasonAndSource()
		{
			TransactionSetIdentifierCode = "d2q",
			ShipmentIdentificationNumber = "t",
			EquipmentInitial = "J",
			EquipmentNumber = "v",
			TransactionReferenceNumber = "x",
			TransactionReferenceDate = "urUOM7Qs",
			CorrectionIndicatorCode = "Y2",
			StandardCarrierAlphaCode = "PE",
			EquipmentNumberCheckDigit = 8,
		};

		var actual = Map.MapObject<ZD_TransactionSetDeletionIDReasonAndSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d2q", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		subject.EquipmentInitial = "J";
		subject.EquipmentNumber = "v";
		subject.CorrectionIndicatorCode = "Y2";
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		subject.TransactionSetIdentifierCode = "d2q";
		subject.EquipmentNumber = "v";
		subject.CorrectionIndicatorCode = "Y2";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		subject.TransactionSetIdentifierCode = "d2q";
		subject.EquipmentInitial = "J";
		subject.CorrectionIndicatorCode = "Y2";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y2", true)]
	public void Validation_RequiredCorrectionIndicatorCode(string correctionIndicatorCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		subject.TransactionSetIdentifierCode = "d2q";
		subject.EquipmentInitial = "J";
		subject.EquipmentNumber = "v";
		subject.CorrectionIndicatorCode = correctionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ZDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZD*F9I*F*O*0*m*LgG5Z4op*Uk*r3*1";

		var expected = new ZD_TransactionSetDeletionIDReasonAndSource()
		{
			TransactionSetIdentifierCode = "F9I",
			ShipmentIdentificationNumber = "F",
			EquipmentInitial = "O",
			EquipmentNumber = "0",
			TransactionReferenceNumber = "m",
			TransactionReferenceDate = "LgG5Z4op",
			CorrectionIndicatorCode = "Uk",
			StandardCarrierAlphaCode = "r3",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<ZD_TransactionSetDeletionIDReasonAndSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F9I", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "0";
		subject.CorrectionIndicatorCode = "Uk";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "F9I";
		subject.EquipmentNumber = "0";
		subject.CorrectionIndicatorCode = "Uk";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "F9I";
		subject.EquipmentInitial = "O";
		subject.CorrectionIndicatorCode = "Uk";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uk", true)]
	public void Validation_RequiredCorrectionIndicatorCode(string correctionIndicatorCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "F9I";
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "0";
		//Test Parameters
		subject.CorrectionIndicatorCode = correctionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

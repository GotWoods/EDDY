using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ZDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZD*tiN*q*k*B*8*aojEyBts*aL*ZQ";

		var expected = new ZD_TransactionSetDeletionIDReasonAndSource()
		{
			TransactionSetIdentifierCode = "tiN",
			ShipmentIdentificationNumber = "q",
			EquipmentInitial = "k",
			EquipmentNumber = "B",
			TransactionReferenceNumber = "8",
			TransactionReferenceDate = "aojEyBts",
			CorrectionIndicator = "aL",
			StandardCarrierAlphaCode = "ZQ",
		};

		var actual = Map.MapObject<ZD_TransactionSetDeletionIDReasonAndSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tiN", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "B";
		subject.CorrectionIndicator = "aL";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "tiN";
		subject.EquipmentNumber = "B";
		subject.CorrectionIndicator = "aL";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "tiN";
		subject.EquipmentInitial = "k";
		subject.CorrectionIndicator = "aL";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aL", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "tiN";
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "B";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

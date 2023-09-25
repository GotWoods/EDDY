using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ZDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZD*3vo*D*B*W*tv*6mrCog*RU*f4";

		var expected = new ZD_TransactionSetDeletionIDReasonAndSource()
		{
			TransactionSetIdentifierCode = "3vo",
			ShipmentIdentificationNumber = "D",
			EquipmentInitial = "B",
			EquipmentNumber = "W",
			TransactionReferenceNumber = "tv",
			TransactionReferenceDate = "6mrCog",
			CorrectionIndicator = "RU",
			StandardCarrierAlphaCode = "f4",
		};

		var actual = Map.MapObject<ZD_TransactionSetDeletionIDReasonAndSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3vo", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "W";
		subject.CorrectionIndicator = "RU";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "3vo";
		subject.EquipmentNumber = "W";
		subject.CorrectionIndicator = "RU";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "3vo";
		subject.EquipmentInitial = "B";
		subject.CorrectionIndicator = "RU";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RU", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "3vo";
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "W";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZD*IO1*b*J*0*eD*zSnK5I*Dz*0g";

		var expected = new ZD_TransactionSetDeletionIDReasonAndSource()
		{
			TransactionSetIdentifierCode = "IO1",
			ShipmentIdentificationNumber = "b",
			EquipmentInitial = "J",
			EquipmentNumber = "0",
			TransactionReferenceNumber = "eD",
			TransactionReferenceDate = "zSnK5I",
			CorrectionIndicator = "Dz",
			StandardCarrierAlphaCode = "0g",
		};

		var actual = Map.MapObject<ZD_TransactionSetDeletionIDReasonAndSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IO1", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.CorrectionIndicator = "Dz";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dz", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZD_TransactionSetDeletionIDReasonAndSource();
		//Required fields
		subject.TransactionSetIdentifierCode = "IO1";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

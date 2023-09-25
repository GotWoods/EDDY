using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*P*L*Q*B*Figg4KIR*CI*I6*v*1";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "P",
			EquipmentInitial = "L",
			EquipmentNumber = "Q",
			TransactionReferenceNumber = "B",
			TransactionReferenceDate = "Figg4KIR",
			CorrectionIndicatorCode = "CI",
			StandardCarrierAlphaCode = "I6",
			TransportationMethodTypeCode = "v",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.TransactionReferenceNumber = "B";
		subject.TransactionReferenceDate = "Figg4KIR";
		subject.CorrectionIndicatorCode = "CI";
		subject.StandardCarrierAlphaCode = "I6";
		subject.TransportationMethodTypeCode = "v";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.TransactionReferenceDate = "Figg4KIR";
		subject.CorrectionIndicatorCode = "CI";
		subject.StandardCarrierAlphaCode = "I6";
		subject.TransportationMethodTypeCode = "v";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Figg4KIR", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.TransactionReferenceNumber = "B";
		subject.CorrectionIndicatorCode = "CI";
		subject.StandardCarrierAlphaCode = "I6";
		subject.TransportationMethodTypeCode = "v";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CI", true)]
	public void Validation_RequiredCorrectionIndicatorCode(string correctionIndicatorCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.TransactionReferenceNumber = "B";
		subject.TransactionReferenceDate = "Figg4KIR";
		subject.StandardCarrierAlphaCode = "I6";
		subject.TransportationMethodTypeCode = "v";
		//Test Parameters
		subject.CorrectionIndicatorCode = correctionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I6", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.TransactionReferenceNumber = "B";
		subject.TransactionReferenceDate = "Figg4KIR";
		subject.CorrectionIndicatorCode = "CI";
		subject.TransportationMethodTypeCode = "v";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "Q";
		subject.TransactionReferenceNumber = "B";
		subject.TransactionReferenceDate = "Figg4KIR";
		subject.CorrectionIndicatorCode = "CI";
		subject.StandardCarrierAlphaCode = "I6";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

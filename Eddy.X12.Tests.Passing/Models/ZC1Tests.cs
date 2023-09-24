using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*4*N*9*3*MbeNMLCu*j1*Qk*E*7";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "4",
			EquipmentInitial = "N",
			EquipmentNumber = "9",
			TransactionReferenceNumber = "3",
			TransactionReferenceDate = "MbeNMLCu",
			CorrectionIndicatorCode = "j1",
			StandardCarrierAlphaCode = "Qk",
			TransportationMethodTypeCode = "E",
			EquipmentNumberCheckDigit = 7,
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		subject.TransactionReferenceNumber = "3";
		subject.TransactionReferenceDate = "MbeNMLCu";
		subject.CorrectionIndicatorCode = "j1";
		subject.StandardCarrierAlphaCode = "Qk";
		subject.TransportationMethodTypeCode = "E";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		subject.EquipmentNumber = "9";
		subject.TransactionReferenceDate = "MbeNMLCu";
		subject.CorrectionIndicatorCode = "j1";
		subject.StandardCarrierAlphaCode = "Qk";
		subject.TransportationMethodTypeCode = "E";
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MbeNMLCu", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		subject.EquipmentNumber = "9";
		subject.TransactionReferenceNumber = "3";
		subject.CorrectionIndicatorCode = "j1";
		subject.StandardCarrierAlphaCode = "Qk";
		subject.TransportationMethodTypeCode = "E";
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j1", true)]
	public void Validation_RequiredCorrectionIndicatorCode(string correctionIndicatorCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		subject.EquipmentNumber = "9";
		subject.TransactionReferenceNumber = "3";
		subject.TransactionReferenceDate = "MbeNMLCu";
		subject.StandardCarrierAlphaCode = "Qk";
		subject.TransportationMethodTypeCode = "E";
		subject.CorrectionIndicatorCode = correctionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qk", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		subject.EquipmentNumber = "9";
		subject.TransactionReferenceNumber = "3";
		subject.TransactionReferenceDate = "MbeNMLCu";
		subject.CorrectionIndicatorCode = "j1";
		subject.TransportationMethodTypeCode = "E";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		subject.EquipmentNumber = "9";
		subject.TransactionReferenceNumber = "3";
		subject.TransactionReferenceDate = "MbeNMLCu";
		subject.CorrectionIndicatorCode = "j1";
		subject.StandardCarrierAlphaCode = "Qk";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

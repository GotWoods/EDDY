using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*9*R*T*q*1svsu7*u2*Ja*T";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "9",
			EquipmentInitial = "R",
			EquipmentNumber = "T",
			TransactionReferenceNumber = "q",
			TransactionReferenceDate = "1svsu7",
			CorrectionIndicator = "u2",
			StandardCarrierAlphaCode = "Ja",
			TransportationMethodTypeCode = "T",
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.TransactionReferenceNumber = "q";
		subject.TransactionReferenceDate = "1svsu7";
		subject.CorrectionIndicator = "u2";
		subject.StandardCarrierAlphaCode = "Ja";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "T";
		subject.TransactionReferenceDate = "1svsu7";
		subject.CorrectionIndicator = "u2";
		subject.StandardCarrierAlphaCode = "Ja";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1svsu7", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "T";
		subject.TransactionReferenceNumber = "q";
		subject.CorrectionIndicator = "u2";
		subject.StandardCarrierAlphaCode = "Ja";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u2", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "T";
		subject.TransactionReferenceNumber = "q";
		subject.TransactionReferenceDate = "1svsu7";
		subject.StandardCarrierAlphaCode = "Ja";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ja", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "T";
		subject.TransactionReferenceNumber = "q";
		subject.TransactionReferenceDate = "1svsu7";
		subject.CorrectionIndicator = "u2";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "T";
		subject.TransactionReferenceNumber = "q";
		subject.TransactionReferenceDate = "1svsu7";
		subject.CorrectionIndicator = "u2";
		subject.StandardCarrierAlphaCode = "Ja";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*q*n*f*P*DigyBnpz*dl*2S*z*4";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "q",
			EquipmentInitial = "n",
			EquipmentNumber = "f",
			TransactionReferenceNumber = "P",
			TransactionReferenceDate = "DigyBnpz",
			CorrectionIndicator = "dl",
			StandardCarrierAlphaCode = "2S",
			TransportationMethodTypeCode = "z",
			EquipmentNumberCheckDigit = 4,
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.TransactionReferenceNumber = "P";
		subject.TransactionReferenceDate = "DigyBnpz";
		subject.CorrectionIndicator = "dl";
		subject.StandardCarrierAlphaCode = "2S";
		subject.TransportationMethodTypeCode = "z";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "f";
		subject.TransactionReferenceDate = "DigyBnpz";
		subject.CorrectionIndicator = "dl";
		subject.StandardCarrierAlphaCode = "2S";
		subject.TransportationMethodTypeCode = "z";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DigyBnpz", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "f";
		subject.TransactionReferenceNumber = "P";
		subject.CorrectionIndicator = "dl";
		subject.StandardCarrierAlphaCode = "2S";
		subject.TransportationMethodTypeCode = "z";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dl", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "f";
		subject.TransactionReferenceNumber = "P";
		subject.TransactionReferenceDate = "DigyBnpz";
		subject.StandardCarrierAlphaCode = "2S";
		subject.TransportationMethodTypeCode = "z";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2S", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "f";
		subject.TransactionReferenceNumber = "P";
		subject.TransactionReferenceDate = "DigyBnpz";
		subject.CorrectionIndicator = "dl";
		subject.TransportationMethodTypeCode = "z";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "f";
		subject.TransactionReferenceNumber = "P";
		subject.TransactionReferenceDate = "DigyBnpz";
		subject.CorrectionIndicator = "dl";
		subject.StandardCarrierAlphaCode = "2S";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*C*h*G*bG*HwHl16*pE*0v*j";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "C",
			EquipmentInitial = "h",
			EquipmentNumber = "G",
			TransactionReferenceNumber = "bG",
			TransactionReferenceDate = "HwHl16",
			CorrectionIndicator = "pE",
			StandardCarrierAlphaCode = "0v",
			TransportationMethodTypeCode = "j",
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "G";
		subject.TransactionReferenceNumber = "bG";
		subject.TransactionReferenceDate = "HwHl16";
		subject.CorrectionIndicator = "pE";
		subject.StandardCarrierAlphaCode = "0v";
		subject.TransportationMethodTypeCode = "j";
		//Test Parameters
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.ShipmentIdentificationNumber = "C";
		subject.TransactionReferenceNumber = "bG";
		subject.TransactionReferenceDate = "HwHl16";
		subject.CorrectionIndicator = "pE";
		subject.StandardCarrierAlphaCode = "0v";
		subject.TransportationMethodTypeCode = "j";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bG", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.ShipmentIdentificationNumber = "C";
		subject.EquipmentNumber = "G";
		subject.TransactionReferenceDate = "HwHl16";
		subject.CorrectionIndicator = "pE";
		subject.StandardCarrierAlphaCode = "0v";
		subject.TransportationMethodTypeCode = "j";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HwHl16", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.ShipmentIdentificationNumber = "C";
		subject.EquipmentNumber = "G";
		subject.TransactionReferenceNumber = "bG";
		subject.CorrectionIndicator = "pE";
		subject.StandardCarrierAlphaCode = "0v";
		subject.TransportationMethodTypeCode = "j";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pE", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.ShipmentIdentificationNumber = "C";
		subject.EquipmentNumber = "G";
		subject.TransactionReferenceNumber = "bG";
		subject.TransactionReferenceDate = "HwHl16";
		subject.StandardCarrierAlphaCode = "0v";
		subject.TransportationMethodTypeCode = "j";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0v", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.ShipmentIdentificationNumber = "C";
		subject.EquipmentNumber = "G";
		subject.TransactionReferenceNumber = "bG";
		subject.TransactionReferenceDate = "HwHl16";
		subject.CorrectionIndicator = "pE";
		subject.TransportationMethodTypeCode = "j";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.ShipmentIdentificationNumber = "C";
		subject.EquipmentNumber = "G";
		subject.TransactionReferenceNumber = "bG";
		subject.TransactionReferenceDate = "HwHl16";
		subject.CorrectionIndicator = "pE";
		subject.StandardCarrierAlphaCode = "0v";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*z*e*t*W*slV9mKq1*hT*3f*x*1";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "z",
			EquipmentInitial = "e",
			EquipmentNumber = "t",
			TransactionReferenceNumber = "W",
			TransactionReferenceDate = "slV9mKq1",
			CorrectionIndicator = "hT",
			StandardCarrierAlphaCode = "3f",
			TransportationMethodTypeCode = "x",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.TransactionReferenceNumber = "W";
		subject.TransactionReferenceDate = "slV9mKq1";
		subject.CorrectionIndicator = "hT";
		subject.StandardCarrierAlphaCode = "3f";
		subject.TransportationMethodTypeCode = "x";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "t";
		subject.TransactionReferenceDate = "slV9mKq1";
		subject.CorrectionIndicator = "hT";
		subject.StandardCarrierAlphaCode = "3f";
		subject.TransportationMethodTypeCode = "x";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("slV9mKq1", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "t";
		subject.TransactionReferenceNumber = "W";
		subject.CorrectionIndicator = "hT";
		subject.StandardCarrierAlphaCode = "3f";
		subject.TransportationMethodTypeCode = "x";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hT", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "t";
		subject.TransactionReferenceNumber = "W";
		subject.TransactionReferenceDate = "slV9mKq1";
		subject.StandardCarrierAlphaCode = "3f";
		subject.TransportationMethodTypeCode = "x";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3f", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "t";
		subject.TransactionReferenceNumber = "W";
		subject.TransactionReferenceDate = "slV9mKq1";
		subject.CorrectionIndicator = "hT";
		subject.TransportationMethodTypeCode = "x";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "t";
		subject.TransactionReferenceNumber = "W";
		subject.TransactionReferenceDate = "slV9mKq1";
		subject.CorrectionIndicator = "hT";
		subject.StandardCarrierAlphaCode = "3f";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

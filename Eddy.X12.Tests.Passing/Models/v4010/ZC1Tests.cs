using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*E*A*u*D*gT60GsKE*zu*BM*V";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "E",
			EquipmentInitial = "A",
			EquipmentNumber = "u",
			TransactionReferenceNumber = "D",
			TransactionReferenceDate = "gT60GsKE",
			CorrectionIndicator = "zu",
			StandardCarrierAlphaCode = "BM",
			TransportationMethodTypeCode = "V",
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.TransactionReferenceNumber = "D";
		subject.TransactionReferenceDate = "gT60GsKE";
		subject.CorrectionIndicator = "zu";
		subject.StandardCarrierAlphaCode = "BM";
		subject.TransportationMethodTypeCode = "V";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "u";
		subject.TransactionReferenceDate = "gT60GsKE";
		subject.CorrectionIndicator = "zu";
		subject.StandardCarrierAlphaCode = "BM";
		subject.TransportationMethodTypeCode = "V";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gT60GsKE", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "u";
		subject.TransactionReferenceNumber = "D";
		subject.CorrectionIndicator = "zu";
		subject.StandardCarrierAlphaCode = "BM";
		subject.TransportationMethodTypeCode = "V";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zu", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "u";
		subject.TransactionReferenceNumber = "D";
		subject.TransactionReferenceDate = "gT60GsKE";
		subject.StandardCarrierAlphaCode = "BM";
		subject.TransportationMethodTypeCode = "V";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BM", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "u";
		subject.TransactionReferenceNumber = "D";
		subject.TransactionReferenceDate = "gT60GsKE";
		subject.CorrectionIndicator = "zu";
		subject.TransportationMethodTypeCode = "V";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "u";
		subject.TransactionReferenceNumber = "D";
		subject.TransactionReferenceDate = "gT60GsKE";
		subject.CorrectionIndicator = "zu";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

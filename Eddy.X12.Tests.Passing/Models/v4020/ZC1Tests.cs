using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class ZC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC1*J*O*I*7*dDqDRhsP*ML*YU*5*2";

		var expected = new ZC1_BeginningSegmentForDataCorrectionOrChange()
		{
			ShipmentIdentificationNumber = "J",
			EquipmentInitial = "O",
			EquipmentNumber = "I",
			TransactionReferenceNumber = "7",
			TransactionReferenceDate = "dDqDRhsP",
			CorrectionIndicator = "ML",
			StandardCarrierAlphaCode = "YU",
			TransportationMethodTypeCode = "5",
			EquipmentNumberCheckDigit = 2,
		};

		var actual = Map.MapObject<ZC1_BeginningSegmentForDataCorrectionOrChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.TransactionReferenceNumber = "7";
		subject.TransactionReferenceDate = "dDqDRhsP";
		subject.CorrectionIndicator = "ML";
		subject.StandardCarrierAlphaCode = "YU";
		subject.TransportationMethodTypeCode = "5";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredTransactionReferenceNumber(string transactionReferenceNumber, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "I";
		subject.TransactionReferenceDate = "dDqDRhsP";
		subject.CorrectionIndicator = "ML";
		subject.StandardCarrierAlphaCode = "YU";
		subject.TransportationMethodTypeCode = "5";
		//Test Parameters
		subject.TransactionReferenceNumber = transactionReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dDqDRhsP", true)]
	public void Validation_RequiredTransactionReferenceDate(string transactionReferenceDate, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "I";
		subject.TransactionReferenceNumber = "7";
		subject.CorrectionIndicator = "ML";
		subject.StandardCarrierAlphaCode = "YU";
		subject.TransportationMethodTypeCode = "5";
		//Test Parameters
		subject.TransactionReferenceDate = transactionReferenceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ML", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "I";
		subject.TransactionReferenceNumber = "7";
		subject.TransactionReferenceDate = "dDqDRhsP";
		subject.StandardCarrierAlphaCode = "YU";
		subject.TransportationMethodTypeCode = "5";
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YU", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "I";
		subject.TransactionReferenceNumber = "7";
		subject.TransactionReferenceDate = "dDqDRhsP";
		subject.CorrectionIndicator = "ML";
		subject.TransportationMethodTypeCode = "5";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new ZC1_BeginningSegmentForDataCorrectionOrChange();
		//Required fields
		subject.EquipmentNumber = "I";
		subject.TransactionReferenceNumber = "7";
		subject.TransactionReferenceDate = "dDqDRhsP";
		subject.CorrectionIndicator = "ML";
		subject.StandardCarrierAlphaCode = "YU";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

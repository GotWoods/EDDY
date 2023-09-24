using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BSNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSN*Zg*2F*21N8ML*gBZy*JKG4*D2*IYL";

		var expected = new BSN_BeginningSegmentForShipNotice()
		{
			TransactionSetPurposeCode = "Zg",
			ShipmentIdentification = "2F",
			Date = "21N8ML",
			Time = "gBZy",
			HierarchicalStructureCode = "JKG4",
			TransactionTypeCode = "D2",
			StatusReasonCode = "IYL",
		};

		var actual = Map.MapObject<BSN_BeginningSegmentForShipNotice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zg", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.ShipmentIdentification = "2F";
		subject.Date = "21N8ML";
		subject.Time = "gBZy";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2F", true)]
	public void Validation_RequiredShipmentIdentification(string shipmentIdentification, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Zg";
		subject.Date = "21N8ML";
		subject.Time = "gBZy";
		subject.ShipmentIdentification = shipmentIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("21N8ML", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Zg";
		subject.ShipmentIdentification = "2F";
		subject.Time = "gBZy";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gBZy", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Zg";
		subject.ShipmentIdentification = "2F";
		subject.Date = "21N8ML";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IYL", "D2", true)]
	[InlineData("IYL", "", false)]
	[InlineData("", "D2", true)]
	public void Validation_ARequiresBStatusReasonCode(string statusReasonCode, string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Zg";
		subject.ShipmentIdentification = "2F";
		subject.Date = "21N8ML";
		subject.Time = "gBZy";
		subject.StatusReasonCode = statusReasonCode;
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BSNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSN*yK*Hg*Q3PGrt*1s8R*4jXy*dO*F4y";

		var expected = new BSN_BeginningSegmentForShipNotice()
		{
			TransactionSetPurposeCode = "yK",
			ShipmentIdentification = "Hg",
			Date = "Q3PGrt",
			Time = "1s8R",
			HierarchicalStructureCode = "4jXy",
			TransactionTypeCode = "dO",
			StatusReasonCode = "F4y",
		};

		var actual = Map.MapObject<BSN_BeginningSegmentForShipNotice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yK", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.ShipmentIdentification = "Hg";
		subject.Date = "Q3PGrt";
		subject.Time = "1s8R";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hg", true)]
	public void Validation_RequiredShipmentIdentification(string shipmentIdentification, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "yK";
		subject.Date = "Q3PGrt";
		subject.Time = "1s8R";
		subject.ShipmentIdentification = shipmentIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q3PGrt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "yK";
		subject.ShipmentIdentification = "Hg";
		subject.Time = "1s8R";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1s8R", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "yK";
		subject.ShipmentIdentification = "Hg";
		subject.Date = "Q3PGrt";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F4y", "dO", true)]
	[InlineData("F4y", "", false)]
	[InlineData("", "dO", true)]
	public void Validation_ARequiresBStatusReasonCode(string statusReasonCode, string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "yK";
		subject.ShipmentIdentification = "Hg";
		subject.Date = "Q3PGrt";
		subject.Time = "1s8R";
		subject.StatusReasonCode = statusReasonCode;
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

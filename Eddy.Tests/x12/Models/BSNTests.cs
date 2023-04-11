using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BSNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSN*7q*dA*CfR2Dckc*liFI*pCiN*jY*0P2";

		var expected = new BSN_BeginningSegmentForShipNotice()
		{
			TransactionSetPurposeCode = "7q",
			ShipmentIdentification = "dA",
			Date = "CfR2Dckc",
			Time = "liFI",
			HierarchicalStructureCode = "pCiN",
			TransactionTypeCode = "jY",
			StatusReasonCode = "0P2",
		};

		var actual = Map.MapObject<BSN_BeginningSegmentForShipNotice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7q", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.ShipmentIdentification = "dA";
		subject.Date = "CfR2Dckc";
		subject.Time = "liFI";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dA", true)]
	public void Validation_RequiredShipmentIdentification(string shipmentIdentification, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "7q";
		subject.Date = "CfR2Dckc";
		subject.Time = "liFI";
		subject.ShipmentIdentification = shipmentIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CfR2Dckc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "7q";
		subject.ShipmentIdentification = "dA";
		subject.Time = "liFI";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("liFI", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "7q";
		subject.ShipmentIdentification = "dA";
		subject.Date = "CfR2Dckc";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "jY", true)]
	[InlineData("0P2", "", false)]
	public void Validation_ARequiresBStatusReasonCode(string statusReasonCode, string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "7q";
		subject.ShipmentIdentification = "dA";
		subject.Date = "CfR2Dckc";
		subject.Time = "liFI";
		subject.StatusReasonCode = statusReasonCode;
		subject.TransactionTypeCode = transactionTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

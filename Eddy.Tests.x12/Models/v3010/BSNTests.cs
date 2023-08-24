using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BSNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSN*Fg*ET*d1ouAR*auaq";

		var expected = new BSN_BeginningSegmentForShipNotice()
		{
			TransactionSetPurposeCode = "Fg",
			ShipmentIdentification = "ET",
			Date = "d1ouAR",
			Time = "auaq",
		};

		var actual = Map.MapObject<BSN_BeginningSegmentForShipNotice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fg", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.ShipmentIdentification = "ET";
		subject.Date = "d1ouAR";
		subject.Time = "auaq";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ET", true)]
	public void Validation_RequiredShipmentIdentification(string shipmentIdentification, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Fg";
		subject.Date = "d1ouAR";
		subject.Time = "auaq";
		subject.ShipmentIdentification = shipmentIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d1ouAR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Fg";
		subject.ShipmentIdentification = "ET";
		subject.Time = "auaq";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("auaq", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "Fg";
		subject.ShipmentIdentification = "ET";
		subject.Date = "d1ouAR";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

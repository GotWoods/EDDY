using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BSNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSN*rV*fe*jidJJc*1VCv";

		var expected = new BSN_BeginningSegmentForShipNotice()
		{
			TransactionSetPurposeCode = "rV",
			ShipmentIdentification = "fe",
			Date = "jidJJc",
			Time = "1VCv",
		};

		var actual = Map.MapObject<BSN_BeginningSegmentForShipNotice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rV", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.ShipmentIdentification = "fe";
		subject.Date = "jidJJc";
		subject.Time = "1VCv";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fe", true)]
	public void Validation_RequiredShipmentIdentification(string shipmentIdentification, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "rV";
		subject.Date = "jidJJc";
		subject.Time = "1VCv";
		subject.ShipmentIdentification = shipmentIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jidJJc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "rV";
		subject.ShipmentIdentification = "fe";
		subject.Time = "1VCv";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1VCv", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new BSN_BeginningSegmentForShipNotice();
		subject.TransactionSetPurposeCode = "rV";
		subject.ShipmentIdentification = "fe";
		subject.Date = "jidJJc";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

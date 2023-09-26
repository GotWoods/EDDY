using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*UW*D*rGMSk1*G*m7G2";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "UW",
			FreightStationAccountingCode = "D",
			Date = "rGMSk1",
			Rule260JunctionCode = "G",
			PostalCode = "m7G2",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UW", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.FreightStationAccountingCode = "D";
		subject.Date = "rGMSk1";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "UW";
		subject.Date = "rGMSk1";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rGMSk1", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "UW";
		subject.FreightStationAccountingCode = "D";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

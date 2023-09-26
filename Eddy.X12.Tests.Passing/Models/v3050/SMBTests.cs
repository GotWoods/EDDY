using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SMBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMB*G9*DVzypQ*g*85bYM5*L*V*N*z";

		var expected = new SMB_BeginningSegmentForRailroadStationMasterFile()
		{
			TransactionSetPurposeCode = "G9",
			Date = "DVzypQ",
			StationTypeCode = "g",
			StandardPointLocationCode = "85bYM5",
			StationTypeCode2 = "L",
			StationTypeCode3 = "V",
			StationTypeCode4 = "N",
			YesNoConditionOrResponseCode = "z",
		};

		var actual = Map.MapObject<SMB_BeginningSegmentForRailroadStationMasterFile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G9", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.Date = "DVzypQ";
		subject.StationTypeCode = "g";
		subject.YesNoConditionOrResponseCode = "z";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DVzypQ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "G9";
		subject.StationTypeCode = "g";
		subject.YesNoConditionOrResponseCode = "z";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredStationTypeCode(string stationTypeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "G9";
		subject.Date = "DVzypQ";
		subject.YesNoConditionOrResponseCode = "z";
		//Test Parameters
		subject.StationTypeCode = stationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "G9";
		subject.Date = "DVzypQ";
		subject.StationTypeCode = "g";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

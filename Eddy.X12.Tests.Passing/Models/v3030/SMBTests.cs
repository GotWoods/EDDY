using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SMBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMB*1B*vAbsQD*D*iPmfk2*L*D*J";

		var expected = new SMB_BeginningSegmentForRailroadStationMasterFile()
		{
			TransactionSetPurposeCode = "1B",
			Date = "vAbsQD",
			StationTypeCode = "D",
			StandardPointLocationCode = "iPmfk2",
			StationTypeCode2 = "L",
			StationTypeCode3 = "D",
			StationTypeCode4 = "J",
		};

		var actual = Map.MapObject<SMB_BeginningSegmentForRailroadStationMasterFile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1B", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.Date = "vAbsQD";
		subject.StationTypeCode = "D";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vAbsQD", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "1B";
		subject.StationTypeCode = "D";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredStationTypeCode(string stationTypeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "1B";
		subject.Date = "vAbsQD";
		//Test Parameters
		subject.StationTypeCode = stationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

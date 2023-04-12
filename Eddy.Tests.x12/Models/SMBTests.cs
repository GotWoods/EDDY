using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SMBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMB*zY*Q*dwNGas*x*j*9*z*F*U*zm";

		var expected = new SMB_BeginningSegmentForRailroadStationMasterFile()
		{
			TransactionSetPurposeCode = "zY",
			StationTypeCode = "Q",
			StandardPointLocationCode = "dwNGas",
			StationTypeCode2 = "x",
			StationTypeCode3 = "j",
			StationTypeCode4 = "9",
			YesNoConditionOrResponseCode = "z",
			Rule260JunctionCode = "F",
			StationTypeCode5 = "U",
			StatusCode = "zm",
		};

		var actual = Map.MapObject<SMB_BeginningSegmentForRailroadStationMasterFile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zY", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		subject.StationTypeCode = "Q";
		subject.StandardPointLocationCode = "dwNGas";
		subject.YesNoConditionOrResponseCode = "z";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredStationTypeCode(string stationTypeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		subject.TransactionSetPurposeCode = "zY";
		subject.StandardPointLocationCode = "dwNGas";
		subject.YesNoConditionOrResponseCode = "z";
		subject.StationTypeCode = stationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dwNGas", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		subject.TransactionSetPurposeCode = "zY";
		subject.StationTypeCode = "Q";
		subject.YesNoConditionOrResponseCode = "z";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		subject.TransactionSetPurposeCode = "zY";
		subject.StationTypeCode = "Q";
		subject.StandardPointLocationCode = "dwNGas";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

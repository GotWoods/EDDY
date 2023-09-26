using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class SMBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMB*Da*e*onXbm6*J*n*F*J*W*h*8s";

		var expected = new SMB_BeginningSegmentForRailroadStationMasterFile()
		{
			TransactionSetPurposeCode = "Da",
			StationTypeCode = "e",
			StandardPointLocationCode = "onXbm6",
			StationTypeCode2 = "J",
			StationTypeCode3 = "n",
			StationTypeCode4 = "F",
			YesNoConditionOrResponseCode = "J",
			Rule260JunctionCode = "W",
			StationTypeCode5 = "h",
			StatusCode = "8s",
		};

		var actual = Map.MapObject<SMB_BeginningSegmentForRailroadStationMasterFile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Da", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.StationTypeCode = "e";
		subject.StandardPointLocationCode = "onXbm6";
		subject.YesNoConditionOrResponseCode = "J";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredStationTypeCode(string stationTypeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "Da";
		subject.StandardPointLocationCode = "onXbm6";
		subject.YesNoConditionOrResponseCode = "J";
		//Test Parameters
		subject.StationTypeCode = stationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("onXbm6", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "Da";
		subject.StationTypeCode = "e";
		subject.YesNoConditionOrResponseCode = "J";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "Da";
		subject.StationTypeCode = "e";
		subject.StandardPointLocationCode = "onXbm6";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

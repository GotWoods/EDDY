using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SMBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMB*8c*C*FlZ96M*5*Z*b*n*X*9";

		var expected = new SMB_BeginningSegmentForRailroadStationMasterFile()
		{
			TransactionSetPurposeCode = "8c",
			StationTypeCode = "C",
			StandardPointLocationCode = "FlZ96M",
			StationTypeCode2 = "5",
			StationTypeCode3 = "Z",
			StationTypeCode4 = "b",
			YesNoConditionOrResponseCode = "n",
			Rule260JunctionCode = "X",
			StationTypeCode5 = "9",
		};

		var actual = Map.MapObject<SMB_BeginningSegmentForRailroadStationMasterFile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8c", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.StationTypeCode = "C";
		subject.YesNoConditionOrResponseCode = "n";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredStationTypeCode(string stationTypeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "8c";
		subject.YesNoConditionOrResponseCode = "n";
		//Test Parameters
		subject.StationTypeCode = stationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "8c";
		subject.StationTypeCode = "C";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

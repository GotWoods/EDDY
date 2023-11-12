using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SMBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMB*kq*RZtAhT*y*XyEcDF*r*d*t*C*66*e*9";

		var expected = new SMB_BeginningSegmentForRailroadStationMasterFile()
		{
			TransactionSetPurposeCode = "kq",
			Date = "RZtAhT",
			StationTypeCode = "y",
			StandardPointLocationCode = "XyEcDF",
			StationTypeCode2 = "r",
			StationTypeCode3 = "d",
			StationTypeCode4 = "t",
			YesNoConditionOrResponseCode = "C",
			Century = 66,
			Rule260JunctionCode = "e",
			StationTypeCode5 = "9",
		};

		var actual = Map.MapObject<SMB_BeginningSegmentForRailroadStationMasterFile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kq", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.Date = "RZtAhT";
		subject.StationTypeCode = "y";
		subject.YesNoConditionOrResponseCode = "C";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RZtAhT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "kq";
		subject.StationTypeCode = "y";
		subject.YesNoConditionOrResponseCode = "C";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredStationTypeCode(string stationTypeCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "kq";
		subject.Date = "RZtAhT";
		subject.YesNoConditionOrResponseCode = "C";
		//Test Parameters
		subject.StationTypeCode = stationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SMB_BeginningSegmentForRailroadStationMasterFile();
		//Required fields
		subject.TransactionSetPurposeCode = "kq";
		subject.Date = "RZtAhT";
		subject.StationTypeCode = "y";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

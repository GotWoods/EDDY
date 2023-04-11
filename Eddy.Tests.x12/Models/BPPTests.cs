using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*SJ*8pQIHq3v*2R*i*3*s*wKcRqCyq*cL*m*b*KAS6gYxi*R*mm*y";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "SJ",
			Date = "8pQIHq3v",
			NetworkOrScheduleDataTypeCode = "2R",
			ContractNumber = "i",
			Description = "3",
			ReferenceIdentification = "s",
			Date2 = "wKcRqCyq",
			ReportTypeCode = "cL",
			ReferenceIdentification2 = "m",
			Description2 = "b",
			Date3 = "KAS6gYxi",
			ReferenceIdentification3 = "R",
			SecurityLevelCode = "mm",
			VersionIdentifier = "y",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SJ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		subject.Date = "8pQIHq3v";
		subject.NetworkOrScheduleDataTypeCode = "2R";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8pQIHq3v", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		subject.TransactionSetPurposeCode = "SJ";
		subject.NetworkOrScheduleDataTypeCode = "2R";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2R", true)]
	public void Validation_RequiredNetworkOrScheduleDataTypeCode(string networkOrScheduleDataTypeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		subject.TransactionSetPurposeCode = "SJ";
		subject.Date = "8pQIHq3v";
		subject.NetworkOrScheduleDataTypeCode = networkOrScheduleDataTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

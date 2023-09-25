using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*C4*jen0vcn8*2E*N*o*g*FaIdYxS7*jO*b*U*G8O1iol3*S*AX*4";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "C4",
			Date = "jen0vcn8",
			NetworkOrScheduleDataType = "2E",
			ContractNumber = "N",
			Description = "o",
			ReferenceIdentification = "g",
			Date2 = "FaIdYxS7",
			ReportTypeCode = "jO",
			ReferenceIdentification2 = "b",
			Description2 = "U",
			Date3 = "G8O1iol3",
			ReferenceIdentification3 = "S",
			SecurityLevelCode = "AX",
			VersionIdentifier = "4",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C4", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.Date = "jen0vcn8";
		subject.NetworkOrScheduleDataType = "2E";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jen0vcn8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "C4";
		subject.NetworkOrScheduleDataType = "2E";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2E", true)]
	public void Validation_RequiredNetworkOrScheduleDataType(string networkOrScheduleDataType, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "C4";
		subject.Date = "jen0vcn8";
		//Test Parameters
		subject.NetworkOrScheduleDataType = networkOrScheduleDataType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

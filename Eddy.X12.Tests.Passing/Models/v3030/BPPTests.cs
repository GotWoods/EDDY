using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*Bv*a2Bkm8*aL*P*9*z*UkO0BU*qV*l*E*zWP4FJ*D*Z2";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "Bv",
			Date = "a2Bkm8",
			NetworkOrScheduleDataType = "aL",
			ContractNumber = "P",
			FreeFormDescription = "9",
			ReferenceNumber = "z",
			Date2 = "UkO0BU",
			ReportTypeCode = "qV",
			ReferenceNumber2 = "l",
			FreeFormDescription2 = "E",
			Date3 = "zWP4FJ",
			ReferenceNumber3 = "D",
			SecurityLevelCode = "Z2",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bv", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.Date = "a2Bkm8";
		subject.NetworkOrScheduleDataType = "aL";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a2Bkm8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Bv";
		subject.NetworkOrScheduleDataType = "aL";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aL", true)]
	public void Validation_RequiredNetworkOrScheduleDataType(string networkOrScheduleDataType, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Bv";
		subject.Date = "a2Bkm8";
		//Test Parameters
		subject.NetworkOrScheduleDataType = networkOrScheduleDataType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

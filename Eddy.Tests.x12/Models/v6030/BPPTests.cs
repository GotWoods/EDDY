using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*Ky*nrdpJVXS*wH*Z*h*5*fV1SZsz7*bC*w*B*iPzETf0s*X*w4*c";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "Ky",
			Date = "nrdpJVXS",
			NetworkOrScheduleDataTypeCode = "wH",
			ContractNumber = "Z",
			Description = "h",
			ReferenceIdentification = "5",
			Date2 = "fV1SZsz7",
			ReportTypeCode = "bC",
			ReferenceIdentification2 = "w",
			Description2 = "B",
			Date3 = "iPzETf0s",
			ReferenceIdentification3 = "X",
			SecurityLevelCode = "w4",
			VersionIdentifier = "c",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ky", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.Date = "nrdpJVXS";
		subject.NetworkOrScheduleDataTypeCode = "wH";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nrdpJVXS", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Ky";
		subject.NetworkOrScheduleDataTypeCode = "wH";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wH", true)]
	public void Validation_RequiredNetworkOrScheduleDataTypeCode(string networkOrScheduleDataTypeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "Ky";
		subject.Date = "nrdpJVXS";
		//Test Parameters
		subject.NetworkOrScheduleDataTypeCode = networkOrScheduleDataTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

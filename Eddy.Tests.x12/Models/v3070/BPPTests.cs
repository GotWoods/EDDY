using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*NE*4Tbu7N*OE*0*0*I*emYNW6*3A*T*c*FPFD9Y*S*1A*R";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "NE",
			Date = "4Tbu7N",
			NetworkOrScheduleDataType = "OE",
			ContractNumber = "0",
			Description = "0",
			ReferenceIdentification = "I",
			Date2 = "emYNW6",
			ReportTypeCode = "3A",
			ReferenceIdentification2 = "T",
			Description2 = "c",
			Date3 = "FPFD9Y",
			ReferenceIdentification3 = "S",
			SecurityLevelCode = "1A",
			VersionIdentifier = "R",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NE", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.Date = "4Tbu7N";
		subject.NetworkOrScheduleDataType = "OE";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Tbu7N", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "NE";
		subject.NetworkOrScheduleDataType = "OE";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OE", true)]
	public void Validation_RequiredNetworkOrScheduleDataType(string networkOrScheduleDataType, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "NE";
		subject.Date = "4Tbu7N";
		//Test Parameters
		subject.NetworkOrScheduleDataType = networkOrScheduleDataType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

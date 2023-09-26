using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*nJ*fULRwIJY*RW*w*s*V*HIwENouz*0N*N*q*KUMf6nem*0*Ix*Q";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "nJ",
			Date = "fULRwIJY",
			NetworkOrScheduleDataType = "RW",
			ContractNumber = "w",
			Description = "s",
			ReferenceIdentification = "V",
			Date2 = "HIwENouz",
			ReportTypeCode = "0N",
			ReferenceIdentification2 = "N",
			Description2 = "q",
			Date3 = "KUMf6nem",
			ReferenceIdentification3 = "0",
			SecurityLevelCode = "Ix",
			VersionIdentifier = "Q",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nJ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.Date = "fULRwIJY";
		subject.NetworkOrScheduleDataType = "RW";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fULRwIJY", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "nJ";
		subject.NetworkOrScheduleDataType = "RW";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RW", true)]
	public void Validation_RequiredNetworkOrScheduleDataType(string networkOrScheduleDataType, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "nJ";
		subject.Date = "fULRwIJY";
		//Test Parameters
		subject.NetworkOrScheduleDataType = networkOrScheduleDataType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

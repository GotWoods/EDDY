using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BPPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPP*91*LvgjTVVF*ZL*M*5*r*8ZhuZF2v*tU*1*m*AGHIjaVy*u*SW*H";

		var expected = new BPP_BeginningSegmentForProjectScheduleReporting()
		{
			TransactionSetPurposeCode = "91",
			Date = "LvgjTVVF",
			NetworkOrScheduleDataType = "ZL",
			ContractNumber = "M",
			Description = "5",
			ReferenceIdentification = "r",
			Date2 = "8ZhuZF2v",
			ReportTypeCode = "tU",
			ReferenceIdentification2 = "1",
			Description2 = "m",
			Date3 = "AGHIjaVy",
			ReferenceIdentification3 = "u",
			SecurityLevelCode = "SW",
			VersionIdentifier = "H",
		};

		var actual = Map.MapObject<BPP_BeginningSegmentForProjectScheduleReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("91", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.Date = "LvgjTVVF";
		subject.NetworkOrScheduleDataType = "ZL";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LvgjTVVF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "91";
		subject.NetworkOrScheduleDataType = "ZL";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZL", true)]
	public void Validation_RequiredNetworkOrScheduleDataType(string networkOrScheduleDataType, bool isValidExpected)
	{
		var subject = new BPP_BeginningSegmentForProjectScheduleReporting();
		//Required fields
		subject.TransactionSetPurposeCode = "91";
		subject.Date = "LvgjTVVF";
		//Test Parameters
		subject.NetworkOrScheduleDataType = networkOrScheduleDataType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

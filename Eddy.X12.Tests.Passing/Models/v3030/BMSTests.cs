using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMS*QD*oFuM7h*de*7*2*7*1*yf*2G";

		var expected = new BMS_BeginningSegmentForMaterialSafetyDataSheet()
		{
			TransactionSetPurposeCode = "QD",
			Date = "oFuM7h",
			LanguageCode = "de",
			ReferenceNumber = "7",
			RevisionNumber = 2,
			ReferenceNumber2 = "7",
			RevisionNumber2 = 1,
			StateOrProvinceCode = "yf",
			CountryCode = "2G",
		};

		var actual = Map.MapObject<BMS_BeginningSegmentForMaterialSafetyDataSheet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QD", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		//Required fields
		subject.Date = "oFuM7h";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oFuM7h", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		//Required fields
		subject.TransactionSetPurposeCode = "QD";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

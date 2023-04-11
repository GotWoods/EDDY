using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMS*fd*ucbCvBkg*4U*I*H*8*T*Hz*rA";

		var expected = new BMS_BeginningSegmentForMaterialSafetyDataSheet()
		{
			TransactionSetPurposeCode = "fd",
			Date = "ucbCvBkg",
			LanguageCode = "4U",
			ReferenceIdentification = "I",
			RevisionValue = "H",
			ReferenceIdentification2 = "8",
			RevisionValue2 = "T",
			StateOrProvinceCode = "Hz",
			CountryCode = "rA",
		};

		var actual = Map.MapObject<BMS_BeginningSegmentForMaterialSafetyDataSheet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fd", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		subject.Date = "ucbCvBkg";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ucbCvBkg", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		subject.TransactionSetPurposeCode = "fd";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

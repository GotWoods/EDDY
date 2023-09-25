using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMS*4j*3G4PhFpt*5l*u*j*S*U*Ii*Q3";

		var expected = new BMS_BeginningSegmentForMaterialSafetyDataSheet()
		{
			TransactionSetPurposeCode = "4j",
			Date = "3G4PhFpt",
			LanguageCode = "5l",
			ReferenceIdentification = "u",
			RevisionValue = "j",
			ReferenceIdentification2 = "S",
			RevisionValue2 = "U",
			StateOrProvinceCode = "Ii",
			CountryCode = "Q3",
		};

		var actual = Map.MapObject<BMS_BeginningSegmentForMaterialSafetyDataSheet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4j", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		//Required fields
		subject.Date = "3G4PhFpt";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3G4PhFpt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		//Required fields
		subject.TransactionSetPurposeCode = "4j";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

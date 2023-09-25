using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMS*I9*HAuYfEIl*4V*H*W*l*y*WV*Gn";

		var expected = new BMS_BeginningSegmentForMaterialSafetyDataSheet()
		{
			TransactionSetPurposeCode = "I9",
			Date = "HAuYfEIl",
			LanguageCode = "4V",
			ReferenceIdentification = "H",
			RevisionValue = "W",
			ReferenceIdentification2 = "l",
			RevisionValue2 = "y",
			StateOrProvinceCode = "WV",
			CountryCode = "Gn",
		};

		var actual = Map.MapObject<BMS_BeginningSegmentForMaterialSafetyDataSheet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I9", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		//Required fields
		subject.Date = "HAuYfEIl";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HAuYfEIl", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMS_BeginningSegmentForMaterialSafetyDataSheet();
		//Required fields
		subject.TransactionSetPurposeCode = "I9";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

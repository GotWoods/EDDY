using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class EIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EIA*yW*X*c*6*3*k";

		var expected = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "yW",
			YesNoConditionOrResponseCode = "X",
			YesNoConditionOrResponseCode2 = "c",
			YesNoConditionOrResponseCode3 = "6",
			Count = 3,
			ReferenceIdentification = "k",
		};

		var actual = Map.MapObject<EIA_BeginningSegmentForEquipmentInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yW", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "6", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBCount(int count, string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		subject.TransactionSetPurposeCode = "yW";
		if (count > 0)
		subject.Count = count;
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

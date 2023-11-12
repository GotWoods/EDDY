using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class EIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EIA*Df*O*y*I*3*3";

		var expected = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "Df",
			YesNoConditionOrResponseCode = "O",
			YesNoConditionOrResponseCode2 = "y",
			YesNoConditionOrResponseCode3 = "I",
			Count = 3,
			ReferenceIdentification = "3",
		};

		var actual = Map.MapObject<EIA_BeginningSegmentForEquipmentInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Df", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		//Required fields
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "I", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "I", true)]
	public void Validation_ARequiresBCount(int count, string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "Df";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

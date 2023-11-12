using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class EIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EIA*4K*K*t*2*1*U";

		var expected = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "4K",
			YesNoConditionOrResponseCode = "K",
			YesNoConditionOrResponseCode2 = "t",
			YesNoConditionOrResponseCode3 = "2",
			Count = 1,
			ReferenceIdentification = "U",
		};

		var actual = Map.MapObject<EIA_BeginningSegmentForEquipmentInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4K", true)]
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
	[InlineData(1, "2", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "2", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode3(int count, string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "4K";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

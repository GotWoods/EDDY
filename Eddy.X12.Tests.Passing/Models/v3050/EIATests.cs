using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class EIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EIA*tS*V*H*G*2*Q*h";

		var expected = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "tS",
			YesNoConditionOrResponseCode = "V",
			YesNoConditionOrResponseCode2 = "H",
			YesNoConditionOrResponseCode3 = "G",
			Count = 2,
			QueryTypeCode = "Q",
			ReferenceNumber = "h",
		};

		var actual = Map.MapObject<EIA_BeginningSegmentForEquipmentInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tS", true)]
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
	[InlineData(2, "G", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "G", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode3(int count, string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "tS";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

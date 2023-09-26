using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class EIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EIA*Bp*b*h*v*5*B*y";

		var expected = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice()
		{
			TransactionSetPurposeCode = "Bp",
			YesNoConditionOrResponseCode = "b",
			YesNoConditionOrResponseCode2 = "h",
			YesNoConditionOrResponseCode3 = "v",
			Count = 5,
			QueryTypeCode = "B",
			ReferenceIdentification = "y",
		};

		var actual = Map.MapObject<EIA_BeginningSegmentForEquipmentInquiryOrAdvice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bp", true)]
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
	[InlineData(5, "v", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "v", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode3(int count, string yesNoConditionOrResponseCode3, bool isValidExpected)
	{
		var subject = new EIA_BeginningSegmentForEquipmentInquiryOrAdvice();
		//Required fields
		subject.TransactionSetPurposeCode = "Bp";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		subject.YesNoConditionOrResponseCode3 = yesNoConditionOrResponseCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

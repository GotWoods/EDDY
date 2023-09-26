using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BC*Ye*8f7Gn1PE*6B7P*z*c*8W*K";

		var expected = new BC_BeginningSegmentForContractCompletionStatus()
		{
			TransactionSetPurposeCode = "Ye",
			Date = "8f7Gn1PE",
			Time = "6B7P",
			ReferenceIdentification = "z",
			ReferenceIdentification2 = "c",
			TransactionTypeCode = "8W",
			ActionCode = "K",
		};

		var actual = Map.MapObject<BC_BeginningSegmentForContractCompletionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ye", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BC_BeginningSegmentForContractCompletionStatus();
		//Required fields
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

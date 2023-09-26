using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BC*jb*Al0x9u*QR98*a*k*wy*t";

		var expected = new BC_BeginningSegmentForContractCompletionStatus()
		{
			TransactionSetPurposeCode = "jb",
			Date = "Al0x9u",
			Time = "QR98",
			ReferenceNumber = "a",
			ReferenceNumber2 = "k",
			TransactionTypeCode = "wy",
			ActionCode = "t",
		};

		var actual = Map.MapObject<BC_BeginningSegmentForContractCompletionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jb", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BC_BeginningSegmentForContractCompletionStatus();
		//Required fields
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

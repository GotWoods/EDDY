using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BC*jR*bCuaiPqw*EMqm*O*M*78*f";

		var expected = new BC_BeginningSegmentForContractCompletionStatus()
		{
			TransactionSetPurposeCode = "jR",
			Date = "bCuaiPqw",
			Time = "EMqm",
			ReferenceIdentification = "O",
			ReferenceIdentification2 = "M",
			TransactionTypeCode = "78",
			ActionCode = "f",
		};

		var actual = Map.MapObject<BC_BeginningSegmentForContractCompletionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BC_BeginningSegmentForContractCompletionStatus();
		//Required fields
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

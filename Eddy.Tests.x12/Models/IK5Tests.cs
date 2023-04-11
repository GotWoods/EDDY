using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IK5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK5*l*O*u*L*A*5";

		var expected = new IK5_ImplementationTransactionSetResponseTrailer()
		{
			TransactionSetAcknowledgmentCode = "l",
			ImplementationTransactionSetSyntaxErrorCode = "O",
			ImplementationTransactionSetSyntaxErrorCode2 = "u",
			ImplementationTransactionSetSyntaxErrorCode3 = "L",
			ImplementationTransactionSetSyntaxErrorCode4 = "A",
			ImplementationTransactionSetSyntaxErrorCode5 = "5",
		};

		var actual = Map.MapObject<IK5_ImplementationTransactionSetResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new IK5_ImplementationTransactionSetResponseTrailer();
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

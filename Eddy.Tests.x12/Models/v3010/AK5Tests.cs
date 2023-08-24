using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AK5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK5*z*9*w*r*z*y";

		var expected = new AK5_TransactionSetResponseTrailer()
		{
			TransactionSetAcknowledgmentCode = "z",
			TransactionSetSyntaxErrorCode = "9",
			TransactionSetSyntaxErrorCode2 = "w",
			TransactionSetSyntaxErrorCode3 = "r",
			TransactionSetSyntaxErrorCode4 = "z",
			TransactionSetSyntaxErrorCode5 = "y",
		};

		var actual = Map.MapObject<AK5_TransactionSetResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new AK5_TransactionSetResponseTrailer();
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

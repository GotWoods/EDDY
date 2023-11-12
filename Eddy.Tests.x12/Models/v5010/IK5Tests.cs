using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class IK5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IK5*M*z*R*G*D*S";

		var expected = new IK5_ImplementationTransactionSetResponseTrailer()
		{
			TransactionSetAcknowledgmentCode = "M",
			ImplementationTransactionSetSyntaxErrorCode = "z",
			ImplementationTransactionSetSyntaxErrorCode2 = "R",
			ImplementationTransactionSetSyntaxErrorCode3 = "G",
			ImplementationTransactionSetSyntaxErrorCode4 = "D",
			ImplementationTransactionSetSyntaxErrorCode5 = "S",
		};

		var actual = Map.MapObject<IK5_ImplementationTransactionSetResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
	{
		var subject = new IK5_ImplementationTransactionSetResponseTrailer();
		//Required fields
		//Test Parameters
		subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

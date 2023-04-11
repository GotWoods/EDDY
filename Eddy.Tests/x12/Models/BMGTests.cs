using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BMGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMG*0P*k*Hp";

		var expected = new BMG_BeginningSegmentForTextMessage()
		{
			TransactionSetPurposeCode = "0P",
			Description = "k",
			TransactionTypeCode = "Hp",
		};

		var actual = Map.MapObject<BMG_BeginningSegmentForTextMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0P", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMG_BeginningSegmentForTextMessage();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

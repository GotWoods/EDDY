using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AK2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK2*3bh*XuM4";

		var expected = new AK2_TransactionSetResponseHeader()
		{
			TransactionSetIdentifierCode = "3bh",
			TransactionSetControlNumber = "XuM4",
		};

		var actual = Map.MapObject<AK2_TransactionSetResponseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3bh", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new AK2_TransactionSetResponseHeader();
		subject.TransactionSetControlNumber = "XuM4";
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XuM4", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new AK2_TransactionSetResponseHeader();
		subject.TransactionSetIdentifierCode = "3bh";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

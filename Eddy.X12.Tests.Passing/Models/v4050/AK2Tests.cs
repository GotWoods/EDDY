using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class AK2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK2*NIC*4cFJ*j";

		var expected = new AK2_TransactionSetResponseHeader()
		{
			TransactionSetIdentifierCode = "NIC",
			TransactionSetControlNumber = "4cFJ",
			ImplementationConventionReference = "j",
		};

		var actual = Map.MapObject<AK2_TransactionSetResponseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NIC", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new AK2_TransactionSetResponseHeader();
		subject.TransactionSetControlNumber = "4cFJ";
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4cFJ", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new AK2_TransactionSetResponseHeader();
		subject.TransactionSetIdentifierCode = "NIC";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

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
		string x12Line = "AK2*FpG*z2BZ*i";

		var expected = new AK2_TransactionSetResponseHeader()
		{
			TransactionSetIdentifierCode = "FpG",
			TransactionSetControlNumber = "z2BZ",
			ImplementationConventionReference = "i",
		};

		var actual = Map.MapObject<AK2_TransactionSetResponseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FpG", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new AK2_TransactionSetResponseHeader();
		subject.TransactionSetControlNumber = "z2BZ";
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z2BZ", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new AK2_TransactionSetResponseHeader();
		subject.TransactionSetIdentifierCode = "FpG";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

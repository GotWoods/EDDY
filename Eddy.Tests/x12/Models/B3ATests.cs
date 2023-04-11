using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B3ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B3A*m7*7";

		var expected = new B3A_InvoiceType()
		{
			TransactionTypeCode = "m7",
			NumberOfShipments = 7,
		};

		var actual = Map.MapObject<B3A_InvoiceType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m7", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new B3A_InvoiceType();
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

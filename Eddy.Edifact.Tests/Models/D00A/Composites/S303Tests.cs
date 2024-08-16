using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S303Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:i:d";

		var expected = new S303_TransactionReference()
		{
			TransactionControlReference = "l",
			InitiatorReferenceIdentification = "i",
			ControllingAgencyCoded = "d",
		};

		var actual = Map.MapComposite<S303_TransactionReference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTransactionControlReference(string transactionControlReference, bool isValidExpected)
	{
		var subject = new S303_TransactionReference();
		//Required fields
		//Test Parameters
		subject.TransactionControlReference = transactionControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

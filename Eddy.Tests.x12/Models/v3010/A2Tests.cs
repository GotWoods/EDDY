using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class A2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A2*Nm6D";

		var expected = new A2_AcceptanceDetail()
		{
			TransactionSetControlNumber = "Nm6D",
		};

		var actual = Map.MapObject<A2_AcceptanceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nm6D", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new A2_AcceptanceDetail();
		subject.TransactionSetControlNumber = "Nm6D";
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

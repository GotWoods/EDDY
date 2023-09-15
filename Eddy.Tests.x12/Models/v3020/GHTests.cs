using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class GHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GH*lC*1cB7yL*C9nzVK*b0*9";

		var expected = new GH_GroupHeader()
		{
			TransactionSetPurposeCode = "lC",
			Date = "1cB7yL",
			ExpirationDate = "C9nzVK",
			GroupTitle = "b0",
			NumberOfLineItems = 9,
		};

		var actual = Map.MapObject<GH_GroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lC", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new GH_GroupHeader();
		subject.Date = "1cB7yL";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1cB7yL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GH_GroupHeader();
		subject.TransactionSetPurposeCode = "lC";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

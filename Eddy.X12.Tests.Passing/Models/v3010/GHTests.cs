using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class GHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GH*0p*fjMVsF*bqz4iu*QI*7";

		var expected = new GH_GroupHeader()
		{
			TransactionSetPurposeCode = "0p",
			EffectiveDate = "fjMVsF",
			ExpirationDate = "bqz4iu",
			GroupTitle = "QI",
			NumberOfLineItems = 7,
		};

		var actual = Map.MapObject<GH_GroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0p", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new GH_GroupHeader();
		subject.EffectiveDate = "fjMVsF";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fjMVsF", true)]
	public void Validation_RequiredEffectiveDate(string effectiveDate, bool isValidExpected)
	{
		var subject = new GH_GroupHeader();
		subject.TransactionSetPurposeCode = "0p";
		subject.EffectiveDate = effectiveDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

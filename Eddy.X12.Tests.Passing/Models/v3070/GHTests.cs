using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class GHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GH*S0*IhPBP3*6*5*42";

		var expected = new GH_GroupHeader()
		{
			TransactionSetPurposeCode = "S0",
			Date = "IhPBP3",
			NumberOfLineItems = 6,
			RevisionNumber = 5,
			Century = 42,
		};

		var actual = Map.MapObject<GH_GroupHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S0", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new GH_GroupHeader();
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(42, "IhPBP3", true)]
	[InlineData(42, "", false)]
	[InlineData(0, "IhPBP3", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new GH_GroupHeader();
		subject.TransactionSetPurposeCode = "S0";
		if (century > 0)
			subject.Century = century;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

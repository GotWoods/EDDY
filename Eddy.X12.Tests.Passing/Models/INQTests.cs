using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INQ*9*we";

		var expected = new INQ_CreditInquiryDetails()
		{
			ResultsCode = "9",
			TypeOfAccountCode = "we",
		};

		var actual = Map.MapObject<INQ_CreditInquiryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredResultsCode(string resultsCode, bool isValidExpected)
	{
		var subject = new INQ_CreditInquiryDetails();
		subject.ResultsCode = resultsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

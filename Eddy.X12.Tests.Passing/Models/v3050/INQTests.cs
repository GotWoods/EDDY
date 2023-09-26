using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class INQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INQ*a*l4";

		var expected = new INQ_CreditInquiryDetails()
		{
			ResultsCode = "a",
			TypeOfAccountCode = "l4",
		};

		var actual = Map.MapObject<INQ_CreditInquiryDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredResultsCode(string resultsCode, bool isValidExpected)
	{
		var subject = new INQ_CreditInquiryDetails();
		//Required fields
		//Test Parameters
		subject.ResultsCode = resultsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

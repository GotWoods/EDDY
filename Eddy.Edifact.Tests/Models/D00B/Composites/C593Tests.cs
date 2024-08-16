using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C593Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:o:K:q:g:q:K";

		var expected = new C593_AccountIdentification()
		{
			AccountIdentifier = "o",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "K",
			AccountAbbreviatedName = "q",
			AccountName = "g",
			AccountName2 = "q",
			CurrencyIdentificationCode = "K",
		};

		var actual = Map.MapComposite<C593_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredAccountIdentifier(string accountIdentifier, bool isValidExpected)
	{
		var subject = new C593_AccountIdentification();
		//Required fields
		//Test Parameters
		subject.AccountIdentifier = accountIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

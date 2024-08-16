using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C593Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:t:y:e:I:H:n";

		var expected = new C593_AccountIdentification()
		{
			AccountIdentifier = "W",
			CodeListIdentificationCode = "t",
			CodeListResponsibleAgencyCode = "y",
			AccountAbbreviatedName = "e",
			AccountName = "I",
			AccountName2 = "H",
			CurrencyIdentificationCode = "n",
		};

		var actual = Map.MapComposite<C593_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredAccountIdentifier(string accountIdentifier, bool isValidExpected)
	{
		var subject = new C593_AccountIdentification();
		//Required fields
		//Test Parameters
		subject.AccountIdentifier = accountIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

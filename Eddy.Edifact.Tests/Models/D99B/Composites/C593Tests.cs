using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C593Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:0:y:I:s:T:j";

		var expected = new C593_AccountIdentification()
		{
			AccountIdentification = "s",
			CodeListIdentificationCode = "0",
			CodeListResponsibleAgencyCode = "y",
			AccountAbbreviatedName = "I",
			AccountName = "s",
			AccountName2 = "T",
			CurrencyIdentificationCode = "j",
		};

		var actual = Map.MapComposite<C593_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAccountIdentification(string accountIdentification, bool isValidExpected)
	{
		var subject = new C593_AccountIdentification();
		//Required fields
		//Test Parameters
		subject.AccountIdentification = accountIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

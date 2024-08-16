using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class C593Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:0:i:J:Z:b:L";

		var expected = new C593_AccountIdentification()
		{
			AccountIdentification = "i",
			CodeListQualifier = "0",
			CodeListResponsibleAgencyCoded = "i",
			AccountAbbreviatedName = "J",
			AccountName = "Z",
			AccountName2 = "b",
			CurrencyCoded = "L",
		};

		var actual = Map.MapComposite<C593_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAccountIdentification(string accountIdentification, bool isValidExpected)
	{
		var subject = new C593_AccountIdentification();
		//Required fields
		//Test Parameters
		subject.AccountIdentification = accountIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E985Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:y:Q:v:D";

		var expected = new E985_TravellerSurnameAndRelatedInformation()
		{
			Surname = "6",
			PartyFunctionCodeQualifier = "y",
			Quantity = "Q",
			StatusDescriptionCode = "v",
			LanguageNameCode = "D",
		};

		var actual = Map.MapComposite<E985_TravellerSurnameAndRelatedInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredSurname(string surname, bool isValidExpected)
	{
		var subject = new E985_TravellerSurnameAndRelatedInformation();
		//Required fields
		//Test Parameters
		subject.Surname = surname;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

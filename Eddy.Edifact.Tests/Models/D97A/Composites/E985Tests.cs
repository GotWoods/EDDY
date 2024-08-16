using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E985Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:0:0:H:H";

		var expected = new E985_TravellerSurnameAndRelatedInformation()
		{
			Surname = "N",
			PartyQualifier = "0",
			Quantity = "0",
			StatusCoded = "H",
			LanguageCoded = "H",
		};

		var actual = Map.MapComposite<E985_TravellerSurnameAndRelatedInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredSurname(string surname, bool isValidExpected)
	{
		var subject = new E985_TravellerSurnameAndRelatedInformation();
		//Required fields
		//Test Parameters
		subject.Surname = surname;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

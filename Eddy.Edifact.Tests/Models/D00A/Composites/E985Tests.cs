using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E985Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "b:U:a:2:t";

		var expected = new E985_TravellerSurnameAndRelatedInformation()
		{
			FamilyName = "b",
			PartyFunctionCodeQualifier = "U",
			Quantity = "a",
			StatusDescriptionCode = "2",
			LanguageNameCode = "t",
		};

		var actual = Map.MapComposite<E985_TravellerSurnameAndRelatedInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredFamilyName(string familyName, bool isValidExpected)
	{
		var subject = new E985_TravellerSurnameAndRelatedInformation();
		//Required fields
		//Test Parameters
		subject.FamilyName = familyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

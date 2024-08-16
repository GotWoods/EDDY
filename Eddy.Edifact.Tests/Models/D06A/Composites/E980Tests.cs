using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:G:6:F:q:F:A:3";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeCode = "D",
			StatusDescriptionCode = "G",
			Quantity = "6",
			PartyName = "F",
			ProcessingIndicatorDescriptionCode = "q",
			LocationIdentifier = "F",
			LocationIdentifier2 = "A",
			CharacteristicDescriptionCode = "3",
		};

		var actual = Map.MapComposite<E980_SpecialRequirementTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredSpecialRequirementTypeCode(string specialRequirementTypeCode, bool isValidExpected)
	{
		var subject = new E980_SpecialRequirementTypeDetails();
		//Required fields
		//Test Parameters
		subject.SpecialRequirementTypeCode = specialRequirementTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

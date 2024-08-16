using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:D:r:Z:f:n:L:X";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeCode = "D",
			StatusDescriptionCode = "D",
			Quantity = "r",
			PartyName = "Z",
			ProcessingIndicatorDescriptionCode = "f",
			LocationIdentifier = "n",
			LocationIdentifier2 = "L",
			CharacteristicDescriptionCode = "X",
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

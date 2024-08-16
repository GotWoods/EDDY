using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:F:6:v:O:p:W:q";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeCode = "D",
			StatusDescriptionCode = "F",
			Quantity = "6",
			PartyName = "v",
			ProcessingIndicatorDescriptionCode = "O",
			LocationNameCode = "p",
			LocationNameCode2 = "W",
			CharacteristicDescriptionCode = "q",
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

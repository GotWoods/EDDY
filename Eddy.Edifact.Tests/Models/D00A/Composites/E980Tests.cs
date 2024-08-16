using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:b:3:b:n:g:1:h";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeCode = "J",
			StatusDescriptionCode = "b",
			Quantity = "3",
			PartyName = "b",
			ProcessingIndicatorDescriptionCode = "n",
			LocationNameCode = "g",
			LocationNameCode2 = "1",
			CharacteristicDescriptionCode = "h",
		};

		var actual = Map.MapComposite<E980_SpecialRequirementTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredSpecialRequirementTypeCode(string specialRequirementTypeCode, bool isValidExpected)
	{
		var subject = new E980_SpecialRequirementTypeDetails();
		//Required fields
		//Test Parameters
		subject.SpecialRequirementTypeCode = specialRequirementTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

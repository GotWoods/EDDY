using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:w:C:l:l:5:p:l";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeIdentification = "E",
			StatusDescriptionCode = "w",
			Quantity = "C",
			PartyName = "l",
			ProcessingIndicatorDescriptionCode = "l",
			LocationNameCode = "5",
			LocationNameCode2 = "p",
			CharacteristicDescriptionCode = "l",
		};

		var actual = Map.MapComposite<E980_SpecialRequirementTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredSpecialRequirementTypeIdentification(string specialRequirementTypeIdentification, bool isValidExpected)
	{
		var subject = new E980_SpecialRequirementTypeDetails();
		//Required fields
		//Test Parameters
		subject.SpecialRequirementTypeIdentification = specialRequirementTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

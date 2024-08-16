using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:t:N:b:P:y:Z:m";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeIdentification = "l",
			StatusCoded = "t",
			Quantity = "N",
			PartyName = "b",
			ProcessingIndicatorCoded = "P",
			PlaceLocationIdentification = "y",
			PlaceLocationIdentification2 = "Z",
			CharacteristicIdentification = "m",
		};

		var actual = Map.MapComposite<E980_SpecialRequirementTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredSpecialRequirementTypeIdentification(string specialRequirementTypeIdentification, bool isValidExpected)
	{
		var subject = new E980_SpecialRequirementTypeDetails();
		//Required fields
		//Test Parameters
		subject.SpecialRequirementTypeIdentification = specialRequirementTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E980Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:3:F:j:Q:c:T";

		var expected = new E980_SpecialRequirementTypeDetails()
		{
			SpecialRequirementTypeIdentification = "H",
			StatusCoded = "3",
			Quantity = "F",
			PartyName = "j",
			ProcessingIndicatorCoded = "Q",
			PlaceLocationIdentification = "c",
			PlaceLocationIdentification2 = "T",
		};

		var actual = Map.MapComposite<E980_SpecialRequirementTypeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredSpecialRequirementTypeIdentification(string specialRequirementTypeIdentification, bool isValidExpected)
	{
		var subject = new E980_SpecialRequirementTypeDetails();
		//Required fields
		//Test Parameters
		subject.SpecialRequirementTypeIdentification = specialRequirementTypeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

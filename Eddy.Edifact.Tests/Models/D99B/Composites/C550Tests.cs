using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C550Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:W:o:9";

		var expected = new C550_RequirementConditionIdentification()
		{
			RequirementOrConditionDescriptionIdentifier = "t",
			CodeListIdentificationCode = "W",
			CodeListResponsibleAgencyCode = "o",
			RequirementOrConditionDescription = "9",
		};

		var actual = Map.MapComposite<C550_RequirementConditionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredRequirementOrConditionDescriptionIdentifier(string requirementOrConditionDescriptionIdentifier, bool isValidExpected)
	{
		var subject = new C550_RequirementConditionIdentification();
		//Required fields
		//Test Parameters
		subject.RequirementOrConditionDescriptionIdentifier = requirementOrConditionDescriptionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

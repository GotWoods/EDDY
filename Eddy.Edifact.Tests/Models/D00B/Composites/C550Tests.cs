using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C550Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:W:7:Y";

		var expected = new C550_RequirementConditionIdentification()
		{
			RequirementOrConditionDescriptionIdentifier = "5",
			CodeListIdentificationCode = "W",
			CodeListResponsibleAgencyCode = "7",
			RequirementOrConditionDescription = "Y",
		};

		var actual = Map.MapComposite<C550_RequirementConditionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredRequirementOrConditionDescriptionIdentifier(string requirementOrConditionDescriptionIdentifier, bool isValidExpected)
	{
		var subject = new C550_RequirementConditionIdentification();
		//Required fields
		//Test Parameters
		subject.RequirementOrConditionDescriptionIdentifier = requirementOrConditionDescriptionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C550Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:K:s:S";

		var expected = new C550_RequirementConditionIdentification()
		{
			RequirementConditionIdentification = "9",
			CodeListQualifier = "K",
			CodeListResponsibleAgencyCoded = "s",
			RequirementOrCondition = "S",
		};

		var actual = Map.MapComposite<C550_RequirementConditionIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredRequirementConditionIdentification(string requirementConditionIdentification, bool isValidExpected)
	{
		var subject = new C550_RequirementConditionIdentification();
		//Required fields
		//Test Parameters
		subject.RequirementConditionIdentification = requirementConditionIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

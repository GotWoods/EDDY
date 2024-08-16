using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class RCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RCS+a++j+a";

		var expected = new RCS_RequirementsAndConditions()
		{
			SectorAreaIdentificationCodeQualifier = "a",
			RequirementConditionIdentification = null,
			ActionCode = "j",
			CountryIdentifier = "a",
		};

		var actual = Map.MapObject<RCS_RequirementsAndConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredSectorAreaIdentificationCodeQualifier(string sectorAreaIdentificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RCS_RequirementsAndConditions();
		//Required fields
		//Test Parameters
		subject.SectorAreaIdentificationCodeQualifier = sectorAreaIdentificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

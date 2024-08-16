using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class RCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RCS+V++E";

		var expected = new RCS_RequirementsAndConditions()
		{
			SectorSubjectIdentificationQualifier = "V",
			RequirementConditionIdentification = null,
			ActionRequestNotificationCoded = "E",
		};

		var actual = Map.MapObject<RCS_RequirementsAndConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredSectorSubjectIdentificationQualifier(string sectorSubjectIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RCS_RequirementsAndConditions();
		//Required fields
		//Test Parameters
		subject.SectorSubjectIdentificationQualifier = sectorSubjectIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

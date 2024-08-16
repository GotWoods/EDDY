using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class RCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RCS+A++E+W";

		var expected = new RCS_RequirementsAndConditions()
		{
			SectorAreaIdentificationCodeQualifier = "A",
			RequirementConditionIdentification = null,
			ActionRequestNotificationDescriptionCode = "E",
			CountryNameCode = "W",
		};

		var actual = Map.MapObject<RCS_RequirementsAndConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSectorAreaIdentificationCodeQualifier(string sectorAreaIdentificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RCS_RequirementsAndConditions();
		//Required fields
		//Test Parameters
		subject.SectorAreaIdentificationCodeQualifier = sectorAreaIdentificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

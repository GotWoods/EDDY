using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class SPRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SPR+n+6+";

		var expected = new SPR_OrganisationClassificationDetails()
		{
			SectorSubjectIdentificationQualifier = "n",
			OrganisationClassificationCoded = "6",
			OrganisationClassificationDetail = null,
		};

		var actual = Map.MapObject<SPR_OrganisationClassificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredSectorSubjectIdentificationQualifier(string sectorSubjectIdentificationQualifier, bool isValidExpected)
	{
		var subject = new SPR_OrganisationClassificationDetails();
		//Required fields
		//Test Parameters
		subject.SectorSubjectIdentificationQualifier = sectorSubjectIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

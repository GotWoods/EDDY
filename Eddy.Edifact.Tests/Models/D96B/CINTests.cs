using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class CINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CIN+j++";

		var expected = new CIN_ClinicalInformation()
		{
			ClinicalInformationQualifier = "j",
			ClinicalInformationDetails = null,
			CertaintyDetails = null,
		};

		var actual = Map.MapObject<CIN_ClinicalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredClinicalInformationQualifier(string clinicalInformationQualifier, bool isValidExpected)
	{
		var subject = new CIN_ClinicalInformation();
		//Required fields
		//Test Parameters
		subject.ClinicalInformationQualifier = clinicalInformationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CIN+g++";

		var expected = new CIN_ClinicalInformation()
		{
			ClinicalInformationTypeCodeQualifier = "g",
			ClinicalInformationDetails = null,
			CertaintyDetails = null,
		};

		var actual = Map.MapObject<CIN_ClinicalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredClinicalInformationTypeCodeQualifier(string clinicalInformationTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new CIN_ClinicalInformation();
		//Required fields
		//Test Parameters
		subject.ClinicalInformationTypeCodeQualifier = clinicalInformationTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

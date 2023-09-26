using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class HPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HPL*kd*z*o7*ah*B*0";

		var expected = new HPL_HealthCareProviderLicense()
		{
			ReferenceIdentificationQualifier = "kd",
			ReferenceIdentification = "z",
			StatusCode = "o7",
			StateOrProvinceCode = "ah",
			Description = "B",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "0",
		};

		var actual = Map.MapObject<HPL_HealthCareProviderLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kd", "z", true)]
	[InlineData("kd", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "0";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("z", "0", true)]
	[InlineData("z", "", true)]
	[InlineData("", "0", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string codeForLicensingCertificationRegistrationOrAccreditationAgency, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = codeForLicensingCertificationRegistrationOrAccreditationAgency;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kd";
			subject.ReferenceIdentification = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

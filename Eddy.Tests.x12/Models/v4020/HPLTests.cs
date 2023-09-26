using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class HPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HPL*vC*G*jQ*Sr*j*7";

		var expected = new HPL_HealthCareProviderLicense()
		{
			ReferenceIdentificationQualifier = "vC",
			ReferenceIdentification = "G",
			StatusCode = "jQ",
			StateOrProvinceCode = "Sr",
			Description = "j",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "7",
		};

		var actual = Map.MapObject<HPL_HealthCareProviderLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vC", "G", true)]
	[InlineData("vC", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "7";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("G", "7", true)]
	[InlineData("G", "", true)]
	[InlineData("", "7", true)]
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
			subject.ReferenceIdentificationQualifier = "vC";
			subject.ReferenceIdentification = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

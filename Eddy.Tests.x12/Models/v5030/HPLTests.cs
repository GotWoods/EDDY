using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class HPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HPL*gX*v*YM*qm*p*y";

		var expected = new HPL_HealthCareProviderLicense()
		{
			ReferenceIdentificationQualifier = "gX",
			ReferenceIdentification = "v",
			StatusCode = "YM",
			StateOrProvinceCode = "qm",
			Description = "p",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "y",
		};

		var actual = Map.MapObject<HPL_HealthCareProviderLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gX", "v", true)]
	[InlineData("gX", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("v", "y", true)]
	[InlineData("v", "", true)]
	[InlineData("", "y", true)]
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
			subject.ReferenceIdentificationQualifier = "gX";
			subject.ReferenceIdentification = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

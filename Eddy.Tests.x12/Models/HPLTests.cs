using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HPL*Ho*D*FF*XC*T*T";

		var expected = new HPL_HealthCareProviderLicense()
		{
			ReferenceIdentificationQualifier = "Ho",
			ReferenceIdentification = "D",
			StatusCode = "FF",
			StateOrProvinceCode = "XC",
			Description = "T",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "T",
		};

		var actual = Map.MapObject<HPL_HealthCareProviderLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ho", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("Ho", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		if (referenceIdentification == "")
			subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "AA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("D","T", true)]
	[InlineData("", "T", true)]
	[InlineData("D", "", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string codeForLicensingCertificationRegistrationOrAccreditationAgency, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		subject.ReferenceIdentification = referenceIdentification;
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = codeForLicensingCertificationRegistrationOrAccreditationAgency;

		if (referenceIdentification != "")
			subject.ReferenceIdentificationQualifier = "AA";

        // if (referenceIdentification == "")
        //     subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

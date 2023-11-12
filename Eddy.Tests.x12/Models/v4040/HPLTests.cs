using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class HPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HPL*Dv*t*ya*ff*m*A";

		var expected = new HPL_HealthCareProviderLicense()
		{
			ReferenceIdentificationQualifier = "Dv",
			ReferenceIdentification = "t",
			StatusCode = "ya",
			StateOrProvinceCode = "ff",
			Description = "m",
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "A",
		};

		var actual = Map.MapObject<HPL_HealthCareProviderLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dv", "t", true)]
	[InlineData("Dv", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new HPL_HealthCareProviderLicense();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.CodeForLicensingCertificationRegistrationOrAccreditationAgency = "A";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("t", "A", true)]
	[InlineData("t", "", true)]
	[InlineData("", "A", true)]
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
			subject.ReferenceIdentificationQualifier = "Dv";
			subject.ReferenceIdentification = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

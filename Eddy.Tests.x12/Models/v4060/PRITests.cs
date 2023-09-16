using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*r5*1*O*h*O*Q*E*Mo*p*jF*9*V*9*t3";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			PrimaryPublicationAuthorityCode = "r5",
			TariffAgencyCode = "1",
			TariffNumber = "O",
			TariffNumberSuffix = "h",
			TariffSupplementIdentifier = "O",
			TariffSectionNumber = "Q",
			TariffItemNumber = "E",
			ReferenceIdentificationQualifier = "Mo",
			ReferenceIdentification = "p",
			StandardCarrierAlphaCode = "jF",
			DocketControlNumber = "9",
			DocketIdentification = "V",
			RevisionNumber = 9,
			GroupTitle = "t3",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r5", true)]
	public void Validation_RequiredPrimaryPublicationAuthorityCode(string primaryPublicationAuthorityCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "1";
		subject.TariffNumber = "O";
		subject.PrimaryPublicationAuthorityCode = primaryPublicationAuthorityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Mo";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "r5";
		subject.TariffNumber = "O";
		subject.TariffAgencyCode = tariffAgencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Mo";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "r5";
		subject.TariffAgencyCode = "1";
		subject.TariffNumber = tariffNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Mo";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Mo", "p", true)]
	[InlineData("Mo", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "r5";
		subject.TariffAgencyCode = "1";
		subject.TariffNumber = "O";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

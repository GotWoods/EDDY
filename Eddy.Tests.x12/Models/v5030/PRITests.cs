using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*Tq*5*e*s*C*P*x*Kn*R*iD*q*V*6*PM";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			PrimaryPublicationAuthorityCode = "Tq",
			TariffAgencyCode = "5",
			TariffNumber = "e",
			TariffNumberSuffix = "s",
			TariffSupplementIdentifier = "C",
			TariffSectionNumber = "P",
			TariffItemNumber = "x",
			ReferenceIdentificationQualifier = "Kn",
			ReferenceIdentification = "R",
			StandardCarrierAlphaCode = "iD",
			DocketControlNumber = "q",
			DocketIdentification = "V",
			RevisionNumber = 6,
			GroupTitle = "PM",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tq", true)]
	public void Validation_RequiredPrimaryPublicationAuthorityCode(string primaryPublicationAuthorityCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "5";
		subject.TariffNumber = "e";
		subject.PrimaryPublicationAuthorityCode = primaryPublicationAuthorityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Kn";
			subject.ReferenceIdentification = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "Tq";
		subject.TariffNumber = "e";
		subject.TariffAgencyCode = tariffAgencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Kn";
			subject.ReferenceIdentification = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "Tq";
		subject.TariffAgencyCode = "5";
		subject.TariffNumber = tariffNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Kn";
			subject.ReferenceIdentification = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kn", "R", true)]
	[InlineData("Kn", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "Tq";
		subject.TariffAgencyCode = "5";
		subject.TariffNumber = "e";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

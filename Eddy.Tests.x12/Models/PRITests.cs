using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*rs*2*M*s*4*N*P*pk*k*JZ*o*Z*7*pj";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			PrimaryPublicationAuthorityCode = "rs",
			TariffAgencyCode = "2",
			TariffNumber = "M",
			TariffNumberSuffix = "s",
			TariffSupplementIdentifier = "4",
			TariffSectionNumber = "N",
			TariffItemNumber = "P",
			ReferenceIdentificationQualifier = "pk",
			ReferenceIdentification = "k",
			StandardCarrierAlphaCode = "JZ",
			DocketControlNumber = "o",
			DocketIdentification = "Z",
			RevisionNumber = 7,
			GroupTitle = "pj",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rs", true)]
	public void Validation_RequiredPrimaryPublicationAuthorityCode(string primaryPublicationAuthorityCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "2";
		subject.TariffNumber = "M";
		subject.PrimaryPublicationAuthorityCode = primaryPublicationAuthorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "rs";
		subject.TariffNumber = "M";
		subject.TariffAgencyCode = tariffAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "rs";
		subject.TariffAgencyCode = "2";
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("pk", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("pk", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "rs";
		subject.TariffAgencyCode = "2";
		subject.TariffNumber = "M";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*tr*F*X*1*y*g*k*iG*f*Nq*2*p*5*i1";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			PrimaryPublicationAuthorityCode = "tr",
			TariffAgencyCode = "F",
			TariffNumber = "X",
			TariffNumberSuffix = "1",
			TariffSupplementIdentifier = "y",
			TariffSection = "g",
			TariffItemNumber = "k",
			ReferenceIdentificationQualifier = "iG",
			ReferenceIdentification = "f",
			StandardCarrierAlphaCode = "Nq",
			DocketControlNumber = "2",
			DocketIdentification = "p",
			RevisionNumber = 5,
			GroupTitle = "i1",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tr", true)]
	public void Validation_RequiredPrimaryPublicationAuthorityCode(string primaryPublicationAuthorityCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "F";
		subject.TariffNumber = "X";
		subject.PrimaryPublicationAuthorityCode = primaryPublicationAuthorityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "iG";
			subject.ReferenceIdentification = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "tr";
		subject.TariffNumber = "X";
		subject.TariffAgencyCode = tariffAgencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "iG";
			subject.ReferenceIdentification = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "tr";
		subject.TariffAgencyCode = "F";
		subject.TariffNumber = tariffNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "iG";
			subject.ReferenceIdentification = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iG", "f", true)]
	[InlineData("iG", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "tr";
		subject.TariffAgencyCode = "F";
		subject.TariffNumber = "X";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*G4*I*R*2*P*8*m*mA*W*XP*D*m*2*v8";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			PrimaryPublicationAuthorityCode = "G4",
			TariffAgencyCode = "I",
			TariffNumber = "R",
			TariffNumberSuffix = "2",
			TariffSupplementIdentifier = "P",
			TariffSection = "8",
			TariffItemNumber = "m",
			ReferenceIdentificationQualifier = "mA",
			ReferenceIdentification = "W",
			StandardCarrierAlphaCode = "XP",
			DocketControlNumber = "D",
			DocketIdentification = "m",
			RevisionNumber = 2,
			GroupTitle = "v8",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G4", true)]
	public void Validation_RequiredPrimaryPublicationAuthorityCode(string primaryPublicationAuthorityCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "I";
		subject.TariffNumber = "R";
		subject.PrimaryPublicationAuthorityCode = primaryPublicationAuthorityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "mA";
			subject.ReferenceIdentification = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "G4";
		subject.TariffNumber = "R";
		subject.TariffAgencyCode = tariffAgencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "mA";
			subject.ReferenceIdentification = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "G4";
		subject.TariffAgencyCode = "I";
		subject.TariffNumber = tariffNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "mA";
			subject.ReferenceIdentification = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mA", "W", true)]
	[InlineData("mA", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.PrimaryPublicationAuthorityCode = "G4";
		subject.TariffAgencyCode = "I";
		subject.TariffNumber = "R";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

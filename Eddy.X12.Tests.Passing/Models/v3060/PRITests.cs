using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*jo*z*7*2*G*9*f*MY*q*xA*j*I*9*z7";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			ReferenceUsageCode = "jo",
			TariffAgencyCode = "z",
			TariffNumber = "7",
			TariffNumberSuffix = "2",
			TariffSupplementIdentifier = "G",
			TariffSection = "9",
			TariffItemNumber = "f",
			ReferenceIdentificationQualifier = "MY",
			ReferenceIdentification = "q",
			StandardCarrierAlphaCode = "xA",
			DocketControlNumber = "j",
			DocketIdentification = "I",
			RevisionNumber = 9,
			GroupTitle = "z7",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jo", true)]
	public void Validation_RequiredReferenceUsageCode(string referenceUsageCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "z";
		subject.TariffNumber = "7";
		subject.ReferenceUsageCode = referenceUsageCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "MY";
			subject.ReferenceIdentification = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "jo";
		subject.TariffNumber = "7";
		subject.TariffAgencyCode = tariffAgencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "MY";
			subject.ReferenceIdentification = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "jo";
		subject.TariffAgencyCode = "z";
		subject.TariffNumber = tariffNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "MY";
			subject.ReferenceIdentification = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MY", "q", true)]
	[InlineData("MY", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "jo";
		subject.TariffAgencyCode = "z";
		subject.TariffNumber = "7";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

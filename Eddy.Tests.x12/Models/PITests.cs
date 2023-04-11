using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*LX*2*vL*LQI*I*I*f*t*7*L*Z*aQushHPQ*KS0JCl6R*6*7*lx";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "LX",
			ReferenceIdentification = "2",
			PrimaryPublicationAuthorityCode = "vL",
			RegulatoryAgencyCode = "LQI",
			TariffAgencyCode = "I",
			IssuingCarrierIdentifier = "I",
			ContractSuffix = "f",
			TariffItemNumber = "t",
			TariffSupplementIdentifier = "7",
			TariffSectionNumber = "L",
			ContractSuffix2 = "Z",
			Date = "aQushHPQ",
			Date2 = "KS0JCl6R",
			AlternationPrecedenceCode = "6",
			AlternationPrecedenceCode2 = "7",
			ServiceLevelCode = "lx",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LX", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		subject.ReferenceIdentification = "2";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		subject.ReferenceIdentificationQualifier = "LX";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

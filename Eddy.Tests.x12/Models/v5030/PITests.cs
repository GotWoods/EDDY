using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*fW*X*CS*Nlr*N*j*W*A*p*n*e*oN8zei5h*0LD4B7fx*o*6*MQ";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "fW",
			ReferenceIdentification = "X",
			PrimaryPublicationAuthorityCode = "CS",
			RegulatoryAgencyCode = "Nlr",
			TariffAgencyCode = "N",
			IssuingCarrierIdentifier = "j",
			ContractSuffix = "W",
			TariffItemNumber = "A",
			TariffSupplementIdentifier = "p",
			TariffSectionNumber = "n",
			ContractSuffix2 = "e",
			Date = "oN8zei5h",
			Date2 = "0LD4B7fx",
			AlternationPrecedenceCode = "o",
			AlternationPrecedenceCode2 = "6",
			ServiceLevelCode = "MQ",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fW", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentification = "X";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "fW";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

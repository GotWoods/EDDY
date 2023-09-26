using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*bA*P*NQ*9v7*3*f*B*g*B*D*W*qzmUtu93*7qjPKOl5*z*H*Bu";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "bA",
			ReferenceIdentification = "P",
			PrimaryPublicationAuthorityCode = "NQ",
			RegulatoryAgencyCode = "9v7",
			TariffAgencyCode = "3",
			IssuingCarrierIdentifier = "f",
			ContractSuffix = "B",
			TariffItemNumber = "g",
			TariffSupplementIdentifier = "B",
			TariffSectionNumber = "D",
			ContractSuffix2 = "W",
			Date = "qzmUtu93",
			Date2 = "7qjPKOl5",
			AlternationPrecedenceCode = "z",
			AlternationPrecedenceCode2 = "H",
			ServiceLevelCode = "Bu",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bA", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentification = "P";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "bA";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

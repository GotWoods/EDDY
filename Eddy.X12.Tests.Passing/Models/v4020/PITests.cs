using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*2y*I*vl*XB4*K*3*J*e*n*b*4*kItS9zXj*5LTYkHi6*j*y";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "2y",
			ReferenceIdentification = "I",
			PrimaryPublicationAuthorityCode = "vl",
			RegulatoryAgencyCode = "XB4",
			TariffAgencyCode = "K",
			IssuingCarrierIdentifier = "3",
			ContractSuffix = "J",
			TariffItemNumber = "e",
			TariffSupplementIdentifier = "n",
			TariffSection = "b",
			ContractSuffix2 = "4",
			Date = "kItS9zXj",
			Date2 = "5LTYkHi6",
			AlternationPrecedenceCode = "j",
			AlternationPrecedenceCode2 = "y",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2y", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentification = "I";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "2y";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

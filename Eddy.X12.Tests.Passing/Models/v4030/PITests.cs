using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*6M*5*lQ*4NN*d*L*j*5*x*z*W*bZuUE2uV*09X0tHJF*2*K";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "6M",
			ReferenceIdentification = "5",
			PrimaryPublicationAuthorityCode = "lQ",
			RegulatoryAgencyCode = "4NN",
			TariffAgencyCode = "d",
			IssuingCarrierIdentifier = "L",
			ContractSuffix = "j",
			TariffItemNumber = "5",
			TariffSupplementIdentifier = "x",
			TariffSection = "z",
			ContractSuffix2 = "W",
			Date = "bZuUE2uV",
			Date2 = "09X0tHJF",
			AlternationPrecedenceCode = "2",
			AlternationPrecedenceCode2 = "K",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6M", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentification = "5";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "6M";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

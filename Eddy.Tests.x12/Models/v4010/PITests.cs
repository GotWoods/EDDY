using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*3U*q*LM*Sqe*Y*8*L*m*x*t*q*684KAEEg*IQrn5LDD*H*i";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "3U",
			ReferenceIdentification = "q",
			PrimaryPublicationAuthorityCode = "LM",
			RegulatoryAgencyCode = "Sqe",
			TariffAgencyCode = "Y",
			IssuingCarrierIdentifier = "8",
			ContractSuffix = "L",
			TariffItemNumber = "m",
			TariffSupplementIdentifier = "x",
			TariffSection = "t",
			ContractSuffix2 = "q",
			Date = "684KAEEg",
			Date2 = "IQrn5LDD",
			AlternationPrecedenceCode = "H",
			AlternationPrecedenceCode2 = "i",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3U", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "3U";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "684KAEEg", true)]
	[InlineData("H", "", false)]
	[InlineData("", "684KAEEg", true)]
	public void Validation_ARequiresBAlternationPrecedenceCode(string alternationPrecedenceCode, string date, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "3U";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.AlternationPrecedenceCode = alternationPrecedenceCode;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "IQrn5LDD", true)]
	[InlineData("i", "", false)]
	[InlineData("", "IQrn5LDD", true)]
	public void Validation_ARequiresBAlternationPrecedenceCode2(string alternationPrecedenceCode2, string date2, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "3U";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.AlternationPrecedenceCode2 = alternationPrecedenceCode2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PI*LZ*E*up*EzT*j*6*t*L*Y*B*B*2Tdrjq*U9ptck*3*D";

		var expected = new PI_PriceAuthorityIdentification()
		{
			ReferenceIdentificationQualifier = "LZ",
			ReferenceIdentification = "E",
			PrimaryPublicationAuthorityCode = "up",
			RegulatoryAgencyCode = "EzT",
			TariffAgencyCode = "j",
			IssuingCarrierIdentifier = "6",
			ContractSuffix = "t",
			TariffItemNumber = "L",
			TariffSupplementIdentifier = "Y",
			TariffSection = "B",
			ContractSuffix2 = "B",
			Date = "2Tdrjq",
			Date2 = "U9ptck",
			AlternationPrecedenceCode = "3",
			AlternationPrecedenceCode2 = "D",
		};

		var actual = Map.MapObject<PI_PriceAuthorityIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LZ", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "LZ";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "2Tdrjq", true)]
	[InlineData("3", "", false)]
	[InlineData("", "2Tdrjq", true)]
	public void Validation_ARequiresBAlternationPrecedenceCode(string alternationPrecedenceCode, string date, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "LZ";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.AlternationPrecedenceCode = alternationPrecedenceCode;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "U9ptck", true)]
	[InlineData("D", "", false)]
	[InlineData("", "U9ptck", true)]
	public void Validation_ARequiresBAlternationPrecedenceCode2(string alternationPrecedenceCode2, string date2, bool isValidExpected)
	{
		var subject = new PI_PriceAuthorityIdentification();
		//Required fields
		subject.ReferenceIdentificationQualifier = "LZ";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.AlternationPrecedenceCode2 = alternationPrecedenceCode2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

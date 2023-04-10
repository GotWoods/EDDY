using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CER*YE*d*5*I*N*MY*b2wU0jMc*c7Uo8xtV";

		var expected = new CER_Certification()
		{
			AgencyQualifierCode = "YE",
			NameLastOrOrganizationName = "d",
			Description = "5",
			ReferenceIdentification = "I",
			IdentificationCodeQualifier = "N",
			IdentificationCode = "MY",
			Date = "b2wU0jMc",
			Date2 = "c7Uo8xtV",
		};

		var actual = Map.MapObject<CER_Certification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("YE","d", true)]
	[InlineData("", "d", true)]
	[InlineData("YE", "", true)]
	public void Validation_AtLeastOneAgencyQualifierCode(string agencyQualifierCode, string nameLastOrOrganizationName, bool isValidExpected)
	{
		var subject = new CER_Certification();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.NameLastOrOrganizationName = nameLastOrOrganizationName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("N", "MY", true)]
	[InlineData("", "MY", false)]
	[InlineData("N", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CER_Certification();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		subject.NameLastOrOrganizationName = "ABCD";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

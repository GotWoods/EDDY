using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CI*5*PD*r*vT*S*2J*a*ADU*SMVKVu5S*x6G*p39S4svp*0*0a*o";

		var expected = new CI_CarrierInterchangeAgreement()
		{
			Name = "5",
			StandardCarrierAlphaCode = "PD",
			IdentificationCodeQualifier = "r",
			IdentificationCode = "vT",
			IdentificationCodeQualifier2 = "S",
			IdentificationCode2 = "2J",
			InterchangeAgreementStatusCode = "a",
			DateTimeQualifier = "ADU",
			Date = "SMVKVu5S",
			DateTimeQualifier2 = "x6G",
			Date2 = "p39S4svp",
			Name2 = "0",
			ReferenceIdentificationQualifier = "0a",
			ReferenceIdentification = "o",
		};

		var actual = Map.MapObject<CI_CarrierInterchangeAgreement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("r", "vT", true)]
	[InlineData("", "vT", false)]
	[InlineData("r", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CI_CarrierInterchangeAgreement();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S", "2J", true)]
	[InlineData("", "2J", false)]
	[InlineData("S", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier2(string identificationCodeQualifier2, string identificationCode2, bool isValidExpected)
	{
		var subject = new CI_CarrierInterchangeAgreement();
		subject.IdentificationCodeQualifier2 = identificationCodeQualifier2;
		subject.IdentificationCode2 = identificationCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ADU", "SMVKVu5S", true)]
	[InlineData("", "SMVKVu5S", false)]
	[InlineData("ADU", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new CI_CarrierInterchangeAgreement();
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("x6G", "p39S4svp", true)]
	[InlineData("", "p39S4svp", false)]
	[InlineData("x6G", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier2(string dateTimeQualifier2, string date2, bool isValidExpected)
	{
		var subject = new CI_CarrierInterchangeAgreement();
		subject.DateTimeQualifier2 = dateTimeQualifier2;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("0a", "o", true)]
	[InlineData("", "o", false)]
	[InlineData("0a", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CI_CarrierInterchangeAgreement();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CCI*pR*5*ZZ*f*9Z*3*C*F*5*h";

		var expected = new CCI_CreditCounselingInformation()
		{
			IdentificationCode = "pR",
			ReferenceIdentification = "5",
			ReferenceIdentificationQualifier = "ZZ",
			ReferenceIdentification2 = "f",
			DateTimePeriodFormatQualifier = "9Z",
			DateTimePeriod = "3",
			DateTimePeriod2 = "C",
			DateTimePeriod3 = "F",
			MonetaryAmount = 5,
			CounselingStatusCode = "h",
		};

		var actual = Map.MapObject<CCI_CreditCounselingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pR", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		subject.ReferenceIdentification = "5";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		subject.IdentificationCode = "pR";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ZZ", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("ZZ", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		subject.IdentificationCode = "pR";
		subject.ReferenceIdentification = "5";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9Z", "h", true)]
	[InlineData("", "h", false)]
	[InlineData("9Z", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string counselingStatusCode, bool isValidExpected)
	{
		var subject = new CCI_CreditCounselingInformation();
		subject.IdentificationCode = "pR";
		subject.ReferenceIdentification = "5";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.CounselingStatusCode = counselingStatusCode;

		if (dateTimePeriodFormatQualifier!= "")
		    subject.DateTimePeriod = "2020";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	//TODO: fix this test
	// [Theory]
	// [InlineData("","", true)]
	// [InlineData("9Z", "3", false)]
	// [InlineData("","3", true)]
	// [InlineData("9Z", "", true)]
	// public void Validation_NEWDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, string dateTimePeriod2, string dateTimePeriod3, bool isValidExpected)
	// {
	// 	var subject = new CCI_CreditCounselingInformation();
	// 	subject.IdentificationCode = "pR";
	// 	subject.ReferenceIdentification = "5";
	// 	subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
	// 	subject.DateTimePeriod = dateTimePeriod;
	// 	subject.DateTimePeriod2 = dateTimePeriod2;
	// 	subject.DateTimePeriod3 = dateTimePeriod3;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
	// }

}

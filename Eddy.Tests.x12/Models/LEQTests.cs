using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*Wx*6*6649*ar*Mq*A*8*vPLRKPX4*7264";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceIdentificationQualifier = "Wx",
			ReferenceIdentification = "6",
			Year = 6649,
			MonthOfTheYearCode = "ar",
			StandardCarrierAlphaCode = "Mq",
			ReferenceIdentification2 = "A",
			MonetaryAmount = 8,
			Date = "vPLRKPX4",
			ExchangeRate = 7264,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wx", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentification = "6";
		subject.Year = 6649;
		subject.MonthOfTheYearCode = "ar";
		subject.StandardCarrierAlphaCode = "Mq";
		subject.ReferenceIdentification2 = "A";
		subject.MonetaryAmount = 8;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentificationQualifier = "Wx";
		subject.Year = 6649;
		subject.MonthOfTheYearCode = "ar";
		subject.StandardCarrierAlphaCode = "Mq";
		subject.ReferenceIdentification2 = "A";
		subject.MonetaryAmount = 8;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6649, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentificationQualifier = "Wx";
		subject.ReferenceIdentification = "6";
		subject.MonthOfTheYearCode = "ar";
		subject.StandardCarrierAlphaCode = "Mq";
		subject.ReferenceIdentification2 = "A";
		subject.MonetaryAmount = 8;
		if (year > 0)
		subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ar", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentificationQualifier = "Wx";
		subject.ReferenceIdentification = "6";
		subject.Year = 6649;
		subject.StandardCarrierAlphaCode = "Mq";
		subject.ReferenceIdentification2 = "A";
		subject.MonetaryAmount = 8;
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mq", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentificationQualifier = "Wx";
		subject.ReferenceIdentification = "6";
		subject.Year = 6649;
		subject.MonthOfTheYearCode = "ar";
		subject.ReferenceIdentification2 = "A";
		subject.MonetaryAmount = 8;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentificationQualifier = "Wx";
		subject.ReferenceIdentification = "6";
		subject.Year = 6649;
		subject.MonthOfTheYearCode = "ar";
		subject.StandardCarrierAlphaCode = "Mq";
		subject.MonetaryAmount = 8;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		subject.ReferenceIdentificationQualifier = "Wx";
		subject.ReferenceIdentification = "6";
		subject.Year = 6649;
		subject.MonthOfTheYearCode = "ar";
		subject.StandardCarrierAlphaCode = "Mq";
		subject.ReferenceIdentification2 = "A";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*oL*F*9178*Hg*Gb*r*7*yzS9etuf*1982";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceIdentificationQualifier = "oL",
			ReferenceIdentification = "F",
			Year = 9178,
			MonthOfTheYearCode = "Hg",
			StandardCarrierAlphaCode = "Gb",
			ReferenceIdentification2 = "r",
			MonetaryAmount = 7,
			Date = "yzS9etuf",
			ExchangeRate = 1982,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oL", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentification = "F";
		subject.Year = 9178;
		subject.MonthOfTheYearCode = "Hg";
		subject.StandardCarrierAlphaCode = "Gb";
		subject.ReferenceIdentification2 = "r";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "oL";
		subject.Year = 9178;
		subject.MonthOfTheYearCode = "Hg";
		subject.StandardCarrierAlphaCode = "Gb";
		subject.ReferenceIdentification2 = "r";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9178, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "oL";
		subject.ReferenceIdentification = "F";
		subject.MonthOfTheYearCode = "Hg";
		subject.StandardCarrierAlphaCode = "Gb";
		subject.ReferenceIdentification2 = "r";
		subject.MonetaryAmount = 7;
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hg", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "oL";
		subject.ReferenceIdentification = "F";
		subject.Year = 9178;
		subject.StandardCarrierAlphaCode = "Gb";
		subject.ReferenceIdentification2 = "r";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "oL";
		subject.ReferenceIdentification = "F";
		subject.Year = 9178;
		subject.MonthOfTheYearCode = "Hg";
		subject.ReferenceIdentification2 = "r";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "oL";
		subject.ReferenceIdentification = "F";
		subject.Year = 9178;
		subject.MonthOfTheYearCode = "Hg";
		subject.StandardCarrierAlphaCode = "Gb";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "oL";
		subject.ReferenceIdentification = "F";
		subject.Year = 9178;
		subject.MonthOfTheYearCode = "Hg";
		subject.StandardCarrierAlphaCode = "Gb";
		subject.ReferenceIdentification2 = "r";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

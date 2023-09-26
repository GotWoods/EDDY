using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*pB*t*3493*3P*1U*S*3*oP1TNXvs*9492";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceIdentificationQualifier = "pB",
			ReferenceIdentification = "t",
			Year = 3493,
			MonthOfTheYearCode = "3P",
			StandardCarrierAlphaCode = "1U",
			ReferenceIdentification2 = "S",
			MonetaryAmount = 3,
			Date = "oP1TNXvs",
			ExchangeRate = 9492,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pB", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentification = "t";
		subject.Year = 3493;
		subject.MonthOfTheYearCode = "3P";
		subject.StandardCarrierAlphaCode = "1U";
		subject.ReferenceIdentification2 = "S";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "pB";
		subject.Year = 3493;
		subject.MonthOfTheYearCode = "3P";
		subject.StandardCarrierAlphaCode = "1U";
		subject.ReferenceIdentification2 = "S";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3493, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "pB";
		subject.ReferenceIdentification = "t";
		subject.MonthOfTheYearCode = "3P";
		subject.StandardCarrierAlphaCode = "1U";
		subject.ReferenceIdentification2 = "S";
		subject.MonetaryAmount = 3;
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3P", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "pB";
		subject.ReferenceIdentification = "t";
		subject.Year = 3493;
		subject.StandardCarrierAlphaCode = "1U";
		subject.ReferenceIdentification2 = "S";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1U", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "pB";
		subject.ReferenceIdentification = "t";
		subject.Year = 3493;
		subject.MonthOfTheYearCode = "3P";
		subject.ReferenceIdentification2 = "S";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "pB";
		subject.ReferenceIdentification = "t";
		subject.Year = 3493;
		subject.MonthOfTheYearCode = "3P";
		subject.StandardCarrierAlphaCode = "1U";
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "pB";
		subject.ReferenceIdentification = "t";
		subject.Year = 3493;
		subject.MonthOfTheYearCode = "3P";
		subject.StandardCarrierAlphaCode = "1U";
		subject.ReferenceIdentification2 = "S";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

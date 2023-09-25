using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*U8*Z*9529*io*e4*u*7*VN6Yky6n*3914";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceIdentificationQualifier = "U8",
			ReferenceIdentification = "Z",
			Year = 9529,
			MonthOfTheYearCode = "io",
			StandardCarrierAlphaCode = "e4",
			ReferenceIdentification2 = "u",
			MonetaryAmount = 7,
			Date = "VN6Yky6n",
			ExchangeRate = 3914,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U8", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentification = "Z";
		subject.Year = 9529;
		subject.MonthOfTheYearCode = "io";
		subject.StandardCarrierAlphaCode = "e4";
		subject.ReferenceIdentification2 = "u";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "U8";
		subject.Year = 9529;
		subject.MonthOfTheYearCode = "io";
		subject.StandardCarrierAlphaCode = "e4";
		subject.ReferenceIdentification2 = "u";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9529, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "U8";
		subject.ReferenceIdentification = "Z";
		subject.MonthOfTheYearCode = "io";
		subject.StandardCarrierAlphaCode = "e4";
		subject.ReferenceIdentification2 = "u";
		subject.MonetaryAmount = 7;
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("io", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "U8";
		subject.ReferenceIdentification = "Z";
		subject.Year = 9529;
		subject.StandardCarrierAlphaCode = "e4";
		subject.ReferenceIdentification2 = "u";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "U8";
		subject.ReferenceIdentification = "Z";
		subject.Year = 9529;
		subject.MonthOfTheYearCode = "io";
		subject.ReferenceIdentification2 = "u";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "U8";
		subject.ReferenceIdentification = "Z";
		subject.Year = 9529;
		subject.MonthOfTheYearCode = "io";
		subject.StandardCarrierAlphaCode = "e4";
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
		subject.ReferenceIdentificationQualifier = "U8";
		subject.ReferenceIdentification = "Z";
		subject.Year = 9529;
		subject.MonthOfTheYearCode = "io";
		subject.StandardCarrierAlphaCode = "e4";
		subject.ReferenceIdentification2 = "u";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

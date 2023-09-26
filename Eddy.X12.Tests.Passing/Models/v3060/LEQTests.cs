using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*4G*D*54*61*7k*8J*n*1*AV8RMI*5644";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceIdentificationQualifier = "4G",
			ReferenceIdentification = "D",
			Century = 54,
			YearWithinCentury = 61,
			MonthOfTheYearCode = "7k",
			StandardCarrierAlphaCode = "8J",
			ReferenceIdentification2 = "n",
			MonetaryAmount = 1,
			Date = "AV8RMI",
			ExchangeRate = 5644,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4G", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentification = "D";
		subject.Century = 54;
		subject.YearWithinCentury = 61;
		subject.MonthOfTheYearCode = "7k";
		subject.StandardCarrierAlphaCode = "8J";
		subject.ReferenceIdentification2 = "n";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.Century = 54;
		subject.YearWithinCentury = 61;
		subject.MonthOfTheYearCode = "7k";
		subject.StandardCarrierAlphaCode = "8J";
		subject.ReferenceIdentification2 = "n";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(54, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.ReferenceIdentification = "D";
		subject.YearWithinCentury = 61;
		subject.MonthOfTheYearCode = "7k";
		subject.StandardCarrierAlphaCode = "8J";
		subject.ReferenceIdentification2 = "n";
		subject.MonetaryAmount = 1;
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(61, true)]
	public void Validation_RequiredYearWithinCentury(int yearWithinCentury, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.ReferenceIdentification = "D";
		subject.Century = 54;
		subject.MonthOfTheYearCode = "7k";
		subject.StandardCarrierAlphaCode = "8J";
		subject.ReferenceIdentification2 = "n";
		subject.MonetaryAmount = 1;
		//Test Parameters
		if (yearWithinCentury > 0) 
			subject.YearWithinCentury = yearWithinCentury;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7k", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.ReferenceIdentification = "D";
		subject.Century = 54;
		subject.YearWithinCentury = 61;
		subject.StandardCarrierAlphaCode = "8J";
		subject.ReferenceIdentification2 = "n";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8J", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.ReferenceIdentification = "D";
		subject.Century = 54;
		subject.YearWithinCentury = 61;
		subject.MonthOfTheYearCode = "7k";
		subject.ReferenceIdentification2 = "n";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.ReferenceIdentification = "D";
		subject.Century = 54;
		subject.YearWithinCentury = 61;
		subject.MonthOfTheYearCode = "7k";
		subject.StandardCarrierAlphaCode = "8J";
		subject.MonetaryAmount = 1;
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "4G";
		subject.ReferenceIdentification = "D";
		subject.Century = 54;
		subject.YearWithinCentury = 61;
		subject.MonthOfTheYearCode = "7k";
		subject.StandardCarrierAlphaCode = "8J";
		subject.ReferenceIdentification2 = "n";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

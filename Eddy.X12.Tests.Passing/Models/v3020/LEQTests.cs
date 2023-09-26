using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*ei*R*42*11*GX*e*W*9";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceNumberQualifier = "ei",
			ReferenceNumber = "R",
			Century = 42,
			YearWithinCentury = 11,
			MonthOfTheYearCode = "GX",
			ReferenceNumber2 = "e",
			ReferenceNumber3 = "W",
			MonetaryAmount = 9,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ei", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumber = "R";
		subject.Century = 42;
		subject.YearWithinCentury = 11;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber2 = "e";
		subject.ReferenceNumber3 = "W";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.Century = 42;
		subject.YearWithinCentury = 11;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber2 = "e";
		subject.ReferenceNumber3 = "W";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(42, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.ReferenceNumber = "R";
		subject.YearWithinCentury = 11;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber2 = "e";
		subject.ReferenceNumber3 = "W";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(11, true)]
	public void Validation_RequiredYearWithinCentury(int yearWithinCentury, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.ReferenceNumber = "R";
		subject.Century = 42;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber2 = "e";
		subject.ReferenceNumber3 = "W";
		subject.MonetaryAmount = 9;
		//Test Parameters
		if (yearWithinCentury > 0) 
			subject.YearWithinCentury = yearWithinCentury;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GX", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.ReferenceNumber = "R";
		subject.Century = 42;
		subject.YearWithinCentury = 11;
		subject.ReferenceNumber2 = "e";
		subject.ReferenceNumber3 = "W";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.ReferenceNumber = "R";
		subject.Century = 42;
		subject.YearWithinCentury = 11;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber3 = "W";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceNumber3(string referenceNumber3, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.ReferenceNumber = "R";
		subject.Century = 42;
		subject.YearWithinCentury = 11;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber2 = "e";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.ReferenceNumber3 = referenceNumber3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "ei";
		subject.ReferenceNumber = "R";
		subject.Century = 42;
		subject.YearWithinCentury = 11;
		subject.MonthOfTheYearCode = "GX";
		subject.ReferenceNumber2 = "e";
		subject.ReferenceNumber3 = "W";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LEQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEQ*PT*a*19*36*0e*oA*D*8*17dEfa*5337";

		var expected = new LEQ_LeasedEquipmentInformation()
		{
			ReferenceNumberQualifier = "PT",
			ReferenceNumber = "a",
			Century = 19,
			YearWithinCentury = 36,
			MonthOfTheYearCode = "0e",
			StandardCarrierAlphaCode = "oA",
			ReferenceNumber2 = "D",
			MonetaryAmount = 8,
			Date = "17dEfa",
			ExchangeRate = 5337,
		};

		var actual = Map.MapObject<LEQ_LeasedEquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PT", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumber = "a";
		subject.Century = 19;
		subject.YearWithinCentury = 36;
		subject.MonthOfTheYearCode = "0e";
		subject.StandardCarrierAlphaCode = "oA";
		subject.ReferenceNumber2 = "D";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.Century = 19;
		subject.YearWithinCentury = 36;
		subject.MonthOfTheYearCode = "0e";
		subject.StandardCarrierAlphaCode = "oA";
		subject.ReferenceNumber2 = "D";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(19, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.ReferenceNumber = "a";
		subject.YearWithinCentury = 36;
		subject.MonthOfTheYearCode = "0e";
		subject.StandardCarrierAlphaCode = "oA";
		subject.ReferenceNumber2 = "D";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(36, true)]
	public void Validation_RequiredYearWithinCentury(int yearWithinCentury, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.ReferenceNumber = "a";
		subject.Century = 19;
		subject.MonthOfTheYearCode = "0e";
		subject.StandardCarrierAlphaCode = "oA";
		subject.ReferenceNumber2 = "D";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (yearWithinCentury > 0) 
			subject.YearWithinCentury = yearWithinCentury;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0e", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.ReferenceNumber = "a";
		subject.Century = 19;
		subject.YearWithinCentury = 36;
		subject.StandardCarrierAlphaCode = "oA";
		subject.ReferenceNumber2 = "D";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oA", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.ReferenceNumber = "a";
		subject.Century = 19;
		subject.YearWithinCentury = 36;
		subject.MonthOfTheYearCode = "0e";
		subject.ReferenceNumber2 = "D";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.ReferenceNumber = "a";
		subject.Century = 19;
		subject.YearWithinCentury = 36;
		subject.MonthOfTheYearCode = "0e";
		subject.StandardCarrierAlphaCode = "oA";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new LEQ_LeasedEquipmentInformation();
		//Required fields
		subject.ReferenceNumberQualifier = "PT";
		subject.ReferenceNumber = "a";
		subject.Century = 19;
		subject.YearWithinCentury = 36;
		subject.MonthOfTheYearCode = "0e";
		subject.StandardCarrierAlphaCode = "oA";
		subject.ReferenceNumber2 = "D";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

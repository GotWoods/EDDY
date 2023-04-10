using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRD*Yo*6*7*9";

		var expected = new CRD_ContentReportingDetail()
		{
			CountryCode = "Yo",
			AmountQualifierCode = "6",
			MonetaryAmount = 7,
			PercentIntegerFormat = 9,
		};

		var actual = Map.MapObject<CRD_ContentReportingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yo", true)]
	public void Validatation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("6", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("6", 0, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		subject.CountryCode = "Yo";
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(7,9, true)]
	[InlineData(0, 9, true)]
	[InlineData(7, 0, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, int percentIntegerFormat, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		subject.CountryCode = "Yo";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		if (percentIntegerFormat > 0)
		subject.PercentIntegerFormat = percentIntegerFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
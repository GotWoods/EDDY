using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRD*2W*3*6*5";

		var expected = new CRD_ContentReportingDetail()
		{
			CountryCode = "2W",
			AmountQualifierCode = "3",
			MonetaryAmount = 6,
			Percent = 5,
		};

		var actual = Map.MapObject<CRD_ContentReportingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2W", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		//At Least one
		subject.MonetaryAmount = 6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "3";
			subject.MonetaryAmount = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("3", 6, true)]
	[InlineData("3", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		//Required fields
		subject.CountryCode = "2W";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//At Least one
		subject.Percent = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(6, 5, true)]
	[InlineData(6, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, int percent, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		//Required fields
		subject.CountryCode = "2W";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "3";
			subject.MonetaryAmount = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRD*OF*m*5*4";

		var expected = new CRD_ContentReportingDetail()
		{
			CountryCode = "OF",
			AmountQualifierCode = "m",
			MonetaryAmount = 5,
			PercentIntegerFormat = 4,
		};

		var actual = Map.MapObject<CRD_ContentReportingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OF", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		//At Least one
		subject.MonetaryAmount = 5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "m";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("m", 5, true)]
	[InlineData("m", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		//Required fields
		subject.CountryCode = "OF";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//At Least one
		subject.PercentIntegerFormat = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(5, 4, true)]
	[InlineData(5, 0, true)]
	[InlineData(0, 4, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, int percentIntegerFormat, bool isValidExpected)
	{
		var subject = new CRD_ContentReportingDetail();
		//Required fields
		subject.CountryCode = "OF";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percentIntegerFormat > 0) 
			subject.PercentIntegerFormat = percentIntegerFormat;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AmountQualifierCode) || !string.IsNullOrEmpty(subject.AmountQualifierCode) || subject.MonetaryAmount > 0)
		{
			subject.AmountQualifierCode = "m";
			subject.MonetaryAmount = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

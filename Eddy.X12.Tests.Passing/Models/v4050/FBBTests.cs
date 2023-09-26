using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class FBBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FBB*Z2*6*8*2*PJ*2*3";

		var expected = new FBB_ForeignAndIndustryBusiness()
		{
			CountryCode = "Z2",
			MonetaryAmount = 6,
			PercentageAsDecimal = 8,
			IdentificationCodeQualifier = "2",
			IdentificationCode = "PJ",
			MonetaryAmount2 = 2,
			PercentageAsDecimal2 = 3,
		};

		var actual = Map.MapObject<FBB_ForeignAndIndustryBusiness>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z2", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		//At Least one
		subject.MonetaryAmount = 6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "2";
			subject.IdentificationCode = "PJ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.PercentageAsDecimal2 > 0)
		{
			subject.IdentificationCodeQualifier = "2";
			subject.MonetaryAmount2 = 2;
			subject.PercentageAsDecimal2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(6, 8, true)]
	[InlineData(6, 0, true)]
	[InlineData(0, 8, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "Z2";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percentageAsDecimal > 0) 
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "2";
			subject.IdentificationCode = "PJ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.PercentageAsDecimal2 > 0)
		{
			subject.IdentificationCodeQualifier = "2";
			subject.MonetaryAmount2 = 2;
			subject.PercentageAsDecimal2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "PJ", true)]
	[InlineData("2", "", false)]
	[InlineData("", "PJ", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "Z2";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

        if (subject.IdentificationCodeQualifier != "")
            subject.MonetaryAmount2 = 1;
        //At Least one
        subject.MonetaryAmount = 6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("2", 2, 3, true)]
	[InlineData("2", 0, 0, false)]
	[InlineData("", 2, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_IdentificationCodeQualifier(string identificationCodeQualifier, decimal monetaryAmount2, decimal percentageAsDecimal2, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "Z2";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (percentageAsDecimal2 > 0) 
			subject.PercentageAsDecimal2 = percentageAsDecimal2;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

        //At Least one
        subject.MonetaryAmount = 6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

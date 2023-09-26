using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FBBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FBB*jj*6*2*H*EZ*5*4";

		var expected = new FBB_ForeignAndIndustryBusiness()
		{
			CountryCode = "jj",
			MonetaryAmount = 6,
			Percent = 2,
			IdentificationCodeQualifier = "H",
			IdentificationCode = "EZ",
			MonetaryAmount2 = 5,
			Percent2 = 4,
		};

		var actual = Map.MapObject<FBB_ForeignAndIndustryBusiness>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jj", true)]
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
			subject.IdentificationCodeQualifier = "H";
			subject.IdentificationCode = "EZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "H";
			subject.MonetaryAmount2 = 5;
			subject.Percent2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(6, 2, true)]
	[InlineData(6, 0, true)]
	[InlineData(0, 2, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal percent, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "jj";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "H";
			subject.IdentificationCode = "EZ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "H";
			subject.MonetaryAmount2 = 5;
			subject.Percent2 = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "EZ", true)]
	[InlineData("H", "", false)]
	[InlineData("", "EZ", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "jj";
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
	[InlineData("H", 5, 4, true)]
	[InlineData("H", 0, 0, false)]
	[InlineData("", 5, 4, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_IdentificationCodeQualifier(string identificationCodeQualifier, decimal monetaryAmount2, decimal percent2, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "jj";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (percent2 > 0) 
			subject.Percent2 = percent2;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

        //At Least one
        subject.MonetaryAmount = 6;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

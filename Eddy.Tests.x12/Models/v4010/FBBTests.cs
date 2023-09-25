using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class FBBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FBB*IV*5*4*h*A1*5*7";

		var expected = new FBB_ForeignAndIndustryBusiness()
		{
			CountryCode = "IV",
			MonetaryAmount = 5,
			Percent = 4,
			IdentificationCodeQualifier = "h",
			IdentificationCode = "A1",
			MonetaryAmount2 = 5,
			Percent2 = 7,
		};

		var actual = Map.MapObject<FBB_ForeignAndIndustryBusiness>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IV", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		//At Least one
		subject.MonetaryAmount = 5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "h";
			subject.IdentificationCode = "A1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "h";
			subject.MonetaryAmount2 = 5;
			subject.Percent2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(5, 4, true)]
	[InlineData(5, 0, true)]
	[InlineData(0, 4, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal percent, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "IV";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "h";
			subject.IdentificationCode = "A1";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "h";
			subject.MonetaryAmount2 = 5;
			subject.Percent2 = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "A1", true)]
	[InlineData("h", "", false)]
	[InlineData("", "A1", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "IV";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

        if (subject.IdentificationCodeQualifier != "")
            subject.MonetaryAmount2 = 1;

        //At Least one
        subject.MonetaryAmount = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("h", 5, 7, true)]
	[InlineData("h", 0, 0, false)]
	[InlineData("", 5, 7, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_IdentificationCodeQualifier(string identificationCodeQualifier, decimal monetaryAmount2, decimal percent2, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "IV";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (percent2 > 0) 
			subject.Percent2 = percent2;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

        //At Least one
        subject.MonetaryAmount = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

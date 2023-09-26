using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class FBBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FBB*ro*3*5*M*hS*8*9";

		var expected = new FBB_ForeignAndIndustryBusiness()
		{
			CountryCode = "ro",
			MonetaryAmount = 3,
			Percent = 5,
			IdentificationCodeQualifier = "M",
			IdentificationCode = "hS",
			MonetaryAmount2 = 8,
			Percent2 = 9,
		};

		var actual = Map.MapObject<FBB_ForeignAndIndustryBusiness>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ro", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		//At Least one
		subject.MonetaryAmount = 3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "M";
			subject.IdentificationCode = "hS";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "M";
			subject.MonetaryAmount2 = 8;
			subject.Percent2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(3, 5, true)]
	[InlineData(3, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal percent, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "ro";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "M";
			subject.IdentificationCode = "hS";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "M";
			subject.MonetaryAmount2 = 8;
			subject.Percent2 = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "hS", true)]
	[InlineData("M", "", false)]
	[InlineData("", "hS", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "ro";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

        if (subject.IdentificationCodeQualifier != "")
            subject.MonetaryAmount2 = 1;

		//At Least one
		subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("M", 8, 9, true)]
	[InlineData("M", 0, 0, false)]
	[InlineData("", 8, 9, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_IdentificationCodeQualifier(string identificationCodeQualifier, decimal monetaryAmount2, decimal percent2, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "ro";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (percent2 > 0) 
			subject.Percent2 = percent2;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

		//At Least one
		subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

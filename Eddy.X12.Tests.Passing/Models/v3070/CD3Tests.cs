using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD3*Q*9*jg*h*cf*g*zB*j*TR*q*z3*iv*q6X*xV";

		var expected = new CD3_CartonPackageDetail()
		{
			WeightQualifier = "Q",
			Weight = 9,
			Zone = "jg",
			ServiceStandard = "h",
			ServiceLevelCode = "cf",
			PickUpOrDeliveryCode = "g",
			RateValueQualifier = "zB",
			Charge = "j",
			RateValueQualifier2 = "TR",
			Charge2 = "q",
			ServiceLevelCode2 = "z3",
			ServiceLevelCode3 = "iv",
			PaymentMethodCode = "q6X",
			CountryCode = "xV",
		};

		var actual = Map.MapObject<CD3_CartonPackageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Q", 9, true)]
	[InlineData("Q", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "zB";
			subject.Charge = "j";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "TR";
			subject.Charge2 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zB", "j", true)]
	[InlineData("zB", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, string charge, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		subject.Charge = charge;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "Q";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "TR";
			subject.Charge2 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TR", "q", true)]
	[InlineData("TR", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, string charge2, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier2 = rateValueQualifier2;
		subject.Charge2 = charge2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "Q";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "zB";
			subject.Charge = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z3", "cf", true)]
	[InlineData("z3", "", false)]
	[InlineData("", "cf", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "Q";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "zB";
			subject.Charge = "j";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "TR";
			subject.Charge2 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iv", "z3", true)]
	[InlineData("iv", "", false)]
	[InlineData("", "z3", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		//A Requires B
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "cf";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "Q";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "zB";
			subject.Charge = "j";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "TR";
			subject.Charge2 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xV", "cf", true)]
	[InlineData("xV", "", false)]
	[InlineData("", "cf", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		subject.ServiceLevelCode = serviceLevelCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "Q";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "zB";
			subject.Charge = "j";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "TR";
			subject.Charge2 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

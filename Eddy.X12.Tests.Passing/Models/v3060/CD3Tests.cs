using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD3*w*3*rK*q*9o*3*0b*B*Gy*o*uq*Go*XDP*pd";

		var expected = new CD3_CartonPackageDetail()
		{
			WeightQualifier = "w",
			Weight = 3,
			Zone = "rK",
			ServiceStandard = "q",
			ServiceLevelCode = "9o",
			PickUpOrDeliveryCode = "3",
			RateValueQualifier = "0b",
			Charge = "B",
			RateValueQualifier2 = "Gy",
			Charge2 = "o",
			ServiceLevelCode2 = "uq",
			ServiceLevelCode3 = "Go",
			PaymentMethodCode = "XDP",
			CountryCode = "pd",
		};

		var actual = Map.MapObject<CD3_CartonPackageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w", 3, true)]
	[InlineData("w", 0, false)]
	[InlineData("", 3, false)]
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
			subject.RateValueQualifier = "0b";
			subject.Charge = "B";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "Gy";
			subject.Charge2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0b", "B", true)]
	[InlineData("0b", "", false)]
	[InlineData("", "B", false)]
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
			subject.WeightQualifier = "w";
			subject.Weight = 3;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "Gy";
			subject.Charge2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gy", "o", true)]
	[InlineData("Gy", "", false)]
	[InlineData("", "o", false)]
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
			subject.WeightQualifier = "w";
			subject.Weight = 3;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "0b";
			subject.Charge = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uq", "9o", true)]
	[InlineData("uq", "", false)]
	[InlineData("", "9o", true)]
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
			subject.WeightQualifier = "w";
			subject.Weight = 3;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "0b";
			subject.Charge = "B";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "Gy";
			subject.Charge2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Go", "uq", true)]
	[InlineData("Go", "", false)]
	[InlineData("", "uq", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		//A Requires B
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "9o";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "w";
			subject.Weight = 3;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "0b";
			subject.Charge = "B";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "Gy";
			subject.Charge2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pd", "9o", true)]
	[InlineData("pd", "", false)]
	[InlineData("", "9o", true)]
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
			subject.WeightQualifier = "w";
			subject.Weight = 3;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "0b";
			subject.Charge = "B";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "Gy";
			subject.Charge2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

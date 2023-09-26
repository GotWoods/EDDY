using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class CD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD3*F*5*J7*J*CW*e*C6*c*cD*9*TH*VB*nvz*7k";

		var expected = new CD3_CartonPackageDetail()
		{
			WeightQualifier = "F",
			Weight = 5,
			Zone = "J7",
			ServiceStandard = "J",
			ServiceLevelCode = "CW",
			PickupOrDeliveryCode = "e",
			RateValueQualifier = "C6",
			AmountCharged = "c",
			RateValueQualifier2 = "cD",
			AmountCharged2 = "9",
			ServiceLevelCode2 = "TH",
			ServiceLevelCode3 = "VB",
			PaymentMethodCode = "nvz",
			CountryCode = "7k",
		};

		var actual = Map.MapObject<CD3_CartonPackageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("F", 5, true)]
	[InlineData("F", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "C6";
			subject.AmountCharged = "c";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "cD";
			subject.AmountCharged2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C6", "c", true)]
	[InlineData("C6", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, string amountCharged, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		subject.AmountCharged = amountCharged;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "F";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "cD";
			subject.AmountCharged2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cD", "9", true)]
	[InlineData("cD", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, string amountCharged2, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier2 = rateValueQualifier2;
		subject.AmountCharged2 = amountCharged2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "F";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "C6";
			subject.AmountCharged = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TH", "CW", true)]
	[InlineData("TH", "", false)]
	[InlineData("", "CW", true)]
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
			subject.WeightQualifier = "F";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "C6";
			subject.AmountCharged = "c";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "cD";
			subject.AmountCharged2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VB", "TH", true)]
	[InlineData("VB", "", false)]
	[InlineData("", "TH", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		//A Requires B
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "CW";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "F";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "C6";
			subject.AmountCharged = "c";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "cD";
			subject.AmountCharged2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7k", "CW", true)]
	[InlineData("7k", "", false)]
	[InlineData("", "CW", true)]
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
			subject.WeightQualifier = "F";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "C6";
			subject.AmountCharged = "c";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "cD";
			subject.AmountCharged2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

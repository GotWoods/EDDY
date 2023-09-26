using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD3*M*8*4v*1*QJ*F*uH*1*HL*s*YS*A8*Tj4*SN";

		var expected = new CD3_CartonPackageDetail()
		{
			WeightQualifier = "M",
			Weight = 8,
			Zone = "4v",
			ServiceStandard = "1",
			ServiceLevelCode = "QJ",
			PickUpOrDeliveryCode = "F",
			RateValueQualifier = "uH",
			AmountCharged = "1",
			RateValueQualifier2 = "HL",
			AmountCharged2 = "s",
			ServiceLevelCode2 = "YS",
			ServiceLevelCode3 = "A8",
			PaymentMethodCode = "Tj4",
			CountryCode = "SN",
		};

		var actual = Map.MapObject<CD3_CartonPackageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("M", 8, true)]
	[InlineData("M", 0, false)]
	[InlineData("", 8, false)]
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
			subject.RateValueQualifier = "uH";
			subject.AmountCharged = "1";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "HL";
			subject.AmountCharged2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uH", "1", true)]
	[InlineData("uH", "", false)]
	[InlineData("", "1", false)]
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
			subject.WeightQualifier = "M";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "HL";
			subject.AmountCharged2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HL", "s", true)]
	[InlineData("HL", "", false)]
	[InlineData("", "s", false)]
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
			subject.WeightQualifier = "M";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "uH";
			subject.AmountCharged = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("YS", "QJ", true)]
	[InlineData("YS", "", false)]
	[InlineData("", "QJ", true)]
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
			subject.WeightQualifier = "M";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "uH";
			subject.AmountCharged = "1";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "HL";
			subject.AmountCharged2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A8", "YS", true)]
	[InlineData("A8", "", false)]
	[InlineData("", "YS", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new CD3_CartonPackageDetail();
		//Required fields
		//Test Parameters
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		//A Requires B
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "QJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "M";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "uH";
			subject.AmountCharged = "1";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "HL";
			subject.AmountCharged2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SN", "QJ", true)]
	[InlineData("SN", "", false)]
	[InlineData("", "QJ", true)]
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
			subject.WeightQualifier = "M";
			subject.Weight = 8;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.AmountCharged))
		{
			subject.RateValueQualifier = "uH";
			subject.AmountCharged = "1";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.AmountCharged2))
		{
			subject.RateValueQualifier2 = "HL";
			subject.AmountCharged2 = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

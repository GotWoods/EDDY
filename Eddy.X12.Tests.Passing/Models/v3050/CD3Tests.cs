using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD3*c*7*nH*A*WO*6*o6*m*0o*E";

		var expected = new CD3_CartonPackageDetail()
		{
			WeightQualifier = "c",
			Weight = 7,
			Zone = "nH",
			ServiceStandard = "A",
			ServiceLevelCode = "WO",
			PickUpOrDeliveryCode = "6",
			RateValueQualifier = "o6",
			Charge = "m",
			RateValueQualifier2 = "0o",
			Charge2 = "E",
		};

		var actual = Map.MapObject<CD3_CartonPackageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("c", 7, true)]
	[InlineData("c", 0, false)]
	[InlineData("", 7, false)]
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
			subject.RateValueQualifier = "o6";
			subject.Charge = "m";
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "0o";
			subject.Charge2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o6", "m", true)]
	[InlineData("o6", "", false)]
	[InlineData("", "m", false)]
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
			subject.WeightQualifier = "c";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.RateValueQualifier2) || !string.IsNullOrEmpty(subject.Charge2))
		{
			subject.RateValueQualifier2 = "0o";
			subject.Charge2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0o", "E", true)]
	[InlineData("0o", "", false)]
	[InlineData("", "E", false)]
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
			subject.WeightQualifier = "c";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.Charge))
		{
			subject.RateValueQualifier = "o6";
			subject.Charge = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

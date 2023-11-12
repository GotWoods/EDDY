using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MS5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS5*Al*nu*2*OM*dsq";

		var expected = new MS5_ShipmentRatesAndCharges()
		{
			DeclaredValue = "Al",
			RateValueQualifier = "nu",
			FreightRate = 2,
			DeclaredValue2 = "OM",
			CurrencyCode = "dsq",
		};

		var actual = Map.MapObject<MS5_ShipmentRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("nu", 2, true)]
	[InlineData("nu", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal freightRate, bool isValidExpected)
	{
		var subject = new MS5_ShipmentRatesAndCharges();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.CurrencyCode) || !string.IsNullOrEmpty(subject.DeclaredValue) || !string.IsNullOrEmpty(subject.DeclaredValue2))
		{
			subject.CurrencyCode = "dsq";
			subject.DeclaredValue = "Al";
			subject.DeclaredValue2 = "OM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("dsq", "Al", "OM", true)]
	[InlineData("dsq", "", "", false)]
	[InlineData("", "Al", "OM", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CurrencyCode(string currencyCode, string declaredValue, string declaredValue2, bool isValidExpected)
	{
		var subject = new MS5_ShipmentRatesAndCharges();
		//Required fields
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		subject.DeclaredValue = declaredValue;
		subject.DeclaredValue2 = declaredValue2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.RateValueQualifier) || !string.IsNullOrEmpty(subject.RateValueQualifier) || subject.FreightRate > 0)
		{
			subject.RateValueQualifier = "nu";
			subject.FreightRate = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

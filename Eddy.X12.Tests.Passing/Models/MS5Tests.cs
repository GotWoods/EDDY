using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MS5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS5*b7*Li*5*RU*8Dd";

		var expected = new MS5_ShipmentRatesAndCharges()
		{
			DeclaredValue = "b7",
			RateValueQualifier = "Li",
			FreightRate = 5,
			DeclaredValue2 = "RU",
			CurrencyCode = "8Dd",
		};

		var actual = Map.MapObject<MS5_ShipmentRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Li", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("Li", 0, false)]
	public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, decimal freightRate, bool isValidExpected)
	{
		var subject = new MS5_ShipmentRatesAndCharges();
		subject.RateValueQualifier = rateValueQualifier;
		if (freightRate > 0)
		subject.FreightRate = freightRate;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", "", true)]
	[InlineData("8Dd", "", "", false)]
	[InlineData("8Dd", "b7", "", true)]
	[InlineData("8Dd", "", "b7", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CurrencyCode(string currencyCode, string declaredValue, string declaredValue2, bool isValidExpected)
	{
		var subject = new MS5_ShipmentRatesAndCharges();
		subject.CurrencyCode = currencyCode;
		subject.DeclaredValue = declaredValue;
		subject.DeclaredValue2 = declaredValue2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}

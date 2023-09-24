using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RA*n*57*Y5*M*6*H*8*4*eApmZB1L*AYrggFNq";

		var expected = new RA_RateHeader()
		{
			RouteCode = "n",
			RateValueQualifier = "57",
			RateValueQualifier2 = "Y5",
			AlternationPrecedenceCode = "M",
			NumberOfRates = 6,
			UnitConversionFactor = "H",
			RateLevelQualifierCode = "8",
			RateLevel = "4",
			Date = "eApmZB1L",
			Date2 = "AYrggFNq",
		};

		var actual = Map.MapObject<RA_RateHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RateValueQualifier = "57";
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("57", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "n";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8", "4", true)]
	[InlineData("", "4", false)]
	[InlineData("8", "", false)]
	public void Validation_AllAreRequiredRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "n";
		subject.RateValueQualifier = "57";
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

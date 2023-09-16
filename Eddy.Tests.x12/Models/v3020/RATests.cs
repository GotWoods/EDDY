using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RA*w*tX*om*u*1*1*Q*C*O2k0HT*jf3J7i";

		var expected = new RA_RateHeader()
		{
			RouteCode = "w",
			RateValueQualifier = "tX",
			RateValueQualifier2 = "om",
			AlternationPrecedenceCode = "u",
			NumberOfRates = 1,
			UnitConversionFactor = "1",
			RateLevelQualifierCode = "Q",
			RateLevel = "C",
			Date = "O2k0HT",
			Date2 = "jf3J7i",
		};

		var actual = Map.MapObject<RA_RateHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RateValueQualifier = "tX";
		subject.RouteCode = routeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevel))
		{
			subject.RateLevelQualifierCode = "Q";
			subject.RateLevel = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tX", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "w";
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevel))
		{
			subject.RateLevelQualifierCode = "Q";
			subject.RateLevel = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "C", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "w";
		subject.RateValueQualifier = "tX";
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RA*P*hN*53*q*1*M*5*R*xFFxykjk*LO7W4kgF";

		var expected = new RA_RateHeader()
		{
			RouteCode = "P",
			RateValueQualifier = "hN",
			RateValueQualifier2 = "53",
			AlternationPrecedenceCode = "q",
			NumberOfRates = 1,
			UnitConversionFactor = "M",
			RateLevelQualifierCode = "5",
			RateLevel = "R",
			Date = "xFFxykjk",
			Date2 = "LO7W4kgF",
		};

		var actual = Map.MapObject<RA_RateHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RateValueQualifier = "hN";
		subject.RouteCode = routeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevel))
		{
			subject.RateLevelQualifierCode = "5";
			subject.RateLevel = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hN", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "P";
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevelQualifierCode) || !string.IsNullOrEmpty(subject.RateLevel))
		{
			subject.RateLevelQualifierCode = "5";
			subject.RateLevel = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "R", true)]
	[InlineData("5", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredRateLevelQualifierCode(string rateLevelQualifierCode, string rateLevel, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "P";
		subject.RateValueQualifier = "hN";
		subject.RateLevelQualifierCode = rateLevelQualifierCode;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

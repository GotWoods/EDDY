using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RA*n*mJ*ub*c*7*6*s*u*h1g0Bn*WiqVsz";

		var expected = new RA_RateHeader()
		{
			RouteCode = "n",
			RateValueQualifier = "mJ",
			RateValueQualifier2 = "ub",
			AlternationPrecedenceCode = "c",
			NumberOfRates = 7,
			UnitConversionFactor = "6",
			RateLevelQualifierCode = "s",
			RateLevel = "u",
			Date = "h1g0Bn",
			Date2 = "WiqVsz",
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
		subject.RateValueQualifier = "mJ";
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mJ", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RA_RateHeader();
		subject.RouteCode = "n";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

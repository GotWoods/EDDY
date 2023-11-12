using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SS*2Abw9w1j*m*6*8*7fc5jF8I*RiySzpiU*8*xNwYokLY*g";

		var expected = new SS_DocketControlStatus()
		{
			Date = "2Abw9w1j",
			RateLevel = "m",
			RateDistributionCode = "6",
			IndependenceCode = "8",
			Date2 = "7fc5jF8I",
			Date3 = "RiySzpiU",
			NumberOfPeriods = 8,
			Date4 = "xNwYokLY",
			RateMaintenanceAuthorityCode = "g",
		};

		var actual = Map.MapObject<SS_DocketControlStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2Abw9w1j", "m", true)]
	[InlineData("2Abw9w1j", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredDate(string date, string rateLevel, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateDistributionCode = "6";
		subject.Date = date;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredRateDistributionCode(string rateDistributionCode, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateDistributionCode = rateDistributionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.RateLevel))
		{
			subject.Date = "2Abw9w1j";
			subject.RateLevel = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

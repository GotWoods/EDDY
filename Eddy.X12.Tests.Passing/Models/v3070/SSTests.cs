using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SS*T1lxS3*r*s*v*VAExpE*uWelEi*3*lj1JCJ*V";

		var expected = new SS_DocketControlStatus()
		{
			Date = "T1lxS3",
			RateLevel = "r",
			RateDistributionCode = "s",
			IndependenceCode = "v",
			Date2 = "VAExpE",
			Date3 = "uWelEi",
			NumberOfPeriods = 3,
			Date4 = "lj1JCJ",
			RateMaintenanceAuthorityCode = "V",
		};

		var actual = Map.MapObject<SS_DocketControlStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T1lxS3", "r", true)]
	[InlineData("T1lxS3", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDate(string date, string rateLevel, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateDistributionCode = "s";
		subject.Date = date;
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredRateDistributionCode(string rateDistributionCode, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateDistributionCode = rateDistributionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.RateLevel))
		{
			subject.Date = "T1lxS3";
			subject.RateLevel = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

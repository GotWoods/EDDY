using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SS*YEp1Thw9*w*S*c*fKs0yY8h*KYb5xURB*5*n0OTr0yk*D";

		var expected = new SS_DocketControlStatus()
		{
			Date = "YEp1Thw9",
			RateLevel = "w",
			RateDistributionCode = "S",
			IndependenceCode = "c",
			Date2 = "fKs0yY8h",
			Date3 = "KYb5xURB",
			NumberOfPeriods = 5,
			Date4 = "n0OTr0yk",
			RateMaintenanceAuthorityCode = "D",
		};

		var actual = Map.MapObject<SS_DocketControlStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("YEp1Thw9", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("YEp1Thw9", "", false)]
	public void Validation_AllAreRequiredDate(string date, string rateLevel, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateDistributionCode = "S";
		subject.Date = date;
		subject.RateLevel = rateLevel;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredRateDistributionCode(string rateDistributionCode, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateDistributionCode = rateDistributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

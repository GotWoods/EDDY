using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SS*okVsog*l*0*t*ejpuCK*3DQbg7*4*7jnZGp*n";

		var expected = new SS_DocketControlStatus()
		{
			Date = "okVsog",
			RateLevel = "l",
			RateDistributionCode = "0",
			IndependenceCode = "t",
			Date2 = "ejpuCK",
			Date3 = "3DQbg7",
			NumberOfPeriods = 4,
			Date4 = "7jnZGp",
			RateMaintenanceAuthorityCode = "n",
		};

		var actual = Map.MapObject<SS_DocketControlStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("okVsog", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.RateLevel = "l";
		subject.RateDistributionCode = "0";
		subject.IndependenceCode = "t";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredRateLevel(string rateLevel, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.Date = "okVsog";
		subject.RateDistributionCode = "0";
		subject.IndependenceCode = "t";
		subject.RateLevel = rateLevel;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredRateDistributionCode(string rateDistributionCode, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.Date = "okVsog";
		subject.RateLevel = "l";
		subject.IndependenceCode = "t";
		subject.RateDistributionCode = rateDistributionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredIndependenceCode(string independenceCode, bool isValidExpected)
	{
		var subject = new SS_DocketControlStatus();
		subject.Date = "okVsog";
		subject.RateLevel = "l";
		subject.RateDistributionCode = "0";
		subject.IndependenceCode = independenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

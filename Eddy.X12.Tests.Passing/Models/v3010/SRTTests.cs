using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRT*e*g*WO*Ts*1*d*p*z*g*D*5";

		var expected = new SRT_RouteMinimumWeightDetail()
		{
			ChangeTypeCode = "e",
			RouteCode = "g",
			RateValueQualifier = "WO",
			RateValueQualifier2 = "Ts",
			RateApplicationTypeCode = "1",
			Scale = "d",
			Scale2 = "p",
			MinimumWeightLogic = "z",
			LoadingRestriction = "g",
			LoadingRestriction2 = "D",
			Percent = 5,
		};

		var actual = Map.MapObject<SRT_RouteMinimumWeightDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new SRT_RouteMinimumWeightDetail();
		subject.RateValueQualifier = "WO";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WO", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SRT_RouteMinimumWeightDetail();
		subject.ChangeTypeCode = "e";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

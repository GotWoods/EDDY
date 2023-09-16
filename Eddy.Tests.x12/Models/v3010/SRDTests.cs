using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRD*p*5*O*y*5*2*2*3*4*1*1*8*9*2*5*5*2*2*4*3";

		var expected = new SRD_ScaleRateDetail()
		{
			DistanceQualifier = "p",
			RateBasisNumber = "5",
			DistanceQualifier2 = "O",
			RateBasisNumber2 = "y",
			FreightRate = 5,
			FreightRate2 = 2,
			FreightRate3 = 2,
			FreightRate4 = 3,
			FreightRate5 = 4,
			FreightRate6 = 1,
			FreightRate7 = 1,
			FreightRate8 = 8,
			FreightRate9 = 9,
			FreightRate10 = 2,
			FreightRate11 = 5,
			FreightRate12 = 5,
			FreightRate13 = 2,
			FreightRate14 = 2,
			FreightRate15 = 4,
			FreightRate16 = 3,
		};

		var actual = Map.MapObject<SRD_ScaleRateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredDistanceQualifier(string distanceQualifier, bool isValidExpected)
	{
		var subject = new SRD_ScaleRateDetail();
		subject.RateBasisNumber = "5";
		subject.FreightRate = 5;
		subject.DistanceQualifier = distanceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredRateBasisNumber(string rateBasisNumber, bool isValidExpected)
	{
		var subject = new SRD_ScaleRateDetail();
		subject.DistanceQualifier = "p";
		subject.FreightRate = 5;
		subject.RateBasisNumber = rateBasisNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new SRD_ScaleRateDetail();
		subject.DistanceQualifier = "p";
		subject.RateBasisNumber = "5";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

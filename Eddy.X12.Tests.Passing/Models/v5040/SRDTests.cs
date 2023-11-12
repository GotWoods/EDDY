using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class SRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRD*8*i*k*H*3*9*8*6*1*5*5*2*6*7*6*4*2*2*9*1";

		var expected = new SRD_ScaleRateDetail()
		{
			DistanceQualifier = "8",
			RateBasisNumber = "i",
			DistanceQualifier2 = "k",
			RateBasisNumber2 = "H",
			FreightRate = 3,
			FreightRate2 = 9,
			FreightRate3 = 8,
			FreightRate4 = 6,
			FreightRate5 = 1,
			FreightRate6 = 5,
			FreightRate7 = 5,
			FreightRate8 = 2,
			FreightRate9 = 6,
			FreightRate10 = 7,
			FreightRate11 = 6,
			FreightRate12 = 4,
			FreightRate13 = 2,
			FreightRate14 = 2,
			FreightRate15 = 9,
			FreightRate16 = 1,
		};

		var actual = Map.MapObject<SRD_ScaleRateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredDistanceQualifier(string distanceQualifier, bool isValidExpected)
	{
		var subject = new SRD_ScaleRateDetail();
		subject.RateBasisNumber = "i";
		subject.FreightRate = 3;
		subject.DistanceQualifier = distanceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredRateBasisNumber(string rateBasisNumber, bool isValidExpected)
	{
		var subject = new SRD_ScaleRateDetail();
		subject.DistanceQualifier = "8";
		subject.FreightRate = 3;
		subject.RateBasisNumber = rateBasisNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new SRD_ScaleRateDetail();
		subject.DistanceQualifier = "8";
		subject.RateBasisNumber = "i";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

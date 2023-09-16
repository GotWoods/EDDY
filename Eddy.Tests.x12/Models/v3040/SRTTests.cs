using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRT*i*A*Xv*QE*r*y*h*f*D*y*4*fMR*hy";

		var expected = new SRT_ScaleRateHeader()
		{
			ChangeTypeCode = "i",
			RouteCode = "A",
			RateValueQualifier = "Xv",
			RateValueQualifier2 = "QE",
			RateApplicationTypeCode = "r",
			Scale = "y",
			Scale2 = "h",
			MinimumWeightLogic = "f",
			LoadingRestriction = "D",
			LoadingRestriction2 = "y",
			Percent = 4,
			SpecialChargeOrAllowanceCode = "fMR",
			SpecialChargeDescription = "hy",
		};

		var actual = Map.MapObject<SRT_ScaleRateHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new SRT_ScaleRateHeader();
		subject.RateValueQualifier = "Xv";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xv", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SRT_ScaleRateHeader();
		subject.ChangeTypeCode = "i";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

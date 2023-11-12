using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SRTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRT*f*Q*6O*7F*h*I*f*g*M*c*8*iVD*br";

		var expected = new SRT_ScaleRateHeader()
		{
			ChangeTypeCode = "f",
			RouteCode = "Q",
			RateValueQualifier = "6O",
			RateValueQualifier2 = "7F",
			RateApplicationTypeCode = "h",
			Scale = "I",
			Scale2 = "f",
			MinimumWeightLogic = "g",
			LoadingRestriction = "M",
			LoadingRestriction2 = "c",
			PercentIntegerFormat = 8,
			SpecialChargeOrAllowanceCode = "iVD",
			SpecialChargeDescription = "br",
		};

		var actual = Map.MapObject<SRT_ScaleRateHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new SRT_ScaleRateHeader();
		subject.RateValueQualifier = "6O";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6O", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SRT_ScaleRateHeader();
		subject.ChangeTypeCode = "f";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

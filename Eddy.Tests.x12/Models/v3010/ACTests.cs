using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AC*L*b*t*q*E*Q*HD*1*WU*O*EYNq*7*M2Xdjr*rftr2y*ot*rc";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "L",
			CommodityCode = "b",
			RateRequestResponseCode = "t",
			ConveyanceCode = "q",
			LocationQualifier = "E",
			LocationQualifier2 = "Q",
			StateOrProvinceCode = "HD",
			LocationIdentifier = "1",
			StateOrProvinceCode2 = "WU",
			LocationIdentifier2 = "O",
			ConditionCode = "EYNq",
			ConditionValue = "7",
			Date = "M2Xdjr",
			Date2 = "rftr2y",
			StandardCarrierAlphaCode = "ot",
			StandardCarrierAlphaCode2 = "rc",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "b";
		subject.RateRequestResponseCode = "t";
		subject.ConveyanceCode = "q";
		subject.LocationQualifier = "E";
		subject.LocationQualifier2 = "Q";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "L";
		subject.RateRequestResponseCode = "t";
		subject.ConveyanceCode = "q";
		subject.LocationQualifier = "E";
		subject.LocationQualifier2 = "Q";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "b";
		subject.ConveyanceCode = "q";
		subject.LocationQualifier = "E";
		subject.LocationQualifier2 = "Q";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "b";
		subject.RateRequestResponseCode = "t";
		subject.LocationQualifier = "E";
		subject.LocationQualifier2 = "Q";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "b";
		subject.RateRequestResponseCode = "t";
		subject.ConveyanceCode = "q";
		subject.LocationQualifier2 = "Q";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "L";
		subject.CommodityCode = "b";
		subject.RateRequestResponseCode = "t";
		subject.ConveyanceCode = "q";
		subject.LocationQualifier = "E";
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

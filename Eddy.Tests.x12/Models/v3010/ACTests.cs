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
		string x12Line = "AC*C*n*N*S*x*d*eQ*v*LH*1*ft5o*P*SeytIn*KZ5Xdo*oU*hX";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "C",
			CommodityCode = "n",
			RateRequestResponseCode = "N",
			ConveyanceCode = "S",
			LocationQualifier = "x",
			LocationQualifier2 = "d",
			StateOrProvinceCode = "eQ",
			LocationIdentifier = "v",
			StateOrProvinceCode2 = "LH",
			LocationIdentifier2 = "1",
			ConditionCode = "ft5o",
			ConditionValue = "P",
			Date = "SeytIn",
			Date2 = "KZ5Xdo",
			StandardCarrierAlphaCode = "oU",
			StandardCarrierAlphaCode2 = "hX",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "n";
		subject.RateRequestResponseCode = "N";
		subject.ConveyanceCode = "S";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "d";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "C";
		subject.RateRequestResponseCode = "N";
		subject.ConveyanceCode = "S";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "d";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "C";
		subject.CommodityCode = "n";
		subject.ConveyanceCode = "S";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "d";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "C";
		subject.CommodityCode = "n";
		subject.RateRequestResponseCode = "N";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "d";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "C";
		subject.CommodityCode = "n";
		subject.RateRequestResponseCode = "N";
		subject.ConveyanceCode = "S";
		subject.LocationQualifier2 = "d";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "C";
		subject.CommodityCode = "n";
		subject.RateRequestResponseCode = "N";
		subject.ConveyanceCode = "S";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

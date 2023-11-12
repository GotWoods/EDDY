using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AC*K*v*G*R*x*8*yW*1*hA*2*QDwD*Y*tTTtd4*thJqsi*J3*d8";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "K",
			CommodityCode = "v",
			RateRequestResponseCode = "G",
			ConveyanceCode = "R",
			LocationQualifier = "x",
			LocationQualifier2 = "8",
			StateOrProvinceCode = "yW",
			LocationIdentifier = "1",
			StateOrProvinceCode2 = "hA",
			LocationIdentifier2 = "2",
			ConditionCode = "QDwD",
			ConditionValue = "Y",
			Date = "tTTtd4",
			Date2 = "thJqsi",
			StandardCarrierAlphaCode = "J3",
			StandardCarrierAlphaCode2 = "d8",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "v";
		subject.RateRequestResponseCode = "G";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "8";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StateOrProvinceCode = "yW";
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.RateRequestResponseCode = "G";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "8";
		subject.CommodityCode = commodityCode;
		subject.StateOrProvinceCode = "yW";
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.CommodityCode = "v";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "8";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		subject.StateOrProvinceCode = "yW";
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.CommodityCode = "v";
		subject.RateRequestResponseCode = "G";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "8";
		subject.ConveyanceCode = conveyanceCode;
		subject.StateOrProvinceCode = "yW";
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.CommodityCode = "v";
		subject.RateRequestResponseCode = "G";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier2 = "8";
		subject.LocationQualifier = locationQualifier;
		subject.StateOrProvinceCode = "yW";
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.CommodityCode = "v";
		subject.RateRequestResponseCode = "G";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = locationQualifier2;
		subject.StateOrProvinceCode = "yW";
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("yW", "1", true)]
	[InlineData("yW", "", true)]
	[InlineData("", "1", true)]
	public void Validation_AtLeastOneStateOrProvinceCode(string stateOrProvinceCode, string locationIdentifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.CommodityCode = "v";
		subject.RateRequestResponseCode = "G";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "8";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode2 = "hA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("hA", "2", true)]
	[InlineData("hA", "", true)]
	[InlineData("", "2", true)]
	public void Validation_AtLeastOneStateOrProvinceCode2(string stateOrProvinceCode2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "K";
		subject.CommodityCode = "v";
		subject.RateRequestResponseCode = "G";
		subject.ConveyanceCode = "R";
		subject.LocationQualifier = "x";
		subject.LocationQualifier2 = "8";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.StateOrProvinceCode = "yW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

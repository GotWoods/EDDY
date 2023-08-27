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
		string x12Line = "AC*g*X*F*Z*b*I*4x*e*Wr*C*SJNR*s*HN5FWd*YUNZZ8*8w*uZ";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "g",
			CommodityCode = "X",
			RateRequestResponseCode = "F",
			ConveyanceCode = "Z",
			LocationQualifier = "b",
			LocationQualifier2 = "I",
			StateOrProvinceCode = "4x",
			LocationIdentifier = "e",
			StateOrProvinceCode2 = "Wr",
			LocationIdentifier2 = "C",
			ConditionCode = "SJNR",
			ConditionValue = "s",
			Date = "HN5FWd",
			Date2 = "YUNZZ8",
			StandardCarrierAlphaCode = "8w",
			StandardCarrierAlphaCode2 = "uZ",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "F";
		subject.ConveyanceCode = "Z";
		subject.LocationQualifier = "b";
		subject.LocationQualifier2 = "I";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "g";
		subject.RateRequestResponseCode = "F";
		subject.ConveyanceCode = "Z";
		subject.LocationQualifier = "b";
		subject.LocationQualifier2 = "I";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "g";
		subject.CommodityCode = "X";
		subject.ConveyanceCode = "Z";
		subject.LocationQualifier = "b";
		subject.LocationQualifier2 = "I";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "g";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "F";
		subject.LocationQualifier = "b";
		subject.LocationQualifier2 = "I";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "g";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "F";
		subject.ConveyanceCode = "Z";
		subject.LocationQualifier2 = "I";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "g";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "F";
		subject.ConveyanceCode = "Z";
		subject.LocationQualifier = "b";
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

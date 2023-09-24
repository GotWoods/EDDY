using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AC*U*R*W*5*h*g*Cv*g*TW*x*xu9s*q*shSkR4*hPmrVB*1u*pK";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "U",
			CommodityCode = "R",
			RateRequestResponseCode = "W",
			ConveyanceCode = "5",
			LocationQualifier = "h",
			LocationQualifier2 = "g",
			StateOrProvinceCode = "Cv",
			LocationIdentifier = "g",
			StateOrProvinceCode2 = "TW",
			LocationIdentifier2 = "x",
			ConditionCode = "xu9s",
			ConditionValue = "q",
			Date = "shSkR4",
			Date2 = "hPmrVB",
			StandardCarrierAlphaCode = "1u",
			StandardCarrierAlphaCode2 = "pK",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "R";
		subject.RateRequestResponseCode = "W";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = "g";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StateOrProvinceCode = "Cv";
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.RateRequestResponseCode = "W";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = "g";
		subject.CommodityCode = commodityCode;
		subject.StateOrProvinceCode = "Cv";
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "R";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = "g";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		subject.StateOrProvinceCode = "Cv";
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "R";
		subject.RateRequestResponseCode = "W";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = "g";
		subject.ConveyanceCode = conveyanceCode;
		subject.StateOrProvinceCode = "Cv";
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "R";
		subject.RateRequestResponseCode = "W";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier2 = "g";
		subject.LocationQualifier = locationQualifier;
		subject.StateOrProvinceCode = "Cv";
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "R";
		subject.RateRequestResponseCode = "W";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = locationQualifier2;
		subject.StateOrProvinceCode = "Cv";
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Cv", "g", true)]
	[InlineData("Cv", "", true)]
	[InlineData("", "g", true)]
	public void Validation_AtLeastOneStateOrProvinceCode(string stateOrProvinceCode, string locationIdentifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "R";
		subject.RateRequestResponseCode = "W";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = "g";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode2 = "TW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("TW", "x", true)]
	[InlineData("TW", "", true)]
	[InlineData("", "x", true)]
	public void Validation_AtLeastOneStateOrProvinceCode2(string stateOrProvinceCode2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "U";
		subject.CommodityCode = "R";
		subject.RateRequestResponseCode = "W";
		subject.ConveyanceCode = "5";
		subject.LocationQualifier = "h";
		subject.LocationQualifier2 = "g";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.StateOrProvinceCode = "Cv";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

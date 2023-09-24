using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class ACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AC*v*M*d*P*W*O*HK*p*6v*s*cmIC*Z*8EnTIF*tlAdmU*3J*t8";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "v",
			CommodityCode = "M",
			RateRequestResponseCode = "d",
			ConveyanceCode = "P",
			LocationQualifier = "W",
			LocationQualifier2 = "O",
			StateOrProvinceCode = "HK",
			LocationIdentifier = "p",
			StateOrProvinceCode2 = "6v",
			LocationIdentifier2 = "s",
			ConditionCode = "cmIC",
			ConditionValue = "Z",
			Date = "8EnTIF",
			Date2 = "tlAdmU",
			StandardCarrierAlphaCode = "3J",
			StandardCarrierAlphaCode2 = "t8",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "M";
		subject.RateRequestResponseCode = "d";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = "O";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.StateOrProvinceCode = "HK";
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.RateRequestResponseCode = "d";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = "O";
		subject.CommodityCode = commodityCode;
		subject.StateOrProvinceCode = "HK";
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.CommodityCode = "M";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = "O";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		subject.StateOrProvinceCode = "HK";
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.CommodityCode = "M";
		subject.RateRequestResponseCode = "d";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = "O";
		subject.ConveyanceCode = conveyanceCode;
		subject.StateOrProvinceCode = "HK";
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.CommodityCode = "M";
		subject.RateRequestResponseCode = "d";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier2 = "O";
		subject.LocationQualifier = locationQualifier;
		subject.StateOrProvinceCode = "HK";
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.CommodityCode = "M";
		subject.RateRequestResponseCode = "d";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = locationQualifier2;
		subject.StateOrProvinceCode = "HK";
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("HK", "p", true)]
	[InlineData("HK", "", true)]
	[InlineData("", "p", true)]
	public void Validation_AtLeastOneStateOrProvinceCode(string stateOrProvinceCode, string locationIdentifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.CommodityCode = "M";
		subject.RateRequestResponseCode = "d";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = "O";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode2 = "6v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6v", "s", true)]
	[InlineData("6v", "", true)]
	[InlineData("", "s", true)]
	public void Validation_AtLeastOneStateOrProvinceCode2(string stateOrProvinceCode2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "v";
		subject.CommodityCode = "M";
		subject.RateRequestResponseCode = "d";
		subject.ConveyanceCode = "P";
		subject.LocationQualifier = "W";
		subject.LocationQualifier2 = "O";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.StateOrProvinceCode = "HK";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

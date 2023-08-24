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
		string x12Line = "AC*5*X*w*2*d*k*4X*b*So*l*Dp1q*W*j7VmFy*XwSdXH*pB*fa";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "5",
			CommodityCode = "X",
			RateRequestResponseCode = "w",
			ConveyanceCode = "2",
			LocationQualifier = "d",
			LocationQualifier2 = "k",
			StateOrProvinceCode = "4X",
			LocationIdentifier = "b",
			StateOrProvinceCode2 = "So",
			LocationIdentifier2 = "l",
			ConditionCode = "Dp1q",
			ConditionValue = "W",
			Date = "j7VmFy",
			Date2 = "XwSdXH",
			StandardCarrierAlphaCode = "pB",
			StandardCarrierAlphaCode2 = "fa",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "w";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "k";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.RateRequestResponseCode = "w";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "k";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.CommodityCode = "X";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "k";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "w";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "k";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "w";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier2 = "k";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "w";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("4X","b", true)]
	[InlineData("", "b", true)]
	[InlineData("4X", "", true)]
	public void Validation_AtLeastOneStateOrProvinceCode(string stateOrProvinceCode, string locationIdentifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "w";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "k";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("So","l", true)]
	[InlineData("", "l", true)]
	[InlineData("So", "", true)]
	public void Validation_AtLeastOneStateOrProvinceCode2(string stateOrProvinceCode2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "5";
		subject.CommodityCode = "X";
		subject.RateRequestResponseCode = "w";
		subject.ConveyanceCode = "2";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "k";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.LocationIdentifier2 = locationIdentifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

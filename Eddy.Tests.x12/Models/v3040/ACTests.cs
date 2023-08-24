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
		string x12Line = "AC*1*x*u*L*d*8*wn*n*uN*P*JrVA*3*hBUaS0*NFMoG6*I9*nZ";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "1",
			CommodityCode = "x",
			RateRequestResponseCode = "u",
			ConveyanceCode = "L",
			LocationQualifier = "d",
			LocationQualifier2 = "8",
			StateOrProvinceCode = "wn",
			LocationIdentifier = "n",
			StateOrProvinceCode2 = "uN",
			LocationIdentifier2 = "P",
			ConditionCode = "JrVA",
			ConditionValue = "3",
			Date = "hBUaS0",
			Date2 = "NFMoG6",
			StandardCarrierAlphaCode = "I9",
			StandardCarrierAlphaCode2 = "nZ",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "x";
		subject.RateRequestResponseCode = "u";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "8";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.RateRequestResponseCode = "u";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "8";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "x";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "8";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "x";
		subject.RateRequestResponseCode = "u";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "8";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "x";
		subject.RateRequestResponseCode = "u";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier2 = "8";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "x";
		subject.RateRequestResponseCode = "u";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("wn","n", true)]
	[InlineData("", "n", true)]
	[InlineData("wn", "", true)]
	public void Validation_AtLeastOneStateOrProvinceCode(string stateOrProvinceCode, string locationIdentifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "x";
		subject.RateRequestResponseCode = "u";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "8";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("uN","P", true)]
	[InlineData("", "P", true)]
	[InlineData("uN", "", true)]
	public void Validation_AtLeastOneStateOrProvinceCode2(string stateOrProvinceCode2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "1";
		subject.CommodityCode = "x";
		subject.RateRequestResponseCode = "u";
		subject.ConveyanceCode = "L";
		subject.LocationQualifier = "d";
		subject.LocationQualifier2 = "8";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.LocationIdentifier2 = locationIdentifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

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
		string x12Line = "AC*b*J*p*g*O*1*8P*v*fi*v*JE1D*J*KNfDEI*2rbfZw*tm*mf";

		var expected = new AC_MovementRateSetHeader()
		{
			CommodityCodeQualifier = "b",
			CommodityCode = "J",
			RateRequestResponseCode = "p",
			ConveyanceCode = "g",
			LocationQualifier = "O",
			LocationQualifier2 = "1",
			StateOrProvinceCode = "8P",
			LocationIdentifier = "v",
			StateOrProvinceCode2 = "fi",
			LocationIdentifier2 = "v",
			ConditionCode = "JE1D",
			ConditionValue = "J",
			Date = "KNfDEI",
			Date2 = "2rbfZw",
			StandardCarrierAlphaCode = "tm",
			StandardCarrierAlphaCode2 = "mf",
		};

		var actual = Map.MapObject<AC_MovementRateSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredCommodityCodeQualifier(string commodityCodeQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCode = "J";
		subject.RateRequestResponseCode = "p";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = "1";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.RateRequestResponseCode = "p";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = "1";
		subject.CommodityCode = commodityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "J";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = "1";
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "J";
		subject.RateRequestResponseCode = "p";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = "1";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "J";
		subject.RateRequestResponseCode = "p";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier2 = "1";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredLocationQualifier2(string locationQualifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "J";
		subject.RateRequestResponseCode = "p";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = locationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("8P","v", true)]
	[InlineData("", "v", true)]
	[InlineData("8P", "", true)]
	public void Validation_AtLeastOneStateOrProvinceCode(string stateOrProvinceCode, string locationIdentifier, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "J";
		subject.RateRequestResponseCode = "p";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = "1";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("fi","v", true)]
	[InlineData("", "v", true)]
	[InlineData("fi", "", true)]
	public void Validation_AtLeastOneStateOrProvinceCode2(string stateOrProvinceCode2, string locationIdentifier2, bool isValidExpected)
	{
		var subject = new AC_MovementRateSetHeader();
		subject.CommodityCodeQualifier = "b";
		subject.CommodityCode = "J";
		subject.RateRequestResponseCode = "p";
		subject.ConveyanceCode = "g";
		subject.LocationQualifier = "O";
		subject.LocationQualifier2 = "1";
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.LocationIdentifier2 = locationIdentifier2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}

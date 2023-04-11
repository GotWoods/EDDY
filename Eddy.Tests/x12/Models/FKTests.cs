using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FK*uV*l*NP*UW*4*5*9*7*3*4*8*8*9*1";

		var expected = new FK_Factor()
		{
			StandardCarrierAlphaCode = "uV",
			TransportationMethodTypeCode = "l",
			StateOrProvinceCode = "NP",
			CityName = "UW",
			Rule260JunctionCode = "4",
			PercentageDivision = "5",
			FactorAmount = 9,
			FactorAmount2 = 7,
			FactorAmount3 = 3,
			FactorAmount4 = 4,
			FactorAmount5 = 8,
			FactorAmount6 = 8,
			FactorAmount7 = 9,
			FactorAmount8 = 1,
		};

		var actual = Map.MapObject<FK_Factor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		subject.TransportationMethodTypeCode = "l";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		subject.StandardCarrierAlphaCode = "uV";
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("NP", "UW", true)]
	[InlineData("", "UW", false)]
	[InlineData("NP", "", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new FK_Factor();
		subject.StandardCarrierAlphaCode = "uV";
		subject.TransportationMethodTypeCode = "l";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NP", "4", false)]
	[InlineData("", "4", true)]
	[InlineData("NP", "", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		subject.StandardCarrierAlphaCode = "uV";
		subject.TransportationMethodTypeCode = "l";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.Rule260JunctionCode = rule260JunctionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}

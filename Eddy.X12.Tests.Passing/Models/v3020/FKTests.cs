using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class FKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FK*V6*T*pX*4v*e*j*8*3*5*3*7*2*3*2";

		var expected = new FK_Factor()
		{
			StandardCarrierAlphaCode = "V6",
			TransportationMethodTypeCode = "T",
			StateOrProvinceCode = "pX",
			CityName = "4v",
			Rule260JunctionCode = "e",
			PercentageDivision = "j",
			FactorAmount = 8,
			FactorAmount2 = 3,
			FactorAmount3 = 5,
			FactorAmount4 = 3,
			FactorAmount5 = 7,
			FactorAmount6 = 2,
			FactorAmount7 = 3,
			FactorAmount8 = 2,
		};

		var actual = Map.MapObject<FK_Factor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V6", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode = "pX";
			subject.CityName = "4v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "V6";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode = "pX";
			subject.CityName = "4v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pX", "4v", true)]
	[InlineData("pX", "", false)]
	[InlineData("", "4v", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "V6";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pX", "e", false)]
	[InlineData("pX", "", true)]
	[InlineData("", "e", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "V6";
		subject.TransportationMethodTypeCode = "T";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.Rule260JunctionCode = rule260JunctionCode;

        if (subject.StateOrProvinceCode != "")
            subject.CityName = "ABCD";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}

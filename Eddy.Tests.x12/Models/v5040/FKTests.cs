using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class FKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FK*e5*w*Vv*Q2*o*v*2*4*6*9*2*3*1*7";

		var expected = new FK_Factor()
		{
			StandardCarrierAlphaCode = "e5",
			TransportationMethodTypeCode = "w",
			StateOrProvinceCode = "Vv",
			CityName = "Q2",
			Rule260JunctionCode = "o",
			PercentageDivision = "v",
			FactorAmount = 2,
			FactorAmount2 = 4,
			FactorAmount3 = 6,
			FactorAmount4 = 9,
			FactorAmount5 = 2,
			FactorAmount6 = 3,
			FactorAmount7 = 1,
			FactorAmount8 = 7,
		};

		var actual = Map.MapObject<FK_Factor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e5", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.TransportationMethodTypeCode = "w";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode = "Vv";
			subject.CityName = "Q2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "e5";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode = "Vv";
			subject.CityName = "Q2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vv", "Q2", true)]
	[InlineData("Vv", "", false)]
	[InlineData("", "Q2", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "e5";
		subject.TransportationMethodTypeCode = "w";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vv", "o", false)]
	[InlineData("Vv", "", true)]
	[InlineData("", "o", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "e5";
		subject.TransportationMethodTypeCode = "w";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.Rule260JunctionCode = rule260JunctionCode;

        if (subject.StateOrProvinceCode != "")
            subject.CityName = "ABCD";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}

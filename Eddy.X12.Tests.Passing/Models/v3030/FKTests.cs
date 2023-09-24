using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FK*oH*d*fo*sC*c*l*8*9*1*8*7*8*6*8";

		var expected = new FK_Factor()
		{
			StandardCarrierAlphaCode = "oH",
			TransportationMethodTypeCode = "d",
			StateOrProvinceCode = "fo",
			CityName = "sC",
			Rule260JunctionCode = "c",
			PercentageDivision = "l",
			FactorAmount = 8,
			FactorAmount2 = 9,
			FactorAmount3 = 1,
			FactorAmount4 = 8,
			FactorAmount5 = 7,
			FactorAmount6 = 8,
			FactorAmount7 = 6,
			FactorAmount8 = 8,
		};

		var actual = Map.MapObject<FK_Factor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oH", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.TransportationMethodTypeCode = "d";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode = "fo";
			subject.CityName = "sC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "oH";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.StateOrProvinceCode) || !string.IsNullOrEmpty(subject.CityName))
		{
			subject.StateOrProvinceCode = "fo";
			subject.CityName = "sC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fo", "sC", true)]
	[InlineData("fo", "", false)]
	[InlineData("", "sC", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "oH";
		subject.TransportationMethodTypeCode = "d";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fo", "c", false)]
	[InlineData("fo", "", true)]
	[InlineData("", "c", true)]
	public void Validation_OnlyOneOfStateOrProvinceCode(string stateOrProvinceCode, string rule260JunctionCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "oH";
		subject.TransportationMethodTypeCode = "d";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.Rule260JunctionCode = rule260JunctionCode;

        if (subject.StateOrProvinceCode != "")
            subject.CityName = "ABCD";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}

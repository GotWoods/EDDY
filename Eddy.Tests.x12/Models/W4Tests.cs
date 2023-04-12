using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W4*Ej*FO*a*HL*Fp";

		var expected = new W4_ConsignorInformation()
		{
			AbbreviatedCustomerName = "Ej",
			StandardCarrierAlphaCode = "FO",
			FreightStationAccountingCode = "a",
			CityName = "HL",
			StateOrProvinceCode = "Fp",
		};

		var actual = Map.MapObject<W4_ConsignorInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("FO", "a", true)]
	[InlineData("", "a", false)]
	[InlineData("FO", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new W4_ConsignorInformation();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.FreightStationAccountingCode = freightStationAccountingCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("FO","HL", true)]
	[InlineData("", "HL", true)]
	[InlineData("FO", "", true)]
	public void Validation_AtLeastOneStandardCarrierAlphaCode(string standardCarrierAlphaCode, string cityName, bool isValidExpected)
	{
		var subject = new W4_ConsignorInformation();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("HL", "Fp", true)]
	[InlineData("", "Fp", false)]
	[InlineData("HL", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new W4_ConsignorInformation();
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

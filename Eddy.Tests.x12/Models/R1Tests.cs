using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R1*CY*Gt*Z5W*nY9*TPa*eMX*093*YYX*95j*OFN*mpQ*wES*2UQ";

		var expected = new R1_RouteInformationAir()
		{
			StandardCarrierAlphaCode = "CY",
			StandardCarrierAlphaCode2 = "Gt",
			AirportCode = "Z5W",
			AirCarrierCode = "nY9",
			AirportCode2 = "TPa",
			AirCarrierCode2 = "eMX",
			AirportCode3 = "093",
			AirCarrierCode3 = "YYX",
			AirportCode4 = "95j",
			AirCarrierCode4 = "OFN",
			AirportCode5 = "mpQ",
			AirCarrierCode5 = "wES",
			AirportCode6 = "2UQ",
		};

		var actual = Map.MapObject<R1_RouteInformationAir>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z5W", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirCarrierCode = "nY9";
		subject.AirportCode2 = "TPa";
		subject.AirportCode = airportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nY9", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "Z5W";
		subject.AirportCode2 = "TPa";
		subject.AirCarrierCode = airCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TPa", true)]
	public void Validation_RequiredAirportCode2(string airportCode2, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "Z5W";
		subject.AirCarrierCode = "nY9";
		subject.AirportCode2 = airportCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("eMX", "093", true)]
	[InlineData("", "093", false)]
	[InlineData("eMX", "", false)]
	public void Validation_AllAreRequiredAirCarrierCode2(string airCarrierCode2, string airportCode3, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "Z5W";
		subject.AirCarrierCode = "nY9";
		subject.AirportCode2 = "TPa";
		subject.AirCarrierCode2 = airCarrierCode2;
		subject.AirportCode3 = airportCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("YYX", "95j", true)]
	[InlineData("", "95j", false)]
	[InlineData("YYX", "", false)]
	public void Validation_AllAreRequiredAirCarrierCode3(string airCarrierCode3, string airportCode4, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "Z5W";
		subject.AirCarrierCode = "nY9";
		subject.AirportCode2 = "TPa";
		subject.AirCarrierCode3 = airCarrierCode3;
		subject.AirportCode4 = airportCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("OFN", "mpQ", true)]
	[InlineData("", "mpQ", false)]
	[InlineData("OFN", "", false)]
	public void Validation_AllAreRequiredAirCarrierCode4(string airCarrierCode4, string airportCode5, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "Z5W";
		subject.AirCarrierCode = "nY9";
		subject.AirportCode2 = "TPa";
		subject.AirCarrierCode4 = airCarrierCode4;
		subject.AirportCode5 = airportCode5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wES", "2UQ", true)]
	[InlineData("", "2UQ", false)]
	[InlineData("wES", "", false)]
	public void Validation_AllAreRequiredAirCarrierCode5(string airCarrierCode5, string airportCode6, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "Z5W";
		subject.AirCarrierCode = "nY9";
		subject.AirportCode2 = "TPa";
		subject.AirCarrierCode5 = airCarrierCode5;
		subject.AirportCode6 = airportCode6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class R1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R1*wX*2v*5CZ*U50*Jn5*c0z*SCl*Suj*8eK*bVx*H9Q*cu1*M0q";

		var expected = new R1_RouteInformationAir()
		{
			StandardCarrierAlphaCode = "wX",
			StandardCarrierAlphaCode2 = "2v",
			AirportCode = "5CZ",
			AirCarrierCode = "U50",
			AirportCode2 = "Jn5",
			AirCarrierCode2 = "c0z",
			AirportCode3 = "SCl",
			AirCarrierCode3 = "Suj",
			AirportCode4 = "8eK",
			AirCarrierCode4 = "bVx",
			AirportCode5 = "H9Q",
			AirCarrierCode5 = "cu1",
			AirportCode6 = "M0q",
		};

		var actual = Map.MapObject<R1_RouteInformationAir>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5CZ", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirCarrierCode = "U50";
		subject.AirportCode2 = "Jn5";
		subject.AirportCode = airportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U50", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "5CZ";
		subject.AirportCode2 = "Jn5";
		subject.AirCarrierCode = airCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jn5", true)]
	public void Validation_RequiredAirportCode2(string airportCode2, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "5CZ";
		subject.AirCarrierCode = "U50";
		subject.AirportCode2 = airportCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

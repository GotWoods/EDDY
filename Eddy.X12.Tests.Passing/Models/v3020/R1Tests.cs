using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class R1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R1*kA*ww*uBL*wLN*kR5*GdF*7G8*bGf*M6R*e0K*J5r*VMo*tnf";

		var expected = new R1_RouteInformationAir()
		{
			StandardCarrierAlphaCode = "kA",
			StandardCarrierAlphaCode2 = "ww",
			AirportCode = "uBL",
			AirCarrierCode = "wLN",
			AirportCode2 = "kR5",
			AirCarrierCode2 = "GdF",
			AirportCode3 = "7G8",
			AirCarrierCode3 = "bGf",
			AirportCode4 = "M6R",
			AirCarrierCode4 = "e0K",
			AirportCode5 = "J5r",
			AirCarrierCode5 = "VMo",
			AirportCode6 = "tnf",
		};

		var actual = Map.MapObject<R1_RouteInformationAir>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uBL", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirCarrierCode = "wLN";
		subject.AirportCode2 = "kR5";
		subject.AirportCode = airportCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirportCode3))
		{
			subject.AirCarrierCode2 = "GdF";
			subject.AirportCode3 = "7G8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirportCode4))
		{
			subject.AirCarrierCode3 = "bGf";
			subject.AirportCode4 = "M6R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirportCode5))
		{
			subject.AirCarrierCode4 = "e0K";
			subject.AirportCode5 = "J5r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirportCode6))
		{
			subject.AirCarrierCode5 = "VMo";
			subject.AirportCode6 = "tnf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wLN", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "uBL";
		subject.AirportCode2 = "kR5";
		subject.AirCarrierCode = airCarrierCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirportCode3))
		{
			subject.AirCarrierCode2 = "GdF";
			subject.AirportCode3 = "7G8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirportCode4))
		{
			subject.AirCarrierCode3 = "bGf";
			subject.AirportCode4 = "M6R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirportCode5))
		{
			subject.AirCarrierCode4 = "e0K";
			subject.AirportCode5 = "J5r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirportCode6))
		{
			subject.AirCarrierCode5 = "VMo";
			subject.AirportCode6 = "tnf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kR5", true)]
	public void Validation_RequiredAirportCode2(string airportCode2, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "uBL";
		subject.AirCarrierCode = "wLN";
		subject.AirportCode2 = airportCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirportCode3))
		{
			subject.AirCarrierCode2 = "GdF";
			subject.AirportCode3 = "7G8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirportCode4))
		{
			subject.AirCarrierCode3 = "bGf";
			subject.AirportCode4 = "M6R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirportCode5))
		{
			subject.AirCarrierCode4 = "e0K";
			subject.AirportCode5 = "J5r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirportCode6))
		{
			subject.AirCarrierCode5 = "VMo";
			subject.AirportCode6 = "tnf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GdF", "7G8", true)]
	[InlineData("GdF", "", false)]
	[InlineData("", "7G8", false)]
	public void Validation_AllAreRequiredAirCarrierCode2(string airCarrierCode2, string airportCode3, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "uBL";
		subject.AirCarrierCode = "wLN";
		subject.AirportCode2 = "kR5";
		subject.AirCarrierCode2 = airCarrierCode2;
		subject.AirportCode3 = airportCode3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirportCode4))
		{
			subject.AirCarrierCode3 = "bGf";
			subject.AirportCode4 = "M6R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirportCode5))
		{
			subject.AirCarrierCode4 = "e0K";
			subject.AirportCode5 = "J5r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirportCode6))
		{
			subject.AirCarrierCode5 = "VMo";
			subject.AirportCode6 = "tnf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bGf", "M6R", true)]
	[InlineData("bGf", "", false)]
	[InlineData("", "M6R", false)]
	public void Validation_AllAreRequiredAirCarrierCode3(string airCarrierCode3, string airportCode4, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "uBL";
		subject.AirCarrierCode = "wLN";
		subject.AirportCode2 = "kR5";
		subject.AirCarrierCode3 = airCarrierCode3;
		subject.AirportCode4 = airportCode4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirportCode3))
		{
			subject.AirCarrierCode2 = "GdF";
			subject.AirportCode3 = "7G8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirportCode5))
		{
			subject.AirCarrierCode4 = "e0K";
			subject.AirportCode5 = "J5r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirportCode6))
		{
			subject.AirCarrierCode5 = "VMo";
			subject.AirportCode6 = "tnf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e0K", "J5r", true)]
	[InlineData("e0K", "", false)]
	[InlineData("", "J5r", false)]
	public void Validation_AllAreRequiredAirCarrierCode4(string airCarrierCode4, string airportCode5, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "uBL";
		subject.AirCarrierCode = "wLN";
		subject.AirportCode2 = "kR5";
		subject.AirCarrierCode4 = airCarrierCode4;
		subject.AirportCode5 = airportCode5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirportCode3))
		{
			subject.AirCarrierCode2 = "GdF";
			subject.AirportCode3 = "7G8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirportCode4))
		{
			subject.AirCarrierCode3 = "bGf";
			subject.AirportCode4 = "M6R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirCarrierCode5) || !string.IsNullOrEmpty(subject.AirportCode6))
		{
			subject.AirCarrierCode5 = "VMo";
			subject.AirportCode6 = "tnf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VMo", "tnf", true)]
	[InlineData("VMo", "", false)]
	[InlineData("", "tnf", false)]
	public void Validation_AllAreRequiredAirCarrierCode5(string airCarrierCode5, string airportCode6, bool isValidExpected)
	{
		var subject = new R1_RouteInformationAir();
		subject.AirportCode = "uBL";
		subject.AirCarrierCode = "wLN";
		subject.AirportCode2 = "kR5";
		subject.AirCarrierCode5 = airCarrierCode5;
		subject.AirportCode6 = airportCode6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirCarrierCode2) || !string.IsNullOrEmpty(subject.AirportCode3))
		{
			subject.AirCarrierCode2 = "GdF";
			subject.AirportCode3 = "7G8";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirCarrierCode3) || !string.IsNullOrEmpty(subject.AirportCode4))
		{
			subject.AirCarrierCode3 = "bGf";
			subject.AirportCode4 = "M6R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirCarrierCode4) || !string.IsNullOrEmpty(subject.AirportCode5))
		{
			subject.AirCarrierCode4 = "e0K";
			subject.AirportCode5 = "J5r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

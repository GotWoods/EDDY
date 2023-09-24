using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class R6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R6*Z*03m*foV*nj*duihoR*Dm4s*v7T*nnfsQ7*PVFt*IL";

		var expected = new R6_AirItinerary()
		{
			RoutingSequenceCode = "Z",
			AirportCode = "03m",
			AirCarrierCode = "foV",
			FlightVoyageNumber = "nj",
			Date = "duihoR",
			Time = "Dm4s",
			AirportCode2 = "v7T",
			Date2 = "nnfsQ7",
			Time2 = "PVFt",
			CountryCode = "IL",
		};

		var actual = Map.MapObject<R6_AirItinerary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.AirportCode = "03m";
		subject.AirCarrierCode = "foV";
		subject.Date = "duihoR";
		subject.Time = "Dm4s";
		subject.Date2 = "nnfsQ7";
		subject.Time2 = "PVFt";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("03m", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "Z";
		subject.AirCarrierCode = "foV";
		subject.Date = "duihoR";
		subject.Time = "Dm4s";
		subject.Date2 = "nnfsQ7";
		subject.Time2 = "PVFt";
		subject.AirportCode = airportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("foV", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "Z";
		subject.AirportCode = "03m";
		subject.Date = "duihoR";
		subject.Time = "Dm4s";
		subject.Date2 = "nnfsQ7";
		subject.Time2 = "PVFt";
		subject.AirCarrierCode = airCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("duihoR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "Z";
		subject.AirportCode = "03m";
		subject.AirCarrierCode = "foV";
		subject.Time = "Dm4s";
		subject.Date2 = "nnfsQ7";
		subject.Time2 = "PVFt";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dm4s", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "Z";
		subject.AirportCode = "03m";
		subject.AirCarrierCode = "foV";
		subject.Date = "duihoR";
		subject.Date2 = "nnfsQ7";
		subject.Time2 = "PVFt";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nnfsQ7", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "Z";
		subject.AirportCode = "03m";
		subject.AirCarrierCode = "foV";
		subject.Date = "duihoR";
		subject.Time = "Dm4s";
		subject.Time2 = "PVFt";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PVFt", true)]
	public void Validation_RequiredTime2(string time2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "Z";
		subject.AirportCode = "03m";
		subject.AirCarrierCode = "foV";
		subject.Date = "duihoR";
		subject.Time = "Dm4s";
		subject.Date2 = "nnfsQ7";
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

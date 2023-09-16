using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class R6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R6*h*tOB*UbO*i3*XOrZfU*hDG4*HNK*nKrBd9*YdlA*oU";

		var expected = new R6_AirItinerary()
		{
			RoutingSequenceCode = "h",
			AirportCode = "tOB",
			AirCarrierCode = "UbO",
			FlightVoyageNumber = "i3",
			Date = "XOrZfU",
			Time = "hDG4",
			AirportCode2 = "HNK",
			Date2 = "nKrBd9",
			Time2 = "YdlA",
			CountryCode = "oU",
		};

		var actual = Map.MapObject<R6_AirItinerary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.AirportCode = "tOB";
		subject.AirCarrierCode = "UbO";
		subject.Date = "XOrZfU";
		subject.Time = "hDG4";
		subject.Date2 = "nKrBd9";
		subject.Time2 = "YdlA";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tOB", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "h";
		subject.AirCarrierCode = "UbO";
		subject.Date = "XOrZfU";
		subject.Time = "hDG4";
		subject.Date2 = "nKrBd9";
		subject.Time2 = "YdlA";
		subject.AirportCode = airportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UbO", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "h";
		subject.AirportCode = "tOB";
		subject.Date = "XOrZfU";
		subject.Time = "hDG4";
		subject.Date2 = "nKrBd9";
		subject.Time2 = "YdlA";
		subject.AirCarrierCode = airCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XOrZfU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "h";
		subject.AirportCode = "tOB";
		subject.AirCarrierCode = "UbO";
		subject.Time = "hDG4";
		subject.Date2 = "nKrBd9";
		subject.Time2 = "YdlA";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hDG4", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "h";
		subject.AirportCode = "tOB";
		subject.AirCarrierCode = "UbO";
		subject.Date = "XOrZfU";
		subject.Date2 = "nKrBd9";
		subject.Time2 = "YdlA";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nKrBd9", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "h";
		subject.AirportCode = "tOB";
		subject.AirCarrierCode = "UbO";
		subject.Date = "XOrZfU";
		subject.Time = "hDG4";
		subject.Time2 = "YdlA";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YdlA", true)]
	public void Validation_RequiredTime2(string time2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "h";
		subject.AirportCode = "tOB";
		subject.AirCarrierCode = "UbO";
		subject.Date = "XOrZfU";
		subject.Time = "hDG4";
		subject.Date2 = "nKrBd9";
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

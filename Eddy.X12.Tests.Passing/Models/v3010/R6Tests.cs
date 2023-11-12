using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class R6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R6*O*ZUJ*282*tC*w5O4gD*rjdh*WzA*ugjdoH*xk34*mR";

		var expected = new R6_AirItinerary()
		{
			RoutingSequenceCode = "O",
			AirportCode = "ZUJ",
			AirCarrierCode = "282",
			FlightVoyageNumber = "tC",
			EventDate = "w5O4gD",
			EventTime = "rjdh",
			AirportCode2 = "WzA",
			EventDate2 = "ugjdoH",
			EventTime2 = "xk34",
			CountryCode = "mR",
		};

		var actual = Map.MapObject<R6_AirItinerary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.AirportCode = "ZUJ";
		subject.AirCarrierCode = "282";
		subject.EventDate = "w5O4gD";
		subject.EventTime = "rjdh";
		subject.EventDate2 = "ugjdoH";
		subject.EventTime2 = "xk34";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZUJ", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "O";
		subject.AirCarrierCode = "282";
		subject.EventDate = "w5O4gD";
		subject.EventTime = "rjdh";
		subject.EventDate2 = "ugjdoH";
		subject.EventTime2 = "xk34";
		subject.AirportCode = airportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("282", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "O";
		subject.AirportCode = "ZUJ";
		subject.EventDate = "w5O4gD";
		subject.EventTime = "rjdh";
		subject.EventDate2 = "ugjdoH";
		subject.EventTime2 = "xk34";
		subject.AirCarrierCode = airCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w5O4gD", true)]
	public void Validation_RequiredEventDate(string eventDate, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "O";
		subject.AirportCode = "ZUJ";
		subject.AirCarrierCode = "282";
		subject.EventTime = "rjdh";
		subject.EventDate2 = "ugjdoH";
		subject.EventTime2 = "xk34";
		subject.EventDate = eventDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rjdh", true)]
	public void Validation_RequiredEventTime(string eventTime, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "O";
		subject.AirportCode = "ZUJ";
		subject.AirCarrierCode = "282";
		subject.EventDate = "w5O4gD";
		subject.EventDate2 = "ugjdoH";
		subject.EventTime2 = "xk34";
		subject.EventTime = eventTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ugjdoH", true)]
	public void Validation_RequiredEventDate2(string eventDate2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "O";
		subject.AirportCode = "ZUJ";
		subject.AirCarrierCode = "282";
		subject.EventDate = "w5O4gD";
		subject.EventTime = "rjdh";
		subject.EventTime2 = "xk34";
		subject.EventDate2 = eventDate2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xk34", true)]
	public void Validation_RequiredEventTime2(string eventTime2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "O";
		subject.AirportCode = "ZUJ";
		subject.AirCarrierCode = "282";
		subject.EventDate = "w5O4gD";
		subject.EventTime = "rjdh";
		subject.EventDate2 = "ugjdoH";
		subject.EventTime2 = eventTime2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

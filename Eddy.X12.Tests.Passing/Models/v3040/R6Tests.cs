using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class R6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R6*M*Lv1*X5l*XR*ggLgyE*ic2y*04o*cgxGVt*kZlz*tG";

		var expected = new R6_AirItinerary()
		{
			RoutingSequenceCode = "M",
			AirportCode = "Lv1",
			AirCarrierCode = "X5l",
			FlightVoyageNumber = "XR",
			Date = "ggLgyE",
			Time = "ic2y",
			AirportCode2 = "04o",
			Date2 = "cgxGVt",
			Time2 = "kZlz",
			CountryCode = "tG",
		};

		var actual = Map.MapObject<R6_AirItinerary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.AirportCode = "Lv1";
		subject.AirCarrierCode = "X5l";
		subject.Date = "ggLgyE";
		subject.Time = "ic2y";
		subject.Date2 = "cgxGVt";
		subject.Time2 = "kZlz";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lv1", true)]
	public void Validation_RequiredAirportCode(string airportCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "M";
		subject.AirCarrierCode = "X5l";
		subject.Date = "ggLgyE";
		subject.Time = "ic2y";
		subject.Date2 = "cgxGVt";
		subject.Time2 = "kZlz";
		subject.AirportCode = airportCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X5l", true)]
	public void Validation_RequiredAirCarrierCode(string airCarrierCode, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "M";
		subject.AirportCode = "Lv1";
		subject.Date = "ggLgyE";
		subject.Time = "ic2y";
		subject.Date2 = "cgxGVt";
		subject.Time2 = "kZlz";
		subject.AirCarrierCode = airCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ggLgyE", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "M";
		subject.AirportCode = "Lv1";
		subject.AirCarrierCode = "X5l";
		subject.Time = "ic2y";
		subject.Date2 = "cgxGVt";
		subject.Time2 = "kZlz";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ic2y", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "M";
		subject.AirportCode = "Lv1";
		subject.AirCarrierCode = "X5l";
		subject.Date = "ggLgyE";
		subject.Date2 = "cgxGVt";
		subject.Time2 = "kZlz";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cgxGVt", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "M";
		subject.AirportCode = "Lv1";
		subject.AirCarrierCode = "X5l";
		subject.Date = "ggLgyE";
		subject.Time = "ic2y";
		subject.Time2 = "kZlz";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kZlz", true)]
	public void Validation_RequiredTime2(string time2, bool isValidExpected)
	{
		var subject = new R6_AirItinerary();
		subject.RoutingSequenceCode = "M";
		subject.AirportCode = "Lv1";
		subject.AirCarrierCode = "X5l";
		subject.Date = "ggLgyE";
		subject.Time = "ic2y";
		subject.Date2 = "cgxGVt";
		subject.Time2 = time2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

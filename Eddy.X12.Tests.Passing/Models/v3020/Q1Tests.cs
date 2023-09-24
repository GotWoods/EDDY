using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Q1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q1*h*3nf*R1jBQh*Y0h8*id*k*oCP*WF";

		var expected = new Q1_StatusDetailsAir()
		{
			StatusCode = "h",
			StatusLocation = "3nf",
			StatusDate = "R1jBQh",
			StatusTime = "Y0h8",
			FlightVoyageNumber = "id",
			TimeQualifier = "k",
			AirportCode = "oCP",
			CustomsInhibitClearanceCode = "WF",
		};

		var actual = Map.MapObject<Q1_StatusDetailsAir>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusLocation = "3nf";
		subject.StatusDate = "R1jBQh";
		subject.StatusTime = "Y0h8";
		subject.StatusCode = statusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.TimeQualifier))
		{
			subject.FlightVoyageNumber = "id";
			subject.TimeQualifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3nf", true)]
	public void Validation_RequiredStatusLocation(string statusLocation, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "h";
		subject.StatusDate = "R1jBQh";
		subject.StatusTime = "Y0h8";
		subject.StatusLocation = statusLocation;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.TimeQualifier))
		{
			subject.FlightVoyageNumber = "id";
			subject.TimeQualifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R1jBQh", true)]
	public void Validation_RequiredStatusDate(string statusDate, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "h";
		subject.StatusLocation = "3nf";
		subject.StatusTime = "Y0h8";
		subject.StatusDate = statusDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.TimeQualifier))
		{
			subject.FlightVoyageNumber = "id";
			subject.TimeQualifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y0h8", true)]
	public void Validation_RequiredStatusTime(string statusTime, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "h";
		subject.StatusLocation = "3nf";
		subject.StatusDate = "R1jBQh";
		subject.StatusTime = statusTime;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.FlightVoyageNumber) || !string.IsNullOrEmpty(subject.TimeQualifier))
		{
			subject.FlightVoyageNumber = "id";
			subject.TimeQualifier = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("id", "k", true)]
	[InlineData("id", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredFlightVoyageNumber(string flightVoyageNumber, string timeQualifier, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "h";
		subject.StatusLocation = "3nf";
		subject.StatusDate = "R1jBQh";
		subject.StatusTime = "Y0h8";
		subject.FlightVoyageNumber = flightVoyageNumber;
		subject.TimeQualifier = timeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

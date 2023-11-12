using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Q1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q1*R*pJG*inUIBX*Qwz9*G3*f*ELH*UU";

		var expected = new Q1_StatusDetailsAir()
		{
			StatusCode = "R",
			StatusLocation = "pJG",
			StatusDate = "inUIBX",
			StatusTime = "Qwz9",
			FlightVoyageNumber = "G3",
			TimeQualifier = "f",
			AirportCode = "ELH",
			CustomsInhibitClearanceCode = "UU",
		};

		var actual = Map.MapObject<Q1_StatusDetailsAir>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusLocation = "pJG";
		subject.StatusDate = "inUIBX";
		subject.StatusTime = "Qwz9";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pJG", true)]
	public void Validation_RequiredStatusLocation(string statusLocation, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "R";
		subject.StatusDate = "inUIBX";
		subject.StatusTime = "Qwz9";
		subject.StatusLocation = statusLocation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("inUIBX", true)]
	public void Validation_RequiredStatusDate(string statusDate, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "R";
		subject.StatusLocation = "pJG";
		subject.StatusTime = "Qwz9";
		subject.StatusDate = statusDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qwz9", true)]
	public void Validation_RequiredStatusTime(string statusTime, bool isValidExpected)
	{
		var subject = new Q1_StatusDetailsAir();
		subject.StatusCode = "R";
		subject.StatusLocation = "pJG";
		subject.StatusDate = "inUIBX";
		subject.StatusTime = statusTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

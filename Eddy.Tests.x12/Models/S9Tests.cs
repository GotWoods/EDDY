using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S9*4*y0jejD*BV*kP*kX*TI*T*Q";

		var expected = new S9_StopOffStation()
		{
			StopSequenceNumber = 4,
			StandardPointLocationCode = "y0jejD",
			CityName = "BV",
			StateOrProvinceCode = "kP",
			CountryCode = "kX",
			StopReasonCode = "TI",
			LocationQualifier = "T",
			LocationIdentifier = "Q",
		};

		var actual = Map.MapObject<S9_StopOffStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.CityName = "BV";
		subject.StateOrProvinceCode = "kP";
		subject.StopReasonCode = "TI";
		if (stopSequenceNumber > 0)
		subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BV", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 4;
		subject.StateOrProvinceCode = "kP";
		subject.StopReasonCode = "TI";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kP", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 4;
		subject.CityName = "BV";
		subject.StopReasonCode = "TI";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TI", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 4;
		subject.CityName = "BV";
		subject.StateOrProvinceCode = "kP";
		subject.StopReasonCode = stopReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("T", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("T", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 4;
		subject.CityName = "BV";
		subject.StateOrProvinceCode = "kP";
		subject.StopReasonCode = "TI";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

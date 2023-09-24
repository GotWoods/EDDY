using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class S9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S9*9*KiGi1i*M6*KC*sr*I9*w*E";

		var expected = new S9_StopOffStation()
		{
			StopSequenceNumber = 9,
			StandardPointLocationCode = "KiGi1i",
			CityName = "M6",
			StateOrProvinceCode = "KC",
			CountryCode = "sr",
			StopReasonCode = "I9",
			LocationQualifier = "w",
			LocationIdentifier = "E",
		};

		var actual = Map.MapObject<S9_StopOffStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.CityName = "M6";
		subject.StateOrProvinceCode = "KC";
		subject.StopReasonCode = "I9";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "w";
			subject.LocationIdentifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M6", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 9;
		subject.StateOrProvinceCode = "KC";
		subject.StopReasonCode = "I9";
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "w";
			subject.LocationIdentifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KC", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 9;
		subject.CityName = "M6";
		subject.StopReasonCode = "I9";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "w";
			subject.LocationIdentifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I9", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 9;
		subject.CityName = "M6";
		subject.StateOrProvinceCode = "KC";
		subject.StopReasonCode = stopReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "w";
			subject.LocationIdentifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "E", true)]
	[InlineData("w", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 9;
		subject.CityName = "M6";
		subject.StateOrProvinceCode = "KC";
		subject.StopReasonCode = "I9";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

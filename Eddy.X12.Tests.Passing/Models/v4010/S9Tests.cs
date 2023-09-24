using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S9*3*s2drWf*Of*H9*uK*2l*V*r";

		var expected = new S9_StopOffStation()
		{
			StopSequenceNumber = 3,
			StandardPointLocationCode = "s2drWf",
			CityName = "Of",
			StateOrProvinceCode = "H9",
			CountryCode = "uK",
			StopReasonCode = "2l",
			LocationQualifier = "V",
			LocationIdentifier = "r",
		};

		var actual = Map.MapObject<S9_StopOffStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.CityName = "Of";
		subject.StateOrProvinceCode = "H9";
		subject.StopReasonCode = "2l";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "V";
			subject.LocationIdentifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Of", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 3;
		subject.StateOrProvinceCode = "H9";
		subject.StopReasonCode = "2l";
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "V";
			subject.LocationIdentifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H9", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 3;
		subject.CityName = "Of";
		subject.StopReasonCode = "2l";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "V";
			subject.LocationIdentifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2l", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 3;
		subject.CityName = "Of";
		subject.StateOrProvinceCode = "H9";
		subject.StopReasonCode = stopReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "V";
			subject.LocationIdentifier = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "r", true)]
	[InlineData("V", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 3;
		subject.CityName = "Of";
		subject.StateOrProvinceCode = "H9";
		subject.StopReasonCode = "2l";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

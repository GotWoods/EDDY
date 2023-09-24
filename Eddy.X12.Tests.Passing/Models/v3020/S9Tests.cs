using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S9*5*XVt2VZ*JV*33*ym*FI*s*P";

		var expected = new S9_StopOffStation()
		{
			StopSequenceNumber = 5,
			StandardPointLocationCode = "XVt2VZ",
			CityName = "JV",
			StateOrProvinceCode = "33",
			CountryCode = "ym",
			StopReasonCode = "FI",
			LocationQualifier = "s",
			LocationIdentifier = "P",
		};

		var actual = Map.MapObject<S9_StopOffStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.CityName = "JV";
		subject.StateOrProvinceCode = "33";
		subject.StopReasonCode = "FI";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "s";
			subject.LocationIdentifier = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JV", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.StateOrProvinceCode = "33";
		subject.StopReasonCode = "FI";
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "s";
			subject.LocationIdentifier = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("33", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.CityName = "JV";
		subject.StopReasonCode = "FI";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "s";
			subject.LocationIdentifier = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FI", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.CityName = "JV";
		subject.StateOrProvinceCode = "33";
		subject.StopReasonCode = stopReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "s";
			subject.LocationIdentifier = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "P", true)]
	[InlineData("s", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.CityName = "JV";
		subject.StateOrProvinceCode = "33";
		subject.StopReasonCode = "FI";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

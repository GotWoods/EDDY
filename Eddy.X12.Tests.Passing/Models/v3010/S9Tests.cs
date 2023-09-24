using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class S9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S9*5*Tfg84i*4k*Vu*KX*tD*T*u";

		var expected = new S9_StopOffStation()
		{
			StopSequenceNumber = 5,
			StandardPointLocationCode = "Tfg84i",
			CityName = "4k",
			StateOrProvinceCode = "Vu",
			CountryCode = "KX",
			StopReasonCode = "tD",
			LocationQualifier = "T",
			LocationIdentifier = "u",
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
		subject.CityName = "4k";
		subject.StateOrProvinceCode = "Vu";
		subject.StopReasonCode = "tD";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4k", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.StateOrProvinceCode = "Vu";
		subject.StopReasonCode = "tD";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vu", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.CityName = "4k";
		subject.StopReasonCode = "tD";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tD", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S9_StopOffStation();
		subject.StopSequenceNumber = 5;
		subject.CityName = "4k";
		subject.StateOrProvinceCode = "Vu";
		subject.StopReasonCode = stopReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

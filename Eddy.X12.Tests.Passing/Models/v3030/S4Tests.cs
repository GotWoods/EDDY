using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class S4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4*8*j3*Wx*DPy*kk";

		var expected = new S4_StopOffCity()
		{
			StopSequenceNumber = 8,
			CityName = "j3",
			StateOrProvinceCode = "Wx",
			PostalCode = "DPy",
			CountryCode = "kk",
		};

		var actual = Map.MapObject<S4_StopOffCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S4_StopOffCity();
		subject.CityName = "j3";
		subject.StateOrProvinceCode = "Wx";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j3", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new S4_StopOffCity();
		subject.StopSequenceNumber = 8;
		subject.StateOrProvinceCode = "Wx";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wx", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new S4_StopOffCity();
		subject.StopSequenceNumber = 8;
		subject.CityName = "j3";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

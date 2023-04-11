using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GR2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GR2*Jb*v*6*rD*ny*jm*W*1QWJiw83*sfGp*X4*h6*z";

		var expected = new GR2_TrainData()
		{
			StandardCarrierAlphaCode = "Jb",
			LocationQualifier = "v",
			LocationIdentifier = "6",
			CityName = "rD",
			StateOrProvinceCode = "ny",
			CountryCode = "jm",
			InterchangeTrainIdentification = "W",
			Date = "1QWJiw83",
			Time = "sfGp",
			StandardCarrierAlphaCode2 = "X4",
			StandardCarrierAlphaCode3 = "h6",
			InterchangeTrainIdentification2 = "z",
		};

		var actual = Map.MapObject<GR2_TrainData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("v", "6", true)]
	[InlineData("", "6", false)]
	[InlineData("v", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		subject.StandardCarrierAlphaCode = "Jb";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("6","rD", true)]
	[InlineData("", "rD", true)]
	[InlineData("6", "", true)]
	public void Validation_AtLeastOneLocationIdentifier(string locationIdentifier, string cityName, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		subject.StandardCarrierAlphaCode = "Jb";
		subject.LocationIdentifier = locationIdentifier;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("rD", "ny", true)]
	[InlineData("", "ny", false)]
	[InlineData("rD", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GR2_TrainData();
		subject.StandardCarrierAlphaCode = "Jb";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

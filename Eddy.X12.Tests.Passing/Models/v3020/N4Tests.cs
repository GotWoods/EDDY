using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class N4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N4*2S*dx*sP4i*HV*V*5";

		var expected = new N4_GeographicLocation()
		{
			CityName = "2S",
			StateOrProvinceCode = "dx",
			PostalCode = "sP4i",
			CountryCode = "HV",
			LocationQualifier = "V",
			LocationIdentifier = "5",
		};

		var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("2S", "V", true)]
	[InlineData("2S", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOneCityName(string cityName, string locationQualifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.CityName = cityName;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "V";
			subject.LocationIdentifier = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "5", true)]
	[InlineData("V", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.CityName = "2S";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

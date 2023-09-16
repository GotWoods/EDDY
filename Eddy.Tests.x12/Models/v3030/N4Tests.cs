using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class N4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N4*a5*ql*Lwo*zs*0*T";

		var expected = new N4_GeographicLocation()
		{
			CityName = "a5",
			StateOrProvinceCode = "ql",
			PostalCode = "Lwo",
			CountryCode = "zs",
			LocationQualifier = "0",
			LocationIdentifier = "T",
		};

		var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("a5", "0", true)]
	[InlineData("a5", "", true)]
	[InlineData("", "0", true)]
	public void Validation_AtLeastOneCityName(string cityName, string locationQualifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.CityName = cityName;
		subject.LocationQualifier = locationQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "0";
			subject.LocationIdentifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "T", true)]
	[InlineData("0", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
			subject.CityName = "a5";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}

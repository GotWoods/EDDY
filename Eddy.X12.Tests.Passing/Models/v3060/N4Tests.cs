using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class N4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N4*2V*uj*5AF*TT*n*s";

		var expected = new N4_GeographicLocation()
		{
			CityName = "2V",
			StateOrProvinceCode = "uj",
			PostalCode = "5AF",
			CountryCode = "TT",
			LocationQualifier = "n",
			LocationIdentifier = "s",
		};

		var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "n", true)]
	[InlineData("s", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new N4_GeographicLocation();
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}

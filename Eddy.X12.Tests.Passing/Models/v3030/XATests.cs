using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class XATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XA*Gm*th*v2*l";

		var expected = new XA_Authorization()
		{
			Name30CharacterFormat = "Gm",
			CityName = "th",
			StateOrProvinceCode = "v2",
			Authority = "l",
		};

		var actual = Map.MapObject<XA_Authorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gm", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.CityName = "th";
		subject.StateOrProvinceCode = "v2";
		subject.Authority = "l";
		//Test Parameters
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("th", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name30CharacterFormat = "Gm";
		subject.StateOrProvinceCode = "v2";
		subject.Authority = "l";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v2", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name30CharacterFormat = "Gm";
		subject.CityName = "th";
		subject.Authority = "l";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAuthority(string authority, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name30CharacterFormat = "Gm";
		subject.CityName = "th";
		subject.StateOrProvinceCode = "v2";
		//Test Parameters
		subject.Authority = authority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

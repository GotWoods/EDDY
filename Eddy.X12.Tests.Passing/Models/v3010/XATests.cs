using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XA*s6*wr*dN*8";

		var expected = new XA_Authorization()
		{
			Name30CharacterFormat = "s6",
			CityName = "wr",
			StateOrProvinceCode = "dN",
			Authority = "8",
		};

		var actual = Map.MapObject<XA_Authorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s6", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.CityName = "wr";
		subject.StateOrProvinceCode = "dN";
		subject.Authority = "8";
		//Test Parameters
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wr", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name30CharacterFormat = "s6";
		subject.StateOrProvinceCode = "dN";
		subject.Authority = "8";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dN", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name30CharacterFormat = "s6";
		subject.CityName = "wr";
		subject.Authority = "8";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredAuthority(string authority, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name30CharacterFormat = "s6";
		subject.CityName = "wr";
		subject.StateOrProvinceCode = "dN";
		//Test Parameters
		subject.Authority = authority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

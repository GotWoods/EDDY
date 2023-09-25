using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class XATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XA*1*11*UT*l";

		var expected = new XA_Authorization()
		{
			Name = "1",
			CityName = "11",
			StateOrProvinceCode = "UT",
			Authority = "l",
		};

		var actual = Map.MapObject<XA_Authorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.CityName = "11";
		subject.StateOrProvinceCode = "UT";
		subject.Authority = "l";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("11", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name = "1";
		subject.StateOrProvinceCode = "UT";
		subject.Authority = "l";
		//Test Parameters
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UT", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new XA_Authorization();
		//Required fields
		subject.Name = "1";
		subject.CityName = "11";
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
		subject.Name = "1";
		subject.CityName = "11";
		subject.StateOrProvinceCode = "UT";
		//Test Parameters
		subject.Authority = authority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

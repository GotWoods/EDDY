using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class U9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "U9*Ic*dz*9QYU*Yx*QyyqI0";

		var expected = new U9_PriorOriginCity()
		{
			CityName = "Ic",
			StateOrProvinceCode = "dz",
			PostalCode = "9QYU",
			CountryCode = "Yx",
			StandardPointLocationCode = "QyyqI0",
		};

		var actual = Map.MapObject<U9_PriorOriginCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ic", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new U9_PriorOriginCity();
		subject.StateOrProvinceCode = "dz";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dz", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new U9_PriorOriginCity();
		subject.CityName = "Ic";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

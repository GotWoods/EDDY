using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D4*FN*BQ*USWN*r9*SUjJvQ";

		var expected = new D4_ConsigneeCity()
		{
			CityName = "FN",
			StateOrProvinceCode = "BQ",
			PostalCode = "USWN",
			CountryCode = "r9",
			StandardPointLocationCode = "SUjJvQ",
		};

		var actual = Map.MapObject<D4_ConsigneeCity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FN", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new D4_ConsigneeCity();
		subject.StateOrProvinceCode = "BQ";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BQ", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D4_ConsigneeCity();
		subject.CityName = "FN";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

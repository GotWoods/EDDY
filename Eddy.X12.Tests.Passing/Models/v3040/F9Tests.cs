using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*R*lm*Nt*3K*e*wo*WQ*y0SagV*kXW";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "R",
			CityName = "lm",
			StateOrProvinceCode = "Nt",
			CountryCode = "3K",
			FreightStationAccountingCode2 = "e",
			CityName2 = "wo",
			StateOrProvinceCode2 = "WQ",
			StandardPointLocationCode = "y0SagV",
			PostalCode = "kXW",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lm", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "Nt";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nt", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "lm";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

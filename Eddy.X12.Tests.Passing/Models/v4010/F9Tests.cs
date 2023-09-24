using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*L*3w*GN*mF*d*CG*Dh*yTmstq*xyf*WFzulp*KN4*H7";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "L",
			CityName = "3w",
			StateOrProvinceCode = "GN",
			CountryCode = "mF",
			FreightStationAccountingCode2 = "d",
			CityName2 = "CG",
			StateOrProvinceCode2 = "Dh",
			StandardPointLocationCode = "yTmstq",
			PostalCode = "xyf",
			StandardPointLocationCode2 = "WFzulp",
			PostalCode2 = "KN4",
			CountryCode2 = "H7",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3w", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "GN";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GN", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "3w";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}

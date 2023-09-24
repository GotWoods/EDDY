using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*J*CW*3h*uX*Q*Pw*UG*ve9gNs*0vv";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "J",
			OriginStation = "CW",
			StateOrProvinceCode = "3h",
			CountryCode = "uX",
			FreightStationAccountingCode2 = "Q",
			CityName = "Pw",
			StateOrProvinceCode2 = "UG",
			StandardPointLocationCode = "ve9gNs",
			PostalCode = "0vv",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CW", true)]
	public void Validation_RequiredOriginStation(string originStation, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "3h";
		subject.OriginStation = originStation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3h", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.OriginStation = "CW";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
